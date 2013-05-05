using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using DllExporter;

namespace cfexts
{
    public static partial class ExtensionApis
    {
        const int DEBUG_EXTENSION_MAJOR_VERSION = 1;
        const int DEBUG_EXTENSION_MINOR_VERSION = 0;

        static UnsafeNativeMethods.IDebugControl control;
        static UnsafeNativeMethods.IDebugClient4 client;
        static UnsafeNativeMethods.IDebugOutputCallbacks previousCallback;
        static DebugOutputCallbacks output = new DebugOutputCallbacks();

        public static bool Verbose { get; private set; }

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

        [DllExport]
        public static void DebugExtensionUninitialize()
        {
        }

        [DllExport(EntryPoint = "help")]
        public static int Help(
            IntPtr debugClient4,
            IntPtr args
            )
        {
            using (new InitApi(debugClient4, args))
            {
                try
                {
                    EnsureSOS();
                    dprintf("!dumpsh          - Displays service hosts\n");
                    dprintf("!dumpppd         - Displays persistence provider directory\n");
                    dprintf("!dumpwsi         - Displays workflow service instances\n");
                    dprintf("!dumpar          - Displays async results, -v for verbose\n");
                    dprintf("!setverbose      - Toggle verbose mode\n");
                    dprintf("!help            - Displays this list\n");
                }
                catch (Exception exception)
                {
                    return HandleException(exception);
                }
            }
            return 0;
        }

        [DllExport(EntryPoint = "dumpsh")]
        public static int DumpServiceHosts(
            IntPtr debugClient4,
            IntPtr args
            )
        {
            StringBuilder strb = new StringBuilder();
            using (new InitApi(debugClient4, args))
            {
                try
                {
                    EnsureSOS();
                    List<System_ServiceModel_ServiceHostBase> serviceHosts = System_ServiceModel_ServiceHostBase.DumpServiceHosts();
                    for (int i = 0; i < serviceHosts.Count; ++i)
                    {
                        dprintf("[{0}]\n", i);
                        dprintf(serviceHosts[i].ToString(false));
                        dprintf("\n");
                    }
                    dprintf("Total: {0} hosts.\n", serviceHosts.Count);
                }
                catch (Exception exception)
                {
                    return HandleException(exception);
                }
            }
            return 0;
        }

        [DllExport(EntryPoint = "dumpwsi")]
        public static int DumpWorkflowServiceInstances(
            IntPtr debugClient4,
            IntPtr args
            )
        {
            using (new InitApi(debugClient4, args))
            {
                try
                {
                    EnsureSOS();
                    List<System_ServiceModel_Activities_Dispatcher_WorkflowServiceInstance> wsis = System_ServiceModel_Activities_Dispatcher_WorkflowServiceInstance.DumpWorkflowServiceInstances();
                    int index = 0;
                    for (int i = 0; i < wsis.Count; ++i)
                    {
                        if (IsInterrupt())
                        {
                            break;
                        }

                        if (Arguments.Contains("-v") || wsis[i].WSIState == System_ServiceModel_Activities_Dispatcher_WorkflowServiceInstance.State.Active)
                        {
                            index++;
                            dprintf("[{0}]\n", index);
                            dprintf(wsis[i].ToString(false));
                            dprintf("\n");
                        }
                    }
                    dprintf("Total: {0} instances.\n", index);
                }
                catch (Exception exception)
                {
                    return HandleException(exception);
                }
            }
            return 0;
        }

        [DllExport(EntryPoint = "dumpppd")]
        public static int DumpPersistenceProviderDirectory(
            IntPtr debugClient4,
            IntPtr args
            )
        {
            using (new InitApi(debugClient4, args))
            {
                try
                {
                    EnsureSOS();
                    List<System_ServiceModel_Activities_Dispatcher_PersistenceProviderDirectory> ppds = System_ServiceModel_Activities_Dispatcher_PersistenceProviderDirectory.DumpPPDs();
                    for (int i = 0; i < ppds.Count; ++i)
                    {
                        dprintf("[{0}]\n", i);
                        dprintf(ppds[i].ToString(false));
                        dprintf("\n");
                    }
                    dprintf("Total: {0} ppds.\n", ppds.Count);
                }
                catch (Exception exception)
                {
                    return HandleException(exception);
                }
            }
            return 0;
        }

        [DllExport(EntryPoint = "dumpar")]
        public static int DumpAsyncResult(
            IntPtr debugClient4,
            IntPtr args
            )
        {
            using (new InitApi(debugClient4, args))
            {
                try
                {
                    EnsureSOS();
                    Dictionary<System_Object, List<System_Object>> chain = System_Runtime_AsyncResult.DumpAsyncResults(Arguments.Contains("-v"));
                    int count = 0;
                    foreach (KeyValuePair<System_Object, List<System_Object>> pair in chain)
                    {
                        if (IsInterrupt())
                        {
                            break;
                        }

                        if (pair.Key != pair.Value[0])
                        {
                            continue;
                        }
                        string delimit = String.Empty;
                        for (int i = pair.Value.Count; i > 0; --i)
                        {
                            if (IsInterrupt())
                            {
                                break;
                            }

                            System_Runtime_AsyncResult ar;
                            // For non-Verbose only print notComplete one
                            if (!Arguments.Contains("-v"))
                            {
                                bool notComplete = false;
                                for (int j = pair.Value.Count; j > 0; --j)
                                {
                                    ar = pair.Value[j - 1] as System_Runtime_AsyncResult;
                                    if (ar != null)
                                    {
                                        notComplete = !ar.IsCompleted;
                                        if (!notComplete)
                                        {
                                            break;
                                        }
                                    }
                                }
                                if (!notComplete)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                bool allComplete = true;
                                for (int j = pair.Value.Count; j > 0; --j)
                                {
                                    ar = pair.Value[j - 1] as System_Runtime_AsyncResult;
                                    if (ar != null)
                                    {
                                        allComplete = allComplete && ar.IsCompleted;
                                        if (!allComplete)
                                        {
                                            break;
                                        }
                                    }
                                }
                                if (allComplete)
                                {
                                    break;
                                }
                            }

                            System_Object obj = pair.Value[i - 1];
                            dprintf(String.Format("{0}TypeName:    {1}\n", delimit, obj.TypeName));
                            dprintf(String.Format("{0}Address:     {1}\n", delimit, obj.Address));
                            ar = obj as System_Runtime_AsyncResult;
                            if (ar != null)
                            {
                                dprintf(String.Format("{0}IsCompleted: {1}\n", delimit, ar.IsCompleted));
                                if (ar.IsCompleted)
                                {
                                    dprintf(String.Format("{0}CompletedSyn:{1}\n", delimit, ar.CompletedSynchronously));
                                    dprintf(String.Format("{0}Exception:   {1}\n", delimit, ar.Exception.Value));
                                }
                                ++count;
                            }
                            delimit += "    ";
                        }
                    }
                    dprintf("Total: {0} async results.\n", count);
                }
                catch (Exception exception)
                {
                    return HandleException(exception);
                }
            }
            return 0;
        }

        [DllExport(EntryPoint = "dumpmt_")]
        public static int DumpMT_(
            IntPtr debugClient4,
            IntPtr args
            )
        {
            using (new InitApi(debugClient4, args))
            {
                try
                {
                    EnsureSOS();
                    EEMethodTable mt = EEMethodTable.Dump(Arguments.Items[0]);
                    dprintf(mt);
                }
                catch (Exception exception)
                {
                    return HandleException(exception);
                }
            }
            return 0;
        }

        [DllExport(EntryPoint = "dumpclass_")]
        public static int DumpClass_(
            IntPtr debugClient4,
            IntPtr args
            )
        {
            using (new InitApi(debugClient4, args))
            {
                try
                {
                    EnsureSOS();
                    EEClass cl = EEClass.Dump(Arguments.Items[0]);
                    dprintf(cl);
                }
                catch (Exception exception)
                {
                    return HandleException(exception);
                }
            }
            return 0;
        }

        [DllExport(EntryPoint = "dumpheap_")]
        public static int DumpHeap_(
            IntPtr debugClient4,
            IntPtr args
            )
        {
            using (new InitApi(debugClient4, args))
            {
                try
                {
                    EnsureSOS();
                    EEHeap heap = EEHeap.Dump(Arguments.Raw);
                    dprintf(heap);
                }
                catch (Exception exception)
                {
                    return HandleException(exception);
                }
            }
            return 0;
        }

        [DllExport(EntryPoint = "dos_")]
        public static int DumpObjs_(
            IntPtr debugClient4,
            IntPtr args
            )
        {
            using (new InitApi(debugClient4, args))
            {
                try
                {
                    EnsureSOS();
                    EEHeap heap = EEHeap.Dump(Arguments.Raw);
                    foreach (KeyValuePair<string, List<string>> pair in heap.Objects)
                    {
                        dprintf(EEMethodTable.Dump(pair.Key));
                        foreach (string obj in pair.Value)
                        {
                            dprintf(System_Object.Dump(obj).ToString(false));
                        }
                    }
                }
                catch (Exception exception)
                {
                    return HandleException(exception);
                }
            }
            return 0;
        }

        [DllExport(EntryPoint = "do_")]
        public static int DumpObj_(
            IntPtr debugClient4,
            IntPtr args
            )
        {
            using (new InitApi(debugClient4, args))
            {
                try
                {
                    EnsureSOS();
                    System_Object obj = System_Object.Dump(Arguments.Items[0]);
                    for (int i = 1; i < Arguments.Items.Length; ++i)
                    {
                        obj = obj.Fields[Arguments.Items[i]].ToObject();
                    }
                    dprintf(obj.ToString(false));
                }
                catch (Exception exception)
                {
                    return HandleException(exception);
                }
            }
            return 0;
        }

        [DllExport(EntryPoint = "setverbose")]
        public static int SetVerbose(
            IntPtr debugClient4,
            IntPtr args
            )
        {
            using (new InitApi(debugClient4, args))
            {
                Verbose = !Verbose;
                dprintf("verbose is {0}\n", Verbose ? "on" : "off");
            }
            return 0;
        }

        static void EnsureSOS()
        {
            try
            {
                sos_threads();
                return;
            }
            catch (Exception)
            {
                loadby_sos_clr();
                sos_threads();
            }
        }

        public static void IfFailThrow(int hr)
        {
            if (hr < 0)
            {
                throw new ExecutionException(hr);
            }
        }

        public static int HandleException(Exception exception)
        {
            ExecutionException ex = exception as ExecutionException;
            if (ex != null)
            {
                dprintf(ex + "\n");
                return ex.HRESULT;
            }

            COMException com = exception as COMException;
            if (com != null)
            {
                if (com.ErrorCode != UnsafeNativeMethods.E_USER_INTERRUPT)
                {
                    dprintf(com + "\n");
                }
                return com.ErrorCode;
            }

            dprintf(exception + "\n");
            return UnsafeNativeMethods.E_FAIL;
        }

        static void dprintf(string format, params object[] args)
        {
            dprintf(String.Format(format, args));
        }

        static void dprintf(string format, object arg0)
        {
            dprintf(String.Format(format, arg0));
        }

        static void dprintf(object obj)
        {
            dprintf("{0}", obj);
        }

        static void dprintf(string text)
        {
            control.Output(UnsafeNativeMethods.OutputControl.Default, text);
        }

        public static bool IsInterrupt()
        {
            int hr = control.GetInterrupt();
            ExtensionApis.IfFailThrow(hr);
            if (hr == 0)
            {
                dprintf("Ctrl-C requested by user!\n");
            }
            return hr == 0;
        }

        public class ExecutionException : Exception
        {
            int hr;
            
            public ExecutionException(int hr)
            {
                this.hr = hr;
            }

            public int HRESULT
            {
                get { return this.hr; }
            }

            public override string ToString()
            {
                return String.Format("hr={0}, {1}", this.hr, base.ToString());
            }
        }

        public class NotLoadedYetException : Exception
        {
        }

        public class InitApi : IDisposable
        {
            public InitApi(IntPtr debugClient4, IntPtr args)
            {
                // Do own Marshalling work for both 32/64 bits
                client = (UnsafeNativeMethods.IDebugClient4)Marshal.GetTypedObjectForIUnknown(debugClient4, typeof(UnsafeNativeMethods.IDebugClient4));
                Arguments.Init(Marshal.PtrToStringAnsi(args));
                control = (UnsafeNativeMethods.IDebugControl)client;

                client.GetOutputCallbacks(out previousCallback);
                output.SetOutput(null);
                client.SetOutputCallbacks(output);
            }

            public void Dispose()
            {
                // Restore output callback
                client.SetOutputCallbacks(previousCallback);
                output.SetOutput(null);

                client = null;
                Arguments.Clear();
                control = null;
            }

        }

        public class DebugOutputCallbacks : UnsafeNativeMethods.IDebugOutputCallbacks
        {
            StreamWriter stream;

            public void SetOutput(StreamWriter stream)
            {
                this.stream = stream;
            }

            public void Output(UnsafeNativeMethods.OutputModes mask, string text)
            {
                if (Verbose || mask == UnsafeNativeMethods.OutputModes.Default)
                {
                    Console.Write(text);
                }
                if (this.stream != null && mask == UnsafeNativeMethods.OutputModes.Normal) 
                {
                    this.stream.Write(text);
                }
            }
        }
    }
}
