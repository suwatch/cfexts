using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class System_Uri : System_Object
    {
        //Name:        System.Uri
        //MethodTable: 6ea5d0e8
        //EEClass:     6e8988ac
        //Size:        40(0x28) bytes
        //File:        C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll
        //Fields:
        //      MT    Field   Offset                 Type VT     Attr    Value Name
        //6fc84be8  4000e25        c        System.String  0 instance 01de923c m_String
        //6fc84be8  4000e26       10        System.String  0 instance 00000000 m_originalUnicodeString
        //6ea5df08  4000e27       14     System.UriParser  0 instance 01de9a48 m_Syntax
        //6fc84be8  4000e28       18        System.String  0 instance 00000000 m_DnsSafeHost
        //6ef20928  4000e29        4        System.UInt64  1 instance 37628346368 m_Flags
        //6ea5e248  4000e2a       1c   System.Uri+UriInfo  0 instance 01e0b238 m_Info
        //6fc8a434  4000e2b       20       System.Boolean  1 instance        0 m_iriParsing
        //6fc84be8  4000e1a      424        System.String  0   static 01de9520 UriSchemeFile
        //6fc84be8  4000e1b      428        System.String  0   static 01de950c UriSchemeFtp
        //6fc84be8  4000e1c      42c        System.String  0   static 01de9538 UriSchemeGopher
        //6fc84be8  4000e1d      430        System.String  0   static 01de94dc UriSchemeHttp
        //6fc84be8  4000e1e      434        System.String  0   static 01de94f4 UriSchemeHttps
        //6fc84be8  4000e1f      438        System.String  0   static 01de9584 UriSchemeMailto
        //6fc84be8  4000e20      43c        System.String  0   static 01de956c UriSchemeNews
        //6fc84be8  4000e21      440        System.String  0   static 01de9554 UriSchemeNntp
        //6fc84be8  4000e22      444        System.String  0   static 01de95ec UriSchemeNetTcp
        //6fc84be8  4000e23      448        System.String  0   static 01de9608 UriSchemeNetPipe
        //6fc84be8  4000e24      44c        System.String  0   static 01de9bd0 SchemeDelimiter
        //6ef3d674  4000e2c      450 ...etSecurityManager  0   static 00000000 s_ManagerRef
        //6fc845a8  4000e2d      454        System.Object  0   static 01de9be4 s_IntranetLock
        //6fc8a434  4000e2e      920       System.Boolean  1   static        0 s_ConfigInitialized
        //6fc8a434  4000e2f      924       System.Boolean  1   static        0 s_ConfigInitializing
        //6ea4a55c  4000e30      928         System.Int32  1   static        0 s_IdnScope
        //6fc8a434  4000e31      92c       System.Boolean  1   static        0 s_IriParsing
        //6fc845a8  4000e32      458        System.Object  0   static 00000000 s_initLock
        //6fc85890  4000e33      45c        System.Char[]  0   static 01de9bf0 HexUpperChars
        //6fc85890  4000e34      460        System.Char[]  0   static 01de9c1c HexLowerChars
        //6fc85890  4000e35      464        System.Char[]  0   static 01de9c48 _WSchars
        System_Uri(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
            : base(address, properties, fields, output)
        {
        }

        public EEField m_String { get { return Fields["m_String"]; } }
        public override string ToString() { return m_String.ToObject().ToString(); }

        public static System_Object TryCreate(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
        {
            if (properties["Name"] == "System.Uri")
            {
                return new System_Uri(address, properties, fields, output);
            }
            return null;
        }
    }
}
