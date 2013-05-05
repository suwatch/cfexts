using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class System_String : System_Object
    {
        //Name:        System.String
        //MethodTable: 6fc84be8
        //EEClass:     6f9d0138
        //Size:        72(0x48) bytes
        //File:        C:\Windows\Microsoft.Net\assembly\GAC_32\mscorlib\v4.0_4.0.0.0__b77a5c561934e089\mscorlib.dll
        //String:      This is test string.
        //Fields:
        //      MT    Field   Offset                 Type VT     Attr    Value Name
        //6fc863a8  40000eb        4         System.Int32  1 instance       29 m_stringLength
        //6fc858d0  40000ec        8          System.Char  1 instance       68 m_firstChar
        //6fc84be8  40000ed        8        System.String  0   shared   static Empty
        //    >> Domain:Value  00463960:01de1228 <<

        //Name:        System.ServiceModel.Description.XmlName
        //MethodTable: 01afbec8
        //EEClass:     01b185fc
        //Size:        16(0x10) bytes
        //File:        C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel\v4.0_4.0.0.0__b77a5c561934e089\System.ServiceModel.dll
        //Fields:
        //      MT    Field   Offset                 Type VT     Attr    Value Name
        //70554be8  4002e12        4        System.String  0 instance 00000000 decoded
        //70554be8  4002e13        8        System.String  0 instance 01efce24 encoded

        System_String(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
            : base(address, properties, fields, output)
        {
            Init();
        }

        void Init()
        {
            if (TypeName == "System.ServiceModel.Description.XmlName")
            {
                System_String decoded = (System_String)Fields["decoded"].ToObject();
                if (decoded != null)
                {
                    String = decoded.String;
                }
                else
                {
                    String = ((System_String)Fields["encoded"].ToObject()).String;
                }
            }
            else
            {
                String = Properties["String"];
            }
        }

        public string String { get; private set; }
        public override string ToString() { return String; }
        protected override string ToOutputString() { return String; }

        public static System_Object TryCreate(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
        {
            if (properties["Name"] == "System.String" || properties["Name"] == "System.ServiceModel.Description.XmlName")
            {
                return new System_String(address, properties, fields, output);
            }
            return null;
        }
    }
}
