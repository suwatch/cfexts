using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class EEMethodTable
    {
        static Dictionary<string, EEMethodTable> methodTables = new Dictionary<string, EEMethodTable>();

        //0:014> !dumpmt 6b9d58aa
        //6b9d58aa is not a MethodTable
        //0:014> !dumpmt 6b93193c
        //EEClass:      6a93bfc0
        //Module:       6a8d1000
        //Name:         System.ServiceModel.CommunicationState
        //mdToken:      02000021
        //File:         C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel\v4.0_4.0.0.0__b77a5c561934e089\System.ServiceModel.dll
        //BaseSize:        0xc
        //ComponentSize:   0x0
        //Slots in VTable: 23
        //Number of IFaces in IFaceMap: 3
        string address;
        Dictionary<string, string> properties;
        string raw;

        EEMethodTable(string address, Dictionary<string, string> properties, StreamReader output)
        {
            this.address = address;
            this.properties = properties;
            this.raw = ExtensionApis.StreamToString(output);
        }

        public string Address { get { return address; } }
        public string TypeName { get { return properties["Name"]; } }
        public string EEClass { get { return properties["EEClass"]; } }
        public string File { get { return properties["File"]; } }

        public override string ToString() 
        {
            return this.raw;
            //StringBuilder strb = new StringBuilder();
            //strb.AppendLine(String.Format("MT:        {0}", Address));
            //strb.AppendLine(String.Format("TypeName:  {0}", TypeName));
            //return strb.ToString(); 
        }

        public static EEMethodTable Dump(string address)
        {
            EEMethodTable mt = null;
            if (!methodTables.TryGetValue(address, out mt))
            {
                StreamReader output = ExtensionApis.Execute("!dumpmt {0}", address);
                Dictionary<string, string> properties = null;
                while (!output.EndOfStream)
                {
                    string key;
                    string value;
                    string line = output.ReadLine();
                    if (!ExtensionApis.ParseKeyValuePair(line, out key, out value))
                    {
                        throw ExtensionApis.ThrowKeyValueExceptionHelper(line, output);
                    }
                    if (properties == null)
                    {
                        properties = new Dictionary<string, string>();
                    }
                    properties.Add(key, value);
                }
                if (properties == null)
                {
                    throw ExtensionApis.ThrowExceptionHelper(null, null, output);
                }
                mt = new EEMethodTable(address, properties, output);
                methodTables[address] = mt;
            }
            return mt;
        }

        public static EEMethodTable Dump(string assembly, string typeName)
        {
            // Look up in cache
            foreach (EEMethodTable mt in methodTables.Values)
            {
                if (mt.TypeName == typeName && mt.File.EndsWith(assembly))
                {
                    return mt;
                }
            }

            //0:016> !name2ee System.ServiceModel.dll System.ServiceModel.ServiceHostBase
            //Module:      6a8d1000
            //Assembly:    System.ServiceModel.dll
            //Token:       0200077f
            //MethodTable: 6b9d58d8
            //EEClass:     6a950b2c
            //Name:        System.ServiceModel.ServiceHostBase            
            StreamReader output = ExtensionApis.Execute("!name2ee {0} {1}", assembly, typeName);
            string address = null;
            while (!output.EndOfStream)
            {
                string key;
                string value;
                string line = output.ReadLine();
                if (!ExtensionApis.ParseKeyValuePair(line, out key, out value))
                {
                    throw ExtensionApis.ThrowKeyValueExceptionHelper(line, output);
                }
                if (key == "MethodTable")
                {
                    if (value.Contains("<not loaded yet>"))
                    {
                        throw ExtensionApis.ThrowNotLoadedYetExceptionHelper(output); 
                    }
                    address = value;
                    break;
                }
            }
            if (address == null)
            {
                throw ExtensionApis.ThrowExceptionHelper(null, null, output);
            }

            return EEMethodTable.Dump(address);
        }
    }
}
