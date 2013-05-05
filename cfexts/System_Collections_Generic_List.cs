using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class System_Collections_Generic_List : System_Object
    {
        //Name:        System.Collections.Generic.List`1[[System.String, mscorlib]]
        //MethodTable: 709a745c
        //EEClass:     706fab90
        //Size:        24(0x18) bytes
        //File:        C:\Windows\Microsoft.Net\assembly\GAC_32\mscorlib\v4.0_4.0.0.0__b77a5c561934e089\mscorlib.dll
        //Fields:
        //      MT    Field   Offset                 Type VT     Attr    Value Name
        //70996f60  4000bfd        4      System.Object[]  0 instance 01f1b47c _items
        //709a4348  4000bfe        c         System.Int32  1 instance        1 _size
        //709a4348  4000bff       10         System.Int32  1 instance        1 _version
        //709a2708  4000c00        8        System.Object  0 instance 00000000 _syncRoot
        //70996f60  4000c01        0      System.Object[]  0   shared   static _emptyArray

        System_Collections_Generic_List(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
            : base(address, properties, fields, output)
        {
            Init();
        }

        public int Count { get; private set; }
        public System_Array Items { get; private set; }

        void Init()
        {
            this.Count = Int32.Parse(Fields["_size"].Value);
            this.Items = (System_Array)Fields["_items"].ToObject();
        }

        public static System_Object TryCreate(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
        {
            if (properties["Name"].StartsWith("System.Collections.Generic.List`1[["))
            {
                return new System_Collections_Generic_List(address, properties, fields, output);
            }
            return null;
        }
    }
}
