using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DllExporter
{
    class Program
    {
        static string inputFile;
        static bool use64bits;
        static string workingDir;
        static string ilasmPath;
        static string ildasmPath;

        static void Main(string[] args)
        {
            if (args.Length == 0 || !File.Exists(args[0]))
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("1. Add reference to DllExporter.exe to your project;");
                Console.WriteLine("2. Add DllExporter.DllExport attribute to static methods that will be exported;");
                Console.WriteLine("3. Add following post-build command to project properties:");
                Console.WriteLine("    DllExporter.exe $(TargetFileName)");
                Console.WriteLine("    move $(TargetName).Exports$(TargetExt) $(TargetFileName)");
                Console.WriteLine("4. Build project;");
                return;
            }

            try
            {
                inputFile = new FileInfo(args[0]).FullName;
                if (args.Length == 1)
                {
                    Assembly assembly = Assembly.LoadFile(inputFile);
                    PortableExecutableKinds kinds;
                    ImageFileMachine imgFileMachine;
                    assembly.ManifestModule.GetPEKind(out kinds, out imgFileMachine);
                    use64bits = (kinds & PortableExecutableKinds.PE32Plus) == PortableExecutableKinds.PE32Plus;
                }
                else
                {
                    // This is for adhoc test
                    use64bits = args[1] == "64";
                }

                workingDir = GetWorkingDirectory().FullName;

                ilasmPath = GetAssemblerPath();
                ildasmPath = GetDisassemblerPath();

                List<string> methods = GetMethods(inputFile);
                string sourcePath = Disassemble(ildasmPath, inputFile, workingDir);
                string sourceOutPath = Path.Combine(workingDir, "output.il");
                ProcessSource(sourcePath, sourceOutPath, methods);
                string outPath = Assemble(ilasmPath, inputFile, workingDir);

                string newPath = Path.Combine(Path.GetDirectoryName(inputFile), Path.GetFileNameWithoutExtension(outPath) + ".Exports" + Path.GetExtension(outPath));
                File.Delete(newPath);
                File.Move(outPath, newPath);

                string newPdb = Path.Combine(Path.GetDirectoryName(inputFile), Path.GetFileNameWithoutExtension(outPath) + ".Exports.pdb");
                string outPdb = Path.Combine(Path.GetDirectoryName(outPath), Path.GetFileNameWithoutExtension(outPath) + ".pdb");
                File.Delete(newPdb);
                File.Move(outPdb, newPdb);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                Environment.Exit(1);
            }
        }

        static DirectoryInfo GetWorkingDirectory()
        {
            var path = Environment.ExpandEnvironmentVariables(@"%TEMP%\DllExporter");

            var directory = new DirectoryInfo(path);

            if (!directory.Exists)
                directory.Create();

            return directory;
        }

        static string GetDisassemblerPath()
        {
            const string registryPath = @"SOFTWARE\Microsoft\Microsoft SDKs\Windows";
            const string registryValue = "CurrentInstallFolder";

            string path = Environment.ExpandEnvironmentVariables(String.Format(@"%RazzleToolPath%\{0}\managed\v2.0\ildasm.exe", use64bits ? "amd64" : "x86"));
            if (!File.Exists(path))
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(registryPath) ?? Registry.CurrentUser.OpenSubKey(registryPath);
                if (key == null)
                    throw new Exception("Cannot locate registry: " + registryPath);

                path = (string)key.GetValue(registryValue);
                if (path == null)
                    throw new Exception("Cannot locate value: " + registryPath + @"\@" + registryValue);

                path = String.Format(@"{0}Bin{1}{2}", path, use64bits ? @"\x64" : String.Empty, @"\ildasm.exe");
                if (!File.Exists(path))
                    throw new Exception("Cannot locate " + path);
            }
            return path;
        }

        static string GetAssemblerPath()
        {
            string path = Environment.ExpandEnvironmentVariables(String.Format(@"%RazzleToolPath%\{0}\managed\v2.0\ilasm.exe", use64bits ? "amd64" : "x86"));
            if (!File.Exists(path))
            {
                path = Environment.ExpandEnvironmentVariables(String.Format(@"%SystemRoot%\Microsoft.NET\Framework{0}\v2.0.50727\ilasm.exe", use64bits ? "64" : String.Empty));
                //string path = Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), "ilasm.exe");
                if (!File.Exists(path))
                    throw new Exception("Cannot locate " + path);
            }
            return path;
        }

        static string Disassemble(string disassemblerPath, string assemblyPath, string workDir)
        {
            string sourcePath = Path.Combine(workDir, "input.il");
            ProcessStartInfo startInfo = new ProcessStartInfo(disassemblerPath, string.Format(@"""{0}"" /out:""{1}""", assemblyPath, sourcePath)) { WindowStyle = ProcessWindowStyle.Hidden };
            Console.WriteLine(startInfo.FileName + " " + startInfo.Arguments);
            Process process = Process.Start(startInfo);

            process.WaitForExit();

            if (process.ExitCode != 0)
                throw new Exception(string.Format("ildasm.exe has failed disassembling {0}.", assemblyPath));

            return sourcePath;
        }

        static string Assemble(string assemblerPath, string assemblyPath, string workDir)
        {
            string outPath = string.Format(@"{0}\{1}", workDir, Path.GetFileName(assemblyPath));
            string resourcePath = string.Format(@"{0}\{1}", workDir, "input.res");

            StringBuilder args = new StringBuilder();
            args.AppendFormat(@"""{0}\output.il"" /out:""{1}""", workDir, outPath);
            if (Path.GetExtension(assemblyPath) == ".dll")
                args.Append(" /dll");
            if (File.Exists(resourcePath))
                args.AppendFormat(@" /res:""{0}""", resourcePath);
            if (use64bits)
                args.Append(" /x64 /pe64");
            args.Append(" /debug");

            ProcessStartInfo startInfo = new ProcessStartInfo(assemblerPath, args.ToString()) { WindowStyle = ProcessWindowStyle.Hidden };
            Console.WriteLine(startInfo.FileName + " " + startInfo.Arguments);
            Process process = Process.Start(startInfo);

            process.WaitForExit();

            if (process.ExitCode != 0)
                throw new Exception("ilasm.exe has failed assembling generated source.");

            return outPath;
        }

        static List<string> GetMethods(string assemblyPath)
        {
            var methods = new List<string>();

            var assembly = Assembly.LoadFrom(assemblyPath);

            foreach (var type in assembly.GetTypes())
            {
                foreach (var method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    var attributes = method.GetCustomAttributes(typeof(DllExportAttribute), false);
                    if (attributes.Length != 1)
                        continue;

                    var attribute = (DllExportAttribute)attributes[0];

                    methods.Add(attribute.EntryPoint ?? method.Name);
                }
            }

            return methods;
        }

        static void ProcessSource(string sourcePath, string outPath, List<string> methods)
        {
            Console.WriteLine();
            Console.WriteLine("Process IL ...");
            Console.WriteLine();

            using (StreamWriter output = new StreamWriter(outPath, false, Encoding.Default))
            {
                int methodIndex = 0;
                int openBraces = 0;
                bool isMethodStatic = false;

                using (StreamReader reader = new StreamReader(sourcePath, Encoding.Default))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line.TrimStart(' ').StartsWith(".assembly extern DllExporter"))
                        {
                            while (!reader.EndOfStream)
                            {
                                if (reader.ReadLine().StartsWith("}"))
                                {
                                    line = reader.ReadLine();
                                    break;
                                }
                            }
                        }

                        if (line.TrimStart(' ').StartsWith(".corflags"))
                        {
                            if (use64bits)
                                output.WriteLine(line);
                            else
                                output.WriteLine(".corflags 0x00000002");

                            for (int i = 1; i <= methods.Count; i++)
                            {
                                if (use64bits)
                                    output.WriteLine(".vtfixup [1] int64 fromunmanaged at VT_{0}", i);
                                else
                                    output.WriteLine(".vtfixup [1] int32 fromunmanaged at VT_{0}", i);
                                //output.WriteLine(".vtfixup [1] int32 at VT_{0}", i);
                            }

                            for (int i = 1; i <= methods.Count; i++)
                            {
                                if (use64bits)
                                    output.WriteLine(".data VT_{0} = int64(0)", i);
                                else
                                    output.WriteLine(".data VT_{0} = int32(0)", i);
                            }

                            continue;
                        }

                        if (line.TrimStart(' ').StartsWith(".method"))
                            isMethodStatic = line.Contains(" static ");

                        if (line.TrimStart(' ').StartsWith(".custom instance void [DllExporter]DllExporter.DllExportAttribute"))
                        {
                            foreach (var ch in line)
                            {
                                if (ch == '(')
                                    openBraces++;
                                if (ch == ')')
                                    openBraces--;
                            }

                            if (isMethodStatic)
                            {
                                output.WriteLine(".vtentry {0} : 1", methodIndex + 1);
                                output.WriteLine(".export [{0}] as {1}", methodIndex + 1, methods[methodIndex]);

                                methodIndex++;
                            }

                            continue;
                        }

                        if (openBraces > 0)
                        {
                            foreach (var ch in line)
                            {
                                if (ch == '(')
                                    openBraces++;
                                if (ch == ')')
                                    openBraces--;
                            }

                            continue;
                        }

                        output.WriteLine(line);
                    }
                }
            }
        }
    }
}
