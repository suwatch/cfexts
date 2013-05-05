using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Versioning;

namespace CsExts
{
    [SuppressUnmanagedCodeSecurity]
    public static class UnsafeNativeMethods
    {
        internal static readonly int E_FAIL = unchecked((int)0x80040005);
        internal static readonly int E_USER_INTERRUPT = unchecked((int)0xD000013A);

        //[SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue"), SuppressMessage("Microsoft.Naming", "CA1714:FlagsEnumsShouldHavePluralNames"), Flags, SuppressMessage("Microsoft.Usage", "CA2217:DoNotMarkEnumsWithFlags")]
        [Flags]
        public enum OutputControl : int
        {
            Ambient = -1,
            AmbientDml = -2,
            AmbientText = -1,
            Dml = 0x20,
            Ignore = 3,
            LogOnly = 4,
            NotLogged = 8,
            Override = 0x10,
            SendMask = 7,
            ToAllClients = 1,
            ToAllOtherClients = 2,
            ToThisClient = 0,
            Default = ToAllClients | NotLogged | Override,
        }

        //[SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue"), Flags]
        [Flags]
        public enum ExecuteOptions : int
        {
            Default = 0,
            Echo = 1,
            NoRepeat = 4,
            NotLogged = 2
        }

        [Flags]
        public enum OutputModes : int
        {
            BreakpointOutput = 0x20000000,
            Debuggee = 0x80,
            DebuggeePrompt = 0x100,
            Error = 2,
            EventOutput = 0x10000000,
            ExtensionWarning = 0x40,
            KdProtocolOutput = -2147483648,
            Normal = 1,
            Prompt = 0x10,
            PromptRegisters = 0x20,
            RemotingOutput = 0x40000000,
            Symbols = 0x200,
            Verbose = 8,
            Warning = 4,
            Default = Normal | Verbose | Prompt,
        } 

        [StructLayout(LayoutKind.Explicit, Size=0x20)]
        public struct DEBUG_VALUE
        {
            [FieldOffset(0)]
            public int I32;
        } 

        [Guid("ca83c3de-5089-4cf8-93c8-d892387f2a5e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComImport, SuppressUnmanagedCodeSecurity]
        public interface IDebugClient4
        {
            [Obsolete("not used", true)]
            void AttachKernel();
            [Obsolete("not used", true)]
            void GetKernelConnectionOptions();
            [Obsolete("not used", true)]
            void SetKernelConnectionOptions();
            [Obsolete("not used", true)]
            void StartProcessServer();
            [Obsolete("not used", true)]
            void ConnectProcessServer();
            [Obsolete("not used", true)]
            void DisconnectProcessServer();
            [Obsolete("not used", true)]
            void GetRunningProcessSystemIds();
            [Obsolete("not used", true)]
            void GetRunningProcessSystemIdByExecutableName();
            [Obsolete("not used", true)]
            void GetRunningProcessDescription();
            [Obsolete("not used", true)]
            void AttachProcess();
            [Obsolete("not used", true)]
            void CreateProcess();
            [Obsolete("not used", true)]
            void CreateProcessAndAttach();
            [Obsolete("not used", true)]
            void GetProcessOptions();
            [Obsolete("not used", true)]
            void AddProcessOptions();
            [Obsolete("not used", true)]
            void RemoveProcessOptions();
            [Obsolete("not used", true)]
            void SetProcessOptions();
            [Obsolete("not used", true)]
            void OpenDumpFile();
            [Obsolete("not used", true)]
            void WriteDumpFile();
            [Obsolete("not used", true)]
            void ConnectSession();
            [Obsolete("not used", true)]
            void StartServer();
            [Obsolete("not used", true)]
            void OutputServers();
            [Obsolete("not used", true)]
            void TerminateProcesses();
            [Obsolete("not used", true)]
            void DetachProcesses();
            [Obsolete("not used", true)]
            void EndSession();
            [Obsolete("not used", true)]
            void GetExitCode();
            [Obsolete("not used", true)]
            void DispatchCallbacks();
            [Obsolete("not used", true)]
            void ExitDispatch();
            [Obsolete("not used", true)]
            void CreateClient();
            [Obsolete("not used", true)]
            void GetInputCallbacks();
            [Obsolete("not used", true)]
            void SetInputCallbacks();

            void GetOutputCallbacks(
                out UnsafeNativeMethods.IDebugOutputCallbacks callback
                );

            void SetOutputCallbacks(
                UnsafeNativeMethods.IDebugOutputCallbacks callback
                );

            [Obsolete("not used", true)]
            void GetOutputMask();
            [Obsolete("not used", true)]
            void SetOutputMask();
            [Obsolete("not used", true)]
            void GetOtherOutputMask();
            [Obsolete("not used", true)]
            void SetOtherOutputMask();
            [Obsolete("not used", true)]
            void GetOutputWidth();
            [Obsolete("not used", true)]
            void SetOutputWidth();
            [Obsolete("not used", true)]
            void GetOutputLinePrefix();
            [Obsolete("not used", true)]
            void SetOutputLinePrefix();
            [Obsolete("not used", true)]
            void GetIdentity();
            [Obsolete("not used", true)]
            void OutputIdentity();
            [Obsolete("not used", true)]
            void GetEventCallbacks();
            [Obsolete("not used", true)]
            void SetEventCallbacks();
            [Obsolete("not used", true)]
            void FlushCallbacks();
            [Obsolete("not used", true)]
            void WriteDumpFile2();
            [Obsolete("not used", true)]
            void AddDumpInformationFile();
            [Obsolete("not used", true)]
            void EndProcessServer();
            [Obsolete("not used", true)]
            void WaitForProcessServerEnd();
            [Obsolete("not used", true)]
            void IsKernelDebuggerEnabled();
            [Obsolete("not used", true)]
            void TerminateCurrentProcess();
            [Obsolete("not used", true)]
            void DetachCurrentProcess();
            [Obsolete("not used", true)]
            void AbandonCurrentProcess();
            [Obsolete("not used", true)]
            void GetRunningProcessSystemIdByExecutableNameWide();
            [Obsolete("not used", true)]
            void GetRunningProcessDescriptionWide();
            [Obsolete("not used", true)]
            void CreateProcessWide();
            [Obsolete("not used", true)]
            void CreateProcessAndAttachWide();
            [Obsolete("not used", true)]
            void OpenDumpFileWide();
            [Obsolete("not used", true)]
            void WriteDumpFileWide();
            [Obsolete("not used", true)]
            void AddDumpInformationFileWide();
            [Obsolete("not used", true)]
            void GetNumberDumpFiles();
            [Obsolete("not used", true)]
            void GetDumpFile();
            [Obsolete("not used", true)]
            void GetDumpFileWide();
        }

        [Guid("5182e668-105e-416e-ad92-24ef800424ba"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComImport, SuppressUnmanagedCodeSecurity]
        public interface IDebugControl
        {
            [PreserveSig]
            int GetInterrupt();

            [Obsolete("not used", true)]
            void SetInterrupt();
            [Obsolete("not used", true)]
            void GetInterruptTimeout();
            [Obsolete("not used", true)]
            void SetInterruptTimeout();
            [Obsolete("not used", true)]
            void GetLogFile();
            [Obsolete("not used", true)]
            void OpenLogFile();
            [Obsolete("not used", true)]
            void CloseLogFile();
            [Obsolete("not used", true)]
            void GetLogMask();
            [Obsolete("not used", true)]
            void SetLogMask();
            [Obsolete("not used", true)]
            void Input();
            [Obsolete("not used", true)]
            void ReturnInput();

            void Output(
                OutputControl ctls,
                [MarshalAs(UnmanagedType.LPStr)]
                string text
                );

            [Obsolete("not used", true)]
            void OutputVaList();
            [Obsolete("not used", true)]
            void ControlledOutput();
            [Obsolete("not used", true)]
            void ControlledOutputVaList();
            [Obsolete("not used", true)]
            void OutputPrompt();
            [Obsolete("not used", true)]
            void OutputPromptVaList();
            [Obsolete("not used", true)]
            void GetPromptText();
            [Obsolete("not used", true)]
            void OutputCurrentState();
            [Obsolete("not used", true)]
            void OutputVersionInformation();
            [Obsolete("not used", true)]
            void GetNotifyEventHandle();
            [Obsolete("not used", true)]
            void SetNotifyEventHandle();
            [Obsolete("not used", true)]
            void Assemble();
            [Obsolete("not used", true)]
            void Disassemble();
            [Obsolete("not used", true)]
            void GetDisassembleEffectiveOffset();
            [Obsolete("not used", true)]
            void OutputDisassembly();
            [Obsolete("not used", true)]
            void OutputDisassemblyLines();
            [Obsolete("not used", true)]
            void GetNearInstruction();
            [Obsolete("not used", true)]
            void GetStackTrace();
            [Obsolete("not used", true)]
            void GetReturnOffset();
            [Obsolete("not used", true)]
            void OutputStackTrace();
            [Obsolete("not used", true)]
            void GetDebuggeeType();
            [Obsolete("not used", true)]
            void GetActualProcessorType();
            [Obsolete("not used", true)]
            void GetExecutingProcessorType();
            [Obsolete("not used", true)]
            void GetNumberPossibleExecutingProcessorTypes();
            [Obsolete("not used", true)]
            void GetPossibleExecutingProcessorTypes();
            [Obsolete("not used", true)]
            void GetNumberProcessors();
            [Obsolete("not used", true)]
            void GetSystemVersion();
            [Obsolete("not used", true)]
            void GetPageSize();
            [Obsolete("not used", true)]
            void IsPointer64Bit();
            [Obsolete("not used", true)]
            void ReadBugCheckData();
            [Obsolete("not used", true)]
            void GetNumberSupportedProcessorTypes();
            [Obsolete("not used", true)]
            void GetSupportedProcessorTypes();
            [Obsolete("not used", true)]
            void GetProcessorTypeNames();
            [Obsolete("not used", true)]
            void GetEffectiveProcessorType();
            [Obsolete("not used", true)]
            void SetEffectiveProcessorType();
            [Obsolete("not used", true)]
            void GetExecutionStatus();
            [Obsolete("not used", true)]
            void SetExecutionStatus();
            [Obsolete("not used", true)]
            void GetCodeLevel();
            [Obsolete("not used", true)]
            void SetCodeLevel();
            [Obsolete("not used", true)]
            void GetEngineOptions();
            [Obsolete("not used", true)]
            void AddEngineOptions();
            [Obsolete("not used", true)]
            void RemoveEngineOptions();
            [Obsolete("not used", true)]
            void SetEngineOptions();
            [Obsolete("not used", true)]
            void GetSystemErrorControl();
            [Obsolete("not used", true)]
            void SetSystemErrorControl();
            [Obsolete("not used", true)]
            void GetTextMacro();
            [Obsolete("not used", true)]
            void SetTextMacro();
            [Obsolete("not used", true)]
            void GetRadix();
            [Obsolete("not used", true)]
            void SetRadix();

            void Evaluate(
                [MarshalAs(UnmanagedType.LPStr)]
                string expression,
                int desiredType,
                out DEBUG_VALUE value,
                out uint remainder
                );

            
            [Obsolete("not used", true)]
            void CoerceValue();
            [Obsolete("not used", true)]
            void CoerceValues();
            
            void Execute(
                OutputControl ctls, 
                [MarshalAs(UnmanagedType.LPStr)]
                string command, 
                ExecuteOptions opts
                );
            
            [Obsolete("not used", true)]
            void ExecuteCommandFile();
            [Obsolete("not used", true)]
            void GetNumberBreakpoints();
            [Obsolete("not used", true)]
            void GetBreakpointByIndex();
            [Obsolete("not used", true)]
            void GetBreakpointById();
            [Obsolete("not used", true)]
            void GetBreakpointParameters();
            [Obsolete("not used", true)]
            void AddBreakpoint();
            [Obsolete("not used", true)]
            void RemoveBreakpoint();
            [Obsolete("not used", true)]
            void AddExtension();
            [Obsolete("not used", true)]
            void RemoveExtension();
            [Obsolete("not used", true)]
            void GetExtensionByPath();
            [Obsolete("not used", true)]
            void CallExtension();
            [Obsolete("not used", true)]
            void GetExtensionFunction();
            [Obsolete("not used", true)]
            void GetWindbgExtensionApis32();
            [Obsolete("not used", true)]
            void GetWindbgExtensionApis64();
            [Obsolete("not used", true)]
            void GetNumberEventFilters();
            [Obsolete("not used", true)]
            void GetEventFilterText();
            [Obsolete("not used", true)]
            void GetEventFilterCommand();
            [Obsolete("not used", true)]
            void SetEventFilterCommand();
            [Obsolete("not used", true)]
            void GetSpecificFilterParameters();
            [Obsolete("not used", true)]
            void SetSpecificFilterParameters();
            [Obsolete("not used", true)]
            void GetSpecificFilterArgument();
            [Obsolete("not used", true)]
            void SetSpecificFilterArgument();
            [Obsolete("not used", true)]
            void GetExceptionFilterParameters();
            [Obsolete("not used", true)]
            void SetExceptionFilterParameters();
            [Obsolete("not used", true)]
            void GetExceptionFilterSecondCommand();
            [Obsolete("not used", true)]
            void SetExceptionFilterSecondCommand();
            [Obsolete("not used", true)]
            void WaitForEvent();
            [Obsolete("not used", true)]
            void GetLastEventInformation();
        }

        [Guid("4bf58045-d654-4c40-b0af-683090f356dc"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComImport, SuppressUnmanagedCodeSecurity]
        public interface IDebugOutputCallbacks
        {
            void Output(
                OutputModes mask,
                [MarshalAs(UnmanagedType.LPStr)]
                string text
                );
        }

        [Guid("88f7dfab-3ea7-4c3a-aefb-c4e8106173aa"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComImport, SuppressUnmanagedCodeSecurity]
        public interface IDebugDataSpaces
        {
            //void ReadVirtual(ulong offset, ref ulong buffer, uint bufferSize, out uint bytesRead);
            void ReadVirtual(ulong offset, IntPtr buffer, int bufferSize, out int bytesRead);
            [Obsolete("not used", true)]
            void WriteVirtual();
            [Obsolete("not used", true)]
            void SearchVirtual();
            [Obsolete("not used", true)]
            void ReadVirtualUncached();
            [Obsolete("not used", true)]
            void WriteVirtualUncached();
            [Obsolete("not used", true)]
            void ReadPointersVirtual();
            [Obsolete("not used", true)]
            void WritePointersVirtual();
            [Obsolete("not used", true)]
            void ReadPhysical();
            [Obsolete("not used", true)]
            void WritePhysical();
            [Obsolete("not used", true)]
            void ReadControl();
            [Obsolete("not used", true)]
            void WriteControl();
            [Obsolete("not used", true)]
            void ReadIo();
            [Obsolete("not used", true)]
            void WriteIo();
            [Obsolete("not used", true)]
            void ReadMsr();
            [Obsolete("not used", true)]
            void WriteMsr();
            [Obsolete("not used", true)]
            void ReadBusData();
            [Obsolete("not used", true)]
            void WriteBusData();
            [Obsolete("not used", true)]
            void CheckLowMemory();
            [Obsolete("not used", true)]
            void ReadDebuggerData();
            [Obsolete("not used", true)]
            void ReadProcessorSystemData();
        }
    }
}
