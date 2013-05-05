using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class System_Object
    {
        //Name:        System.Guid
        //MethodTable: 6f92b1c4
        //EEClass:     6f672adc
        //Size:        24(0x18) bytes
        //File:        C:\Windows\Microsoft.Net\assembly\GAC_32\mscorlib\v4.0_4.0.0.0__b77a5c561934e089\mscorlib.dll
        //Fields:
        //      MT    Field   Offset                 Type VT     Attr    Value Name
        //6f9263a8  4000451        4         System.Int32  1 instance -967707146 _a
        //6f9284b4  4000452        8         System.Int16  1 instance     7181 _b
        //6f9284b4  4000453        a         System.Int16  1 instance    18734 _c
        //6f925fcc  4000454        c          System.Byte  1 instance      138 _d
        //6f925fcc  4000455        d          System.Byte  1 instance      225 _e
        //6f925fcc  4000456        e          System.Byte  1 instance      180 _f
        //6f925fcc  4000457        f          System.Byte  1 instance      239 _g
        //6f925fcc  4000458       10          System.Byte  1 instance      215 _h
        //6f925fcc  4000459       11          System.Byte  1 instance      201 _i
        //6f925fcc  400045a       12          System.Byte  1 instance      213 _j
        //6f925fcc  400045b       13          System.Byte  1 instance        3 _k
        //6f92b1c4  4000450       dc          System.Guid  1   shared   static Empty

        const string header1RegExPattern = " +MT +Field +Offset +Type +VT +Attr +Value +Name";

        string address;
        Dictionary<string, string> properties;
        Dictionary<string, EEField> fields;
        string raw;

        public System_Object(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
        {
            this.address = address;
            this.properties = properties;
            this.fields = fields;
            this.raw = ExtensionApis.StreamToString(output);
        }

        public Dictionary<string, EEField> Fields { get { return this.fields; } }
        protected Dictionary<string, string> Properties { get { return this.properties; } }
        public string Address { get { return this.address; } }
        public string TypeName { get { return this.properties["Name"]; } }
        public string MethodTable { get { return this.properties["MethodTable"]; } }
        public string EEClass { get { return this.properties["EEClass"]; } }

        public override bool Equals(object obj) 
        { 
            System_Object dst = obj as System_Object;
            if (dst == null)
            {
                return false;
            }
            return dst.Address == Address;
        }

        public override int GetHashCode()
        {
            return Address.GetHashCode();
        }

        public string ToString(bool raw)
        {
            if (raw)
            {
                return this.raw;
            }
            else
            {
                return ToOutputString();
            }
        }

        protected virtual string ToOutputString()
        {
            StringBuilder strb = new StringBuilder();
            strb.AppendLine(String.Format("TypeName:        {0}", TypeName));
            strb.AppendLine(String.Format("Address:         {0}", Address));
            return strb.ToString();
        }

        public override string ToString()
        {
            return ToString(true);
        }

        public static System_Object DumpVC(string address, string mt)
        {
            if (IsNullAddress(address))
            {
                return null;
            }
            StreamReader output = ExtensionApis.Execute("!dumpvc {0} {1}", mt, address);
            return Dump(address, output);
        }

        public static System_Object Dump(string address)
        {
            if (IsNullAddress(address))
            {
                return null;
            }
            StreamReader output = ExtensionApis.Execute("!dumpobj {0}", address);
            return Dump(address, output);
        }

        public static bool IsNullAddress(string address)
        {
            return address == "00000000" || address == "0000000000000000";
        }

        static System_Object Dump(string address, StreamReader output)
        {
            Dictionary<string, string> properties = null;
            while (!output.EndOfStream)
            {
                string key;
                string value;
                string line = output.ReadLine();
                if (line.StartsWith("Fields:"))
                {
                    break;
                }
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

            while (!output.EndOfStream)
            {
                string line = output.ReadLine();
                if (ExtensionApis.MatchRegex(header1RegExPattern, line))
                {
                    break;
                }
            }
            Dictionary<string, EEField> fields = new Dictionary<string, EEField>();
            while (!output.EndOfStream)
            {
                string line = output.ReadLine();
                if (line.Contains(">> Domain:Value") || line.StartsWith("None") || line.Contains(">> Thread"))
                {
                    continue;
                }
                EEField field = EEField.Parse(line);
                if (!fields.ContainsKey(field.Name))
                {
                    fields.Add(field.Name, field);
                }
                else
                {
                    fields.Add(field.Name + "_" + field.Offset, field);
                }
            }

            foreach (Type type in typeof(System_Object).Assembly.GetTypes())
            {
                if (type == typeof(System_Object) || !typeof(System_Object).IsAssignableFrom(type))
                    continue;

                MethodInfo method = type.GetMethod("TryCreate", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod);
                if (method == null)
                    continue;

                System_Object obj = (System_Object)method.Invoke(null, new object[] { address, properties, fields, output });
                if (obj != null)
                    return obj;
            }
            return new System_Object(address, properties, fields, output);
        }
    }
}
