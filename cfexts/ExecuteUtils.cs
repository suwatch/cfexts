using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Runtime.InteropServices;
using DllExporter;

namespace cfexts
{
    public static partial class ExtensionApis
    {
        const string keyColonValuePattern = "(?<Key>[^:]*): *(?<Value>.*)";
        const string modulePattern = "(?<Start>[^ ]*) +(?<End>[^ ]*) +(?<Module>[^ ]*) .*";

        static Dictionary<string, Regex> regexs = new Dictionary<string, Regex>();

        public static Regex NewRegex(string pattern)
        {
            Regex regex;
            if (!regexs.TryGetValue(pattern, out regex))
            {
                regex = new Regex(pattern, RegexOptions.Compiled);
                regexs.Add(pattern, regex);
            }
            return regex;
        }

        public static bool MatchRegex(string pattern, string input)
        {
            return ExtensionApis.NewRegex(pattern).Match(input).Success;
        }

        //start    end        module name
        //00c10000 00c5a000   TestBeta1   (deferred)
        //657d0000 65814000   System_Transactions   (deferred)
        //65850000 658ef000   System_Transactions_ni   (deferred)
        //69090000 690f3000   System_Xml_Linq_ni   (deferred)
        //69700000 6a230000   System_Web_ni   (deferred)
        //
        //Unloaded modules:
        //75520000 75527000   credssp.dll
        //76960000 77470000   shell32.dll        
        //public static bool IsModuleLoaded(string module)
        //{
        //    StreamReader output = Execute("lm");
        //    if (output.EndOfStream)
        //    {
        //        throw ThrowExceptionHelper(null, null, output);
        //    }
        //    string line = output.ReadLine();
        //    if (!line.StartsWith("start    end"))
        //    {
        //        throw ThrowExceptionHelper("start    end", line, output);
        //    }
        //    Regex regex = ExtensionApis.NewRegex(modulePattern);
        //    string module_ni = module + "_ni";
        //    while (!output.EndOfStream)
        //    {
        //        line = output.ReadLine();
        //        if (String.IsNullOrEmpty(line))
        //        {
        //            return false;
        //        }
        //        Match match = regex.Match(line);
        //        if (!match.Success)
        //        {
        //            throw ThrowExceptionHelper(modulePattern, line, output);
        //        }
        //        if (match.Groups["Module"].Value == module || match.Groups["Module"].Value == module_ni)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public static void loadby_sos_clr()
        {
            StreamReader output = Execute(".loadby sos clr");
            if (!output.EndOfStream)
            {
                throw ThrowExceptionHelper(null, null, output);
            }
        }

        //                                   PreEmptive   GC Alloc                Lock
        //       ID  OSID ThreadOBJ    State GC           Context       Domain   Count APT Exception
        //   0    1  265c 001fb680      a020 Enabled  01fd2e7c:01fd2f2c 001c3980     0 MTA
        //   2    2  10e0 001cc078      b220 Enabled  00000000:00000000 001c3980     0 MTA (Finalizer)
        public static List<System_Threading_Thread> sos_threads()
        {
            StreamReader output = Execute("!threads");
            List<System_Threading_Thread> threads = null;
            while (!output.EndOfStream)
            {
                string line = output.ReadLine();
                if (line.StartsWith("       ID  OSID "))
                {
                    break;
                }
            }

            while (!output.EndOfStream)
            {
                string line = output.ReadLine();
                System_Threading_Thread thread = System_Threading_Thread.Parse(line);
                if (threads == null)
                {
                    threads = new List<System_Threading_Thread>();
                }
                threads.Add(thread);
            }
            if (threads == null)
            {
                throw ThrowExceptionHelper(null, null, output);
            }
            return threads;
        }

        public static bool ParseKeyValuePair(string text, out string key, out string value)
        {
            Regex regex = ExtensionApis.NewRegex(keyColonValuePattern);
            Match match = regex.Match(text);
            bool success = match.Success;
            if (success)
            {
                key = match.Groups["Key"].Value;
                value = match.Groups["Value"].Value;
            }
            else
            {
                key = null;
                value = null;
            }
            return success;
        }

        public static StreamReader Execute(string format, object arg0)
        {
            return Execute(String.Format(format, arg0));
        }

        public static StreamReader Execute(string format, params object[] args)
        {
            return Execute(String.Format(format, args));
        }

        public static StreamReader Execute(string cmd)
        {
            if (Verbose)
            {
                dprintf("Execute({0})\n", cmd);
            }
            MemoryStream mem = new MemoryStream();
            StreamWriter writer =  new StreamWriter(mem);
            output.SetOutput(writer);
            control.Execute(UnsafeNativeMethods.OutputControl.Default, cmd, UnsafeNativeMethods.ExecuteOptions.Default);
            output.SetOutput(null);
            writer.Flush();
            mem.Seek(0, SeekOrigin.Begin);
            return new StreamReader(mem);
        }

        public static string StreamToString(StreamReader output)
        {
            output.BaseStream.Seek(0, SeekOrigin.Begin);
            return output.ReadToEnd();
        }

        public static Exception ThrowNotLoadedYetExceptionHelper(StreamReader output)
        {
            if (ExtensionApis.Verbose)
                dprintf(StreamToString(output));
            return new NotLoadedYetException();
        }

        public static Exception ThrowKeyValueExceptionHelper(string line, StreamReader output)
        {
            return ThrowExceptionHelper(keyColonValuePattern, line, output);
        }

        public static Exception ThrowExceptionHelper(string pattern, string line, StreamReader output)
        {
            Stream stream = output.BaseStream;
            stream.Seek(0, SeekOrigin.Begin);
            return ThrowExceptionHelper(pattern, line, new StreamReader(stream).ReadToEnd());
        }

        public static Exception ThrowExceptionHelper(string pattern, string line, string text)
        {
            if (text != null)
            {
                dprintf(text);
            }
            if (pattern != null)
            {
                dprintf("regx: {0}\n", pattern);
                dprintf("line: {0}\n", line);
            }
            return new ExecutionException(UnsafeNativeMethods.E_FAIL);
        }
    }
}
