using System;
using System.Collections.Generic;
using System.Text;
using DllExporter;
using System.Runtime.InteropServices;

namespace CsExts
{
    public static partial class CsExts
    {
        const int DEBUG_EXTENSION_MAJOR_VERSION = 1;
        const int DEBUG_EXTENSION_MINOR_VERSION = 0;

        [DllExport]
        public static int DebugExtensionInitialize(
            out int Version,
            out int Flags
            )
        {
            Version = ((((DEBUG_EXTENSION_MAJOR_VERSION) & 0xffff) << 16) | ((DEBUG_EXTENSION_MINOR_VERSION) & 0xffff));
            Flags = 0;
            return 0;
        }
    }
}
