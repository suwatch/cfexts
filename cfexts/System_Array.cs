using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class System_Array : System_Object
    {
        //Name:        System.Guid[]
        //MethodTable: 6f937764
        //EEClass:     6f6f1e2c
        //Size:        60(0x3c) bytes
        //Array:       Rank 1, Number of elements 3, Type VALUETYPE // CLASS
        //Element Methodtable: 6f92b1c4
        //[0] 01f77f44
        //[1] 01f77f54
        //[2] 01f77f64
        const string rankLengthRegExPattern = ".*Rank +(?<Rank>[0-9]+).*Number of elements +(?<Length>[0-9]+), Type +(?<VType>.*)";
        const string elementRegExPattern = "\\[(?<Index>[^\\]]*)\\] +(?<Value>[0-9a-fnull]+)";

        Dictionary<string, string> elements;
        Dictionary<string, System_Object> objects;

        System_Array(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
            : base(address, properties, fields, output)
        {
            Init();
        }

        public string Length { get; private set; }
        public string Rank { get; private set; }
        public string Element_VType { get; private set; }
        public bool IsElementCLASS { get { return Element_VType == "CLASS"; } }
        public string Element_Type { get { return Properties["Element Type"]; } }
        public string Element_MT { get { return Properties["Element Methodtable"]; } }
        public Dictionary<string, string> Elements { get { return this.elements; } }

        public static System_Object TryCreate(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
        {
            if (properties.ContainsKey("Array") && properties.ContainsKey("Element Type"))
            {
                return new System_Array(address, properties, fields, output);
            }
            return null;
        }

        void Init()
        {
            StreamReader output = ExtensionApis.Execute("!dumparray {0}", Address);
            while (!output.EndOfStream)
            {
                string key;
                string value;
                string line = output.ReadLine();
                if (!ExtensionApis.ParseKeyValuePair(line, out key, out value))
                {
                    throw ExtensionApis.ThrowKeyValueExceptionHelper(line, output);
                }
                string prevValue;
                if (!Properties.TryGetValue(key, out prevValue))
                {
                    Properties.Add(key, value);
                }
                else
                {
                    // the Name could be mismatched due to baseClass
                    // preferred one from Array
                    if (prevValue != value)
                    {
                        if (key == "Name")
                        {
                            Properties[key] = value;
                        }
                        else
                        {
                            throw new Exception(String.Format("{0}: {1} != {2}", key, prevValue, value));
                        }
                    }
                }

                if (line.StartsWith("Element Methodtable:"))
                {
                    break;
                }
            }

            Regex regex = ExtensionApis.NewRegex(rankLengthRegExPattern);
            Match match = regex.Match(Properties["Array"]);
            if (!match.Success)
            {
                throw ExtensionApis.ThrowExceptionHelper(rankLengthRegExPattern, Properties["Array"], output);
            }
            this.Rank = match.Groups["Rank"].Value;
            this.Length = match.Groups["Length"].Value;
            this.Element_VType = match.Groups["VType"].Value;

            regex = ExtensionApis.NewRegex(elementRegExPattern);
            this.elements = new Dictionary<string, string>();
            while (!output.EndOfStream)
            {
                string line = output.ReadLine();
                match = regex.Match(line);
                if (!match.Success)
                {
                    throw ExtensionApis.ThrowExceptionHelper(elementRegExPattern, line, output);
                }
                this.elements.Add(match.Groups["Index"].Value, match.Groups["Value"].Value);
            }
            this.objects = new Dictionary<string, System_Object>();
        }

        public System_Object GetObject(string index)
        {
            System_Object obj;
            if (this.objects.TryGetValue(index, out obj))
            {
                return obj;
            }
            string elem = this.elements[index];
            if (elem == "null")
            {
                return null;
            }
            obj = IsElementCLASS ? System_Object.Dump(elem) : System_Object.DumpVC(elem, Element_MT);
            this.objects[index] = obj;
            return obj;
        }

        //public override string ToString()
        //{
        //    StringBuilder strb = new StringBuilder();
        //    strb.AppendLine(String.Format("TypeName:        {0}", TypeName));
        //    strb.AppendLine(String.Format("Address:         {0}", Address));
        //    strb.AppendLine(String.Format("Length:          {0}", Length));
        //    strb.AppendLine(String.Format("Rank:            {0}", Rank));
        //    strb.AppendLine(String.Format("Element_Type:    {0}", Element_Type));
        //    strb.AppendLine(String.Format("Element_MT:      {0}", Element_MT));
        //    strb.AppendLine(String.Format("Element_VType:   {0}", Element_VType));
        //    foreach (KeyValuePair<string, string> pair in this.elements)
        //    {
        //        strb.AppendLine(String.Format("[{0}] {1}", pair.Key, pair.Value));
        //    }
        //    return strb.ToString();
        //}
    }
}
