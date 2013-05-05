using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class System_Guid : System_Object
    {
        //Name:        System.Guid
        //MethodTable: 6f937764
        //EEClass:     6f6f1e2c
        //Size:        60(0x3c) bytes
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
        Guid guid;

        System_Guid(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
            : base(address, properties, fields, output)
        {
            Init();
        }

        void Init()
        {
            // 00000000-0000-0000-0000-000000000000
            this.guid = new Guid(
                Int32.Parse(Fields["_a"].Value), Int16.Parse(Fields["_b"].Value), Int16.Parse(Fields["_c"].Value),
                Byte.Parse(Fields["_d"].Value), Byte.Parse(Fields["_e"].Value), Byte.Parse(Fields["_f"].Value), Byte.Parse(Fields["_g"].Value),
                Byte.Parse(Fields["_h"].Value), Byte.Parse(Fields["_i"].Value), Byte.Parse(Fields["_j"].Value), Byte.Parse(Fields["_k"].Value)
                );
        }

        public Guid Guid { get { return this.guid; } }
        public override string ToString() { return this.guid.ToString(); }
        protected override string ToOutputString() { return this.guid.ToString(); }

        public static System_Object TryCreate(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
        {
            if (properties["Name"] == "System.Guid")
            {
                return new System_Guid(address, properties, fields, output);
            }
            return null;
        }
    }
}
