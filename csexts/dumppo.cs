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
        public static int dumppo(IntPtr debugClient4, IntPtr args)
        {
            const int DEBUG_VALUE_INT32 = 3;
            UnsafeNativeMethods.DEBUG_VALUE value;
            int cb;
            uint remainder;
            int bufSize = Marshal.SizeOf(typeof(ulong));
            IntPtr buffer = Marshal.AllocHGlobal(bufSize);

            UnsafeNativeMethods.IDebugClient4 client = (UnsafeNativeMethods.IDebugClient4)Marshal.GetTypedObjectForIUnknown(debugClient4, typeof(UnsafeNativeMethods.IDebugClient4));
            string argument = Marshal.PtrToStringAnsi(args);
            UnsafeNativeMethods.IDebugControl control = (UnsafeNativeMethods.IDebugControl)client;
            UnsafeNativeMethods.IDebugDataSpaces dataSpaces = (UnsafeNativeMethods.IDebugDataSpaces)client;

            control.Evaluate(argument, DEBUG_VALUE_INT32, out value, out remainder);
            dataSpaces.ReadVirtual((ulong)value.I32, buffer, bufSize, out cb);
            Console.WriteLine("Example4, PurchaseOrder: Id={0}", Marshal.ReadInt32(buffer));

            Marshal.FreeHGlobal(buffer);
            dataSpaces = null;
            client = null;
            control = null;
            return 0;
        }
    }
}
