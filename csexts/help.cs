using System;
using System.Collections.Generic;
using System.Text;
using DllExporter;
using System.Runtime.InteropServices;

namespace CsExts
{
    public static partial class CsExts
    {
        [DllExport]
        public static int help(IntPtr debugClient4, IntPtr args)
        {
            Console.WriteLine("Help for CsExts.dll");
            Console.WriteLine("!dumppo <addr>    - dump PurchaseOrder structure for address");
            Console.WriteLine("!help             - Shows this help");
            return 0;
        }
    }
}
