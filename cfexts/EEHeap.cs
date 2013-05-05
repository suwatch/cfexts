using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class EEHeap
    {
        //------------------------------
        //Heap 0
        //         Address               MT     Size
        //00000000ff5f8370 000007ff002ff2c0      128
        //00000000ff5f8b60 000007ff002ff2c0      128
        //00000000ff60d568 000007ff00428620       64
        //total 0 objects
        //------------------------------
        //Heap 1
        //         Address               MT     Size
        //000000013f611b08 000007ff002fdc80       72
        //000000013f611e38 000007ff002fe228       24
        //000000013f611e98 000007ff002fe860       88
        //000000013f611ef0 000007ff002fe7d0       40
        //000000013f611f30 000007ff002fe7d0       40
        //000000013f611f70 000007ff002fe7d0       40
        //000000013f611fb0 000007ff002fe7d0       40
        //000000013f611ff0 000007ff002fe7d0       40
        //000000013f612030 000007ff002fe7d0       40
        //000000013f612070 000007ff002fe7d0       40
        //000000013f6120b0 000007ff002fe7d0       40
        //000000013f6120f0 000007ff002fe7d0       40
        //000000013f612130 000007ff002fe7d0       40
        //000000013f612170 000007ff002fe7d0       40
        //000000013f6121b0 000007ff002fe7d0       40
        //000000013f612268 000007ff002fef40      576
        //000000013f6124a8 000007ff002fe7d0       40
        //000000013f6124e8 000007ff002fe7d0       40
        //000000013f612528 000007ff002fe7d0       40
        //000000013f612568 000007ff002fe7d0       40
        //000000013f6125a8 000007ff002fe7d0       40
        //000000013f6125e8 000007ff002fe7d0       40
        //000000013f612628 000007ff002fe7d0       40
        //000000013f8120d0 000007ff0040b158       32
        //000000013fc191e0 000007ff0040eb18       40
        //000000013fc19208 000007ff0058b940       40
        //000000013fc194d8 000007ff00587c78       64
        //000000013fd89348 000007ff0042a5f0      328
        //total 0 objects
        //------------------------------

        // Address       MT     Size
        //020fd998 0033229c      248
        //021065ac 6ba32ac0       20
        //021065c0 6b9a69f4       24
        //021068c0 558bda2c       36
        //object 0000000012863aa0: does not have valid MT
        //curr_object:      0000000012863aa0
        //Last good object: 0000000012853b80
        //----------------
        //total 0 objects
        //Statistics:
        //      MT    Count    TotalSize Class Name
        //6ba32ac0        1           20 System.ServiceModel.ExtensionCollection`1[[System.ServiceModel.ServiceHostBase, System.ServiceModel]]
        //6b9a69f4        1           24 System.Collections.Generic.List`1[[System.ServiceModel.IExtension`1[[System.ServiceModel.ServiceHostBase, System.ServiceModel]], System.ServiceModel]]
        //558bda2c        1           36 System.ServiceModel.Activities.WorkflowServiceHost+WorkflowServiceHostExtensions
        //0033229c        1          248 TestBeta1.MyWorkflowServiceHost
        //Total 4 objects

        const string header1RegExPattern = " +Address +MT +Size";
        const string header2RegExPattern = " +MT +Count +TotalSize +Class Name";

        const string regExPattern = "(?<Address>[0-9a-f]+)"
            + " +(?<MT>[0-9a-f]+)"
            + " +(?<Size>[0-9]+)";
        const string methodTablesRegExPattern = "(?<MT>[0-9a-f]+)"
            + " +(?<Count>[0-9]+)"
            + " +(?<TotalSize>[0-9]+)"
            + " +(?<Class_Name>.+)";

        Dictionary<string, List<string>> objects;
        Dictionary<string, string> methodTables;
        string raw;

        EEHeap(Dictionary<string, List<string>> objects, Dictionary<string, string> methodTables, StreamReader output)
        {
            this.objects = objects;
            this.methodTables = methodTables;
            this.raw = ExtensionApis.StreamToString(output);
        }

        // MT to Address(es)
        public Dictionary<string, List<string>> Objects { get { return this.objects; } }
        // MT to Class Name
        public Dictionary<string, string> MethodTables { get { return this.methodTables; } }

        public override string ToString()
        {
            return this.raw;
            //StringBuilder strb = new StringBuilder();
            //strb.AppendLine(" Address       MT");
            //foreach (KeyValuePair<string, List<string>> pair in this.objects)
            //{
            //    foreach (string address in pair.Value)
            //    {
            //        strb.AppendLine(String.Format("{0} {1} {2}", address, pair.Key, this.methodTables[pair.Key]));
            //    }
            //}
            //return strb.ToString();
        }

        public static EEHeap Dump(string args)
        {
            StreamReader output = ExtensionApis.Execute("!dumpheap {0}", args);
            Dictionary<string, List<string>> objects = null;
            while (!output.EndOfStream)
            {
                string line = output.ReadLine();
                if (ExtensionApis.MatchRegex(header1RegExPattern, line))
                {
                    break;
                }
            }

            Regex regex = ExtensionApis.NewRegex(regExPattern);
            while (!output.EndOfStream)
            {
                string line = output.ReadLine();
                if (line.StartsWith("Statistics:"))
                {
                    if (objects == null)
                    {
                        objects = new Dictionary<string, List<string>>();
                    }
                    break;
                }
                
                //object 0000000012863aa0: does not have valid MT
                //curr_object:      0000000012863aa0
                //Last good object: 0000000012853b80
                //----------------
                if (line.StartsWith("object ") ||
                    line.StartsWith("curr_object") ||
                    line.StartsWith("Last good object") ||
                    line.StartsWith("--------") ||
                    line.StartsWith("Heap ") ||
                    line.Contains(" Address ") ||
                    line.StartsWith("total "))
                {
                    continue;
                }
                
                Match match = regex.Match(line);
                if (!match.Success)
                {
                    throw ExtensionApis.ThrowExceptionHelper(regExPattern, line, output);
                }

                string mt = match.Groups["MT"].Value;
                string address = match.Groups["Address"].Value;
                List<string> addresses;
                if (objects == null)
                {
                    objects = new Dictionary<string, List<string>>();
                }
                if (!objects.TryGetValue(mt, out addresses))
                {
                    addresses = new List<string>();
                    objects.Add(mt, addresses);
                }
                addresses.Add(address);
            }
            if (objects == null)
            {
                throw ExtensionApis.ThrowExceptionHelper(null, null, output);
            }

            Dictionary<string, string> methodTables = null;
            while (!output.EndOfStream)
            {
                string line = output.ReadLine();
                if (ExtensionApis.MatchRegex(header2RegExPattern, line))
                {
                    break;
                }
            }
            regex = ExtensionApis.NewRegex(methodTablesRegExPattern);
            while (!output.EndOfStream)
            {
                string line = output.ReadLine();
                if (line.StartsWith("Total "))
                {
                    if (methodTables == null)
                    {
                        methodTables = new Dictionary<string, string>();
                    }
                    break;
                }

                Match match = regex.Match(line);
                if (!match.Success)
                {
                    throw ExtensionApis.ThrowExceptionHelper(methodTablesRegExPattern, line, output);
                }

                string mt = match.Groups["MT"].Value;
                string className = match.Groups["Class_Name"].Value;
                if (methodTables == null)
                {
                    methodTables = new Dictionary<string, string>();
                }
                methodTables.Add(mt, className);
            }
            if (methodTables == null)
            {
                throw ExtensionApis.ThrowExceptionHelper(null, null, output);
            }

            return new EEHeap(objects, methodTables, output);
        }
    }
}
