
//  Microsoft (R) .NET Framework IL Disassembler.  Version 3.5.30729.1
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v2.0.50727
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 2:0:0:0
}
.assembly csexts
{
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 27 43 6F 70 79 72 69 67 68 74 20 C2 A9 20   // ..'Copyright .. 
                                                                                                  4D 69 63 72 6F 73 6F 66 74 20 43 6F 72 70 6F 72   // Microsoft Corpor
                                                                                                  61 74 69 6F 6E 20 32 30 30 39 00 00 )             // ation 2009..
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 06 63 73 65 78 74 73 00 00 )                // ...csexts..

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 15 4D 69 63 72 6F 73 6F 66 74 20 43 6F 72   // ...Microsoft Cor
                                                                                                70 6F 72 61 74 69 6F 6E 00 00 )                   // poration..
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 64 37 30 37 63 37 30 61 2D 38 65 62 33   // ..$d707c70a-8eb3
                                                                                                  2D 34 65 64 65 2D 61 36 34 31 2D 38 35 36 32 66   // -4ede-a641-8562f
                                                                                                  33 38 39 65 30 38 62 00 00 )                      // 389e08b..
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 06 63 73 65 78 74 73 00 00 )                // ...csexts..
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module csexts.dll
// MVID: {4A5AEFA4-802C-4531-BC39-BA849EC10EF9}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00350000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed beforefieldinit CsExts.UnsafeNativeMethods
       extends [mscorlib]System.Object
{
  .custom instance void [mscorlib]System.Security.SuppressUnmanagedCodeSecurityAttribute::.ctor() = ( 01 00 00 00 ) 
  .class auto ansi sealed nested public OutputControl
         extends [mscorlib]System.Enum
  {
    .custom instance void [mscorlib]System.FlagsAttribute::.ctor() = ( 01 00 00 00 ) 
    .field public specialname rtspecialname int32 value__
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputControl Ambient = int32(0xFFFFFFFF)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputControl AmbientDml = int32(0xFFFFFFFE)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputControl AmbientText = int32(0xFFFFFFFF)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputControl Dml = int32(0x00000020)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputControl Ignore = int32(0x00000003)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputControl LogOnly = int32(0x00000004)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputControl NotLogged = int32(0x00000008)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputControl Override = int32(0x00000010)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputControl SendMask = int32(0x00000007)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputControl ToAllClients = int32(0x00000001)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputControl ToAllOtherClients = int32(0x00000002)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputControl ToThisClient = int32(0x00000000)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputControl Default = int32(0x00000019)
  } // end of class OutputControl

  .class auto ansi sealed nested public ExecuteOptions
         extends [mscorlib]System.Enum
  {
    .custom instance void [mscorlib]System.FlagsAttribute::.ctor() = ( 01 00 00 00 ) 
    .field public specialname rtspecialname int32 value__
    .field public static literal valuetype CsExts.UnsafeNativeMethods/ExecuteOptions Default = int32(0x00000000)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/ExecuteOptions Echo = int32(0x00000001)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/ExecuteOptions NoRepeat = int32(0x00000004)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/ExecuteOptions NotLogged = int32(0x00000002)
  } // end of class ExecuteOptions

  .class auto ansi sealed nested public OutputModes
         extends [mscorlib]System.Enum
  {
    .custom instance void [mscorlib]System.FlagsAttribute::.ctor() = ( 01 00 00 00 ) 
    .field public specialname rtspecialname int32 value__
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputModes BreakpointOutput = int32(0x20000000)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputModes Debuggee = int32(0x00000080)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputModes DebuggeePrompt = int32(0x00000100)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputModes Error = int32(0x00000002)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputModes EventOutput = int32(0x10000000)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputModes ExtensionWarning = int32(0x00000040)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputModes KdProtocolOutput = int32(0x80000000)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputModes Normal = int32(0x00000001)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputModes Prompt = int32(0x00000010)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputModes PromptRegisters = int32(0x00000020)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputModes RemotingOutput = int32(0x40000000)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputModes Symbols = int32(0x00000200)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputModes Verbose = int32(0x00000008)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputModes Warning = int32(0x00000004)
    .field public static literal valuetype CsExts.UnsafeNativeMethods/OutputModes Default = int32(0x00000019)
  } // end of class OutputModes

  .class explicit ansi sealed nested public beforefieldinit DEBUG_VALUE
         extends [mscorlib]System.ValueType
  {
    .pack 0
    .size 32
    .field [0] public int32 I32
  } // end of class DEBUG_VALUE

  .class interface abstract auto ansi import nested public IDebugClient4
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ComInterfaceType) = ( 01 00 01 00 00 00 00 00 ) 
    .custom instance void [mscorlib]System.Security.SuppressUnmanagedCodeSecurityAttribute::.ctor() = ( 01 00 00 00 ) 
    .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 63 61 38 33 63 33 64 65 2D 35 30 38 39   // ..$ca83c3de-5089
                                                                                                    2D 34 63 66 38 2D 39 33 63 38 2D 64 38 39 32 33   // -4cf8-93c8-d8923
                                                                                                    38 37 66 32 61 35 65 00 00 )                      // 87f2a5e..
    .method public hidebysig newslot abstract virtual 
            instance void  AttachKernel() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::AttachKernel

    .method public hidebysig newslot abstract virtual 
            instance void  GetKernelConnectionOptions() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::GetKernelConnectionOptions

    .method public hidebysig newslot abstract virtual 
            instance void  SetKernelConnectionOptions() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::SetKernelConnectionOptions

    .method public hidebysig newslot abstract virtual 
            instance void  StartProcessServer() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::StartProcessServer

    .method public hidebysig newslot abstract virtual 
            instance void  ConnectProcessServer() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::ConnectProcessServer

    .method public hidebysig newslot abstract virtual 
            instance void  DisconnectProcessServer() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::DisconnectProcessServer

    .method public hidebysig newslot abstract virtual 
            instance void  GetRunningProcessSystemIds() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::GetRunningProcessSystemIds

    .method public hidebysig newslot abstract virtual 
            instance void  GetRunningProcessSystemIdByExecutableName() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::GetRunningProcessSystemIdByExecutableName

    .method public hidebysig newslot abstract virtual 
            instance void  GetRunningProcessDescription() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::GetRunningProcessDescription

    .method public hidebysig newslot abstract virtual 
            instance void  AttachProcess() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::AttachProcess

    .method public hidebysig newslot abstract virtual 
            instance void  CreateProcess() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::CreateProcess

    .method public hidebysig newslot abstract virtual 
            instance void  CreateProcessAndAttach() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::CreateProcessAndAttach

    .method public hidebysig newslot abstract virtual 
            instance void  GetProcessOptions() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::GetProcessOptions

    .method public hidebysig newslot abstract virtual 
            instance void  AddProcessOptions() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::AddProcessOptions

    .method public hidebysig newslot abstract virtual 
            instance void  RemoveProcessOptions() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::RemoveProcessOptions

    .method public hidebysig newslot abstract virtual 
            instance void  SetProcessOptions() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::SetProcessOptions

    .method public hidebysig newslot abstract virtual 
            instance void  OpenDumpFile() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::OpenDumpFile

    .method public hidebysig newslot abstract virtual 
            instance void  WriteDumpFile() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::WriteDumpFile

    .method public hidebysig newslot abstract virtual 
            instance void  ConnectSession() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::ConnectSession

    .method public hidebysig newslot abstract virtual 
            instance void  StartServer() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::StartServer

    .method public hidebysig newslot abstract virtual 
            instance void  OutputServers() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::OutputServers

    .method public hidebysig newslot abstract virtual 
            instance void  TerminateProcesses() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::TerminateProcesses

    .method public hidebysig newslot abstract virtual 
            instance void  DetachProcesses() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::DetachProcesses

    .method public hidebysig newslot abstract virtual 
            instance void  EndSession() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::EndSession

    .method public hidebysig newslot abstract virtual 
            instance void  GetExitCode() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::GetExitCode

    .method public hidebysig newslot abstract virtual 
            instance void  DispatchCallbacks() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::DispatchCallbacks

    .method public hidebysig newslot abstract virtual 
            instance void  ExitDispatch() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::ExitDispatch

    .method public hidebysig newslot abstract virtual 
            instance void  CreateClient() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::CreateClient

    .method public hidebysig newslot abstract virtual 
            instance void  GetInputCallbacks() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::GetInputCallbacks

    .method public hidebysig newslot abstract virtual 
            instance void  SetInputCallbacks() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::SetInputCallbacks

    .method public hidebysig newslot abstract virtual 
            instance void  GetOutputCallbacks([out] class CsExts.UnsafeNativeMethods/IDebugOutputCallbacks& callback) cil managed
    {
    } // end of method IDebugClient4::GetOutputCallbacks

    .method public hidebysig newslot abstract virtual 
            instance void  SetOutputCallbacks(class CsExts.UnsafeNativeMethods/IDebugOutputCallbacks callback) cil managed
    {
    } // end of method IDebugClient4::SetOutputCallbacks

    .method public hidebysig newslot abstract virtual 
            instance void  GetOutputMask() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::GetOutputMask

    .method public hidebysig newslot abstract virtual 
            instance void  SetOutputMask() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::SetOutputMask

    .method public hidebysig newslot abstract virtual 
            instance void  GetOtherOutputMask() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::GetOtherOutputMask

    .method public hidebysig newslot abstract virtual 
            instance void  SetOtherOutputMask() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::SetOtherOutputMask

    .method public hidebysig newslot abstract virtual 
            instance void  GetOutputWidth() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::GetOutputWidth

    .method public hidebysig newslot abstract virtual 
            instance void  SetOutputWidth() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::SetOutputWidth

    .method public hidebysig newslot abstract virtual 
            instance void  GetOutputLinePrefix() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::GetOutputLinePrefix

    .method public hidebysig newslot abstract virtual 
            instance void  SetOutputLinePrefix() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::SetOutputLinePrefix

    .method public hidebysig newslot abstract virtual 
            instance void  GetIdentity() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::GetIdentity

    .method public hidebysig newslot abstract virtual 
            instance void  OutputIdentity() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::OutputIdentity

    .method public hidebysig newslot abstract virtual 
            instance void  GetEventCallbacks() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::GetEventCallbacks

    .method public hidebysig newslot abstract virtual 
            instance void  SetEventCallbacks() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::SetEventCallbacks

    .method public hidebysig newslot abstract virtual 
            instance void  FlushCallbacks() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::FlushCallbacks

    .method public hidebysig newslot abstract virtual 
            instance void  WriteDumpFile2() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::WriteDumpFile2

    .method public hidebysig newslot abstract virtual 
            instance void  AddDumpInformationFile() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::AddDumpInformationFile

    .method public hidebysig newslot abstract virtual 
            instance void  EndProcessServer() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::EndProcessServer

    .method public hidebysig newslot abstract virtual 
            instance void  WaitForProcessServerEnd() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::WaitForProcessServerEnd

    .method public hidebysig newslot abstract virtual 
            instance void  IsKernelDebuggerEnabled() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::IsKernelDebuggerEnabled

    .method public hidebysig newslot abstract virtual 
            instance void  TerminateCurrentProcess() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::TerminateCurrentProcess

    .method public hidebysig newslot abstract virtual 
            instance void  DetachCurrentProcess() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::DetachCurrentProcess

    .method public hidebysig newslot abstract virtual 
            instance void  AbandonCurrentProcess() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::AbandonCurrentProcess

    .method public hidebysig newslot abstract virtual 
            instance void  GetRunningProcessSystemIdByExecutableNameWide() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::GetRunningProcessSystemIdByExecutableNameWide

    .method public hidebysig newslot abstract virtual 
            instance void  GetRunningProcessDescriptionWide() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::GetRunningProcessDescriptionWide

    .method public hidebysig newslot abstract virtual 
            instance void  CreateProcessWide() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::CreateProcessWide

    .method public hidebysig newslot abstract virtual 
            instance void  CreateProcessAndAttachWide() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::CreateProcessAndAttachWide

    .method public hidebysig newslot abstract virtual 
            instance void  OpenDumpFileWide() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::OpenDumpFileWide

    .method public hidebysig newslot abstract virtual 
            instance void  WriteDumpFileWide() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::WriteDumpFileWide

    .method public hidebysig newslot abstract virtual 
            instance void  AddDumpInformationFileWide() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::AddDumpInformationFileWide

    .method public hidebysig newslot abstract virtual 
            instance void  GetNumberDumpFiles() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::GetNumberDumpFiles

    .method public hidebysig newslot abstract virtual 
            instance void  GetDumpFile() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::GetDumpFile

    .method public hidebysig newslot abstract virtual 
            instance void  GetDumpFileWide() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugClient4::GetDumpFileWide

  } // end of class IDebugClient4

  .class interface abstract auto ansi import nested public IDebugControl
  {
    .custom instance void [mscorlib]System.Security.SuppressUnmanagedCodeSecurityAttribute::.ctor() = ( 01 00 00 00 ) 
    .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ComInterfaceType) = ( 01 00 01 00 00 00 00 00 ) 
    .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 35 31 38 32 65 36 36 38 2D 31 30 35 65   // ..$5182e668-105e
                                                                                                    2D 34 31 36 65 2D 61 64 39 32 2D 32 34 65 66 38   // -416e-ad92-24ef8
                                                                                                    30 30 34 32 34 62 61 00 00 )                      // 00424ba..
    .method public hidebysig newslot abstract virtual 
            instance int32  GetInterrupt() cil managed preservesig
    {
    } // end of method IDebugControl::GetInterrupt

    .method public hidebysig newslot abstract virtual 
            instance void  SetInterrupt() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::SetInterrupt

    .method public hidebysig newslot abstract virtual 
            instance void  GetInterruptTimeout() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetInterruptTimeout

    .method public hidebysig newslot abstract virtual 
            instance void  SetInterruptTimeout() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::SetInterruptTimeout

    .method public hidebysig newslot abstract virtual 
            instance void  GetLogFile() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetLogFile

    .method public hidebysig newslot abstract virtual 
            instance void  OpenLogFile() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::OpenLogFile

    .method public hidebysig newslot abstract virtual 
            instance void  CloseLogFile() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::CloseLogFile

    .method public hidebysig newslot abstract virtual 
            instance void  GetLogMask() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetLogMask

    .method public hidebysig newslot abstract virtual 
            instance void  SetLogMask() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::SetLogMask

    .method public hidebysig newslot abstract virtual 
            instance void  Input() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::Input

    .method public hidebysig newslot abstract virtual 
            instance void  ReturnInput() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::ReturnInput

    .method public hidebysig newslot abstract virtual 
            instance void  Output(valuetype CsExts.UnsafeNativeMethods/OutputControl ctls,
                                  string  marshal( lpstr) text) cil managed
    {
    } // end of method IDebugControl::Output

    .method public hidebysig newslot abstract virtual 
            instance void  OutputVaList() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::OutputVaList

    .method public hidebysig newslot abstract virtual 
            instance void  ControlledOutput() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::ControlledOutput

    .method public hidebysig newslot abstract virtual 
            instance void  ControlledOutputVaList() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::ControlledOutputVaList

    .method public hidebysig newslot abstract virtual 
            instance void  OutputPrompt() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::OutputPrompt

    .method public hidebysig newslot abstract virtual 
            instance void  OutputPromptVaList() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::OutputPromptVaList

    .method public hidebysig newslot abstract virtual 
            instance void  GetPromptText() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetPromptText

    .method public hidebysig newslot abstract virtual 
            instance void  OutputCurrentState() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::OutputCurrentState

    .method public hidebysig newslot abstract virtual 
            instance void  OutputVersionInformation() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::OutputVersionInformation

    .method public hidebysig newslot abstract virtual 
            instance void  GetNotifyEventHandle() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetNotifyEventHandle

    .method public hidebysig newslot abstract virtual 
            instance void  SetNotifyEventHandle() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::SetNotifyEventHandle

    .method public hidebysig newslot abstract virtual 
            instance void  Assemble() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::Assemble

    .method public hidebysig newslot abstract virtual 
            instance void  Disassemble() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::Disassemble

    .method public hidebysig newslot abstract virtual 
            instance void  GetDisassembleEffectiveOffset() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetDisassembleEffectiveOffset

    .method public hidebysig newslot abstract virtual 
            instance void  OutputDisassembly() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::OutputDisassembly

    .method public hidebysig newslot abstract virtual 
            instance void  OutputDisassemblyLines() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::OutputDisassemblyLines

    .method public hidebysig newslot abstract virtual 
            instance void  GetNearInstruction() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetNearInstruction

    .method public hidebysig newslot abstract virtual 
            instance void  GetStackTrace() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetStackTrace

    .method public hidebysig newslot abstract virtual 
            instance void  GetReturnOffset() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetReturnOffset

    .method public hidebysig newslot abstract virtual 
            instance void  OutputStackTrace() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::OutputStackTrace

    .method public hidebysig newslot abstract virtual 
            instance void  GetDebuggeeType() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetDebuggeeType

    .method public hidebysig newslot abstract virtual 
            instance void  GetActualProcessorType() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetActualProcessorType

    .method public hidebysig newslot abstract virtual 
            instance void  GetExecutingProcessorType() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetExecutingProcessorType

    .method public hidebysig newslot abstract virtual 
            instance void  GetNumberPossibleExecutingProcessorTypes() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetNumberPossibleExecutingProcessorTypes

    .method public hidebysig newslot abstract virtual 
            instance void  GetPossibleExecutingProcessorTypes() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetPossibleExecutingProcessorTypes

    .method public hidebysig newslot abstract virtual 
            instance void  GetNumberProcessors() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetNumberProcessors

    .method public hidebysig newslot abstract virtual 
            instance void  GetSystemVersion() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetSystemVersion

    .method public hidebysig newslot abstract virtual 
            instance void  GetPageSize() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetPageSize

    .method public hidebysig newslot abstract virtual 
            instance void  IsPointer64Bit() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::IsPointer64Bit

    .method public hidebysig newslot abstract virtual 
            instance void  ReadBugCheckData() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::ReadBugCheckData

    .method public hidebysig newslot abstract virtual 
            instance void  GetNumberSupportedProcessorTypes() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetNumberSupportedProcessorTypes

    .method public hidebysig newslot abstract virtual 
            instance void  GetSupportedProcessorTypes() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetSupportedProcessorTypes

    .method public hidebysig newslot abstract virtual 
            instance void  GetProcessorTypeNames() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetProcessorTypeNames

    .method public hidebysig newslot abstract virtual 
            instance void  GetEffectiveProcessorType() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetEffectiveProcessorType

    .method public hidebysig newslot abstract virtual 
            instance void  SetEffectiveProcessorType() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::SetEffectiveProcessorType

    .method public hidebysig newslot abstract virtual 
            instance void  GetExecutionStatus() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetExecutionStatus

    .method public hidebysig newslot abstract virtual 
            instance void  SetExecutionStatus() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::SetExecutionStatus

    .method public hidebysig newslot abstract virtual 
            instance void  GetCodeLevel() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetCodeLevel

    .method public hidebysig newslot abstract virtual 
            instance void  SetCodeLevel() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::SetCodeLevel

    .method public hidebysig newslot abstract virtual 
            instance void  GetEngineOptions() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetEngineOptions

    .method public hidebysig newslot abstract virtual 
            instance void  AddEngineOptions() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::AddEngineOptions

    .method public hidebysig newslot abstract virtual 
            instance void  RemoveEngineOptions() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::RemoveEngineOptions

    .method public hidebysig newslot abstract virtual 
            instance void  SetEngineOptions() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::SetEngineOptions

    .method public hidebysig newslot abstract virtual 
            instance void  GetSystemErrorControl() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetSystemErrorControl

    .method public hidebysig newslot abstract virtual 
            instance void  SetSystemErrorControl() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::SetSystemErrorControl

    .method public hidebysig newslot abstract virtual 
            instance void  GetTextMacro() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetTextMacro

    .method public hidebysig newslot abstract virtual 
            instance void  SetTextMacro() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::SetTextMacro

    .method public hidebysig newslot abstract virtual 
            instance void  GetRadix() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetRadix

    .method public hidebysig newslot abstract virtual 
            instance void  SetRadix() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::SetRadix

    .method public hidebysig newslot abstract virtual 
            instance void  Evaluate(string  marshal( lpstr) expression,
                                    int32 desiredType,
                                    [out] valuetype CsExts.UnsafeNativeMethods/DEBUG_VALUE& 'value',
                                    [out] uint32& remainder) cil managed
    {
    } // end of method IDebugControl::Evaluate

    .method public hidebysig newslot abstract virtual 
            instance void  CoerceValue() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::CoerceValue

    .method public hidebysig newslot abstract virtual 
            instance void  CoerceValues() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::CoerceValues

    .method public hidebysig newslot abstract virtual 
            instance void  Execute(valuetype CsExts.UnsafeNativeMethods/OutputControl ctls,
                                   string  marshal( lpstr) command,
                                   valuetype CsExts.UnsafeNativeMethods/ExecuteOptions opts) cil managed
    {
    } // end of method IDebugControl::Execute

    .method public hidebysig newslot abstract virtual 
            instance void  ExecuteCommandFile() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::ExecuteCommandFile

    .method public hidebysig newslot abstract virtual 
            instance void  GetNumberBreakpoints() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetNumberBreakpoints

    .method public hidebysig newslot abstract virtual 
            instance void  GetBreakpointByIndex() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetBreakpointByIndex

    .method public hidebysig newslot abstract virtual 
            instance void  GetBreakpointById() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetBreakpointById

    .method public hidebysig newslot abstract virtual 
            instance void  GetBreakpointParameters() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetBreakpointParameters

    .method public hidebysig newslot abstract virtual 
            instance void  AddBreakpoint() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::AddBreakpoint

    .method public hidebysig newslot abstract virtual 
            instance void  RemoveBreakpoint() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::RemoveBreakpoint

    .method public hidebysig newslot abstract virtual 
            instance void  AddExtension() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::AddExtension

    .method public hidebysig newslot abstract virtual 
            instance void  RemoveExtension() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::RemoveExtension

    .method public hidebysig newslot abstract virtual 
            instance void  GetExtensionByPath() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetExtensionByPath

    .method public hidebysig newslot abstract virtual 
            instance void  CallExtension() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::CallExtension

    .method public hidebysig newslot abstract virtual 
            instance void  GetExtensionFunction() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetExtensionFunction

    .method public hidebysig newslot abstract virtual 
            instance void  GetWindbgExtensionApis32() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetWindbgExtensionApis32

    .method public hidebysig newslot abstract virtual 
            instance void  GetWindbgExtensionApis64() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetWindbgExtensionApis64

    .method public hidebysig newslot abstract virtual 
            instance void  GetNumberEventFilters() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetNumberEventFilters

    .method public hidebysig newslot abstract virtual 
            instance void  GetEventFilterText() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetEventFilterText

    .method public hidebysig newslot abstract virtual 
            instance void  GetEventFilterCommand() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetEventFilterCommand

    .method public hidebysig newslot abstract virtual 
            instance void  SetEventFilterCommand() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::SetEventFilterCommand

    .method public hidebysig newslot abstract virtual 
            instance void  GetSpecificFilterParameters() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetSpecificFilterParameters

    .method public hidebysig newslot abstract virtual 
            instance void  SetSpecificFilterParameters() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::SetSpecificFilterParameters

    .method public hidebysig newslot abstract virtual 
            instance void  GetSpecificFilterArgument() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetSpecificFilterArgument

    .method public hidebysig newslot abstract virtual 
            instance void  SetSpecificFilterArgument() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::SetSpecificFilterArgument

    .method public hidebysig newslot abstract virtual 
            instance void  GetExceptionFilterParameters() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetExceptionFilterParameters

    .method public hidebysig newslot abstract virtual 
            instance void  SetExceptionFilterParameters() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::SetExceptionFilterParameters

    .method public hidebysig newslot abstract virtual 
            instance void  GetExceptionFilterSecondCommand() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetExceptionFilterSecondCommand

    .method public hidebysig newslot abstract virtual 
            instance void  SetExceptionFilterSecondCommand() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::SetExceptionFilterSecondCommand

    .method public hidebysig newslot abstract virtual 
            instance void  WaitForEvent() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::WaitForEvent

    .method public hidebysig newslot abstract virtual 
            instance void  GetLastEventInformation() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugControl::GetLastEventInformation

  } // end of class IDebugControl

  .class interface abstract auto ansi import nested public IDebugOutputCallbacks
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ComInterfaceType) = ( 01 00 01 00 00 00 00 00 ) 
    .custom instance void [mscorlib]System.Security.SuppressUnmanagedCodeSecurityAttribute::.ctor() = ( 01 00 00 00 ) 
    .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 34 62 66 35 38 30 34 35 2D 64 36 35 34   // ..$4bf58045-d654
                                                                                                    2D 34 63 34 30 2D 62 30 61 66 2D 36 38 33 30 39   // -4c40-b0af-68309
                                                                                                    30 66 33 35 36 64 63 00 00 )                      // 0f356dc..
    .method public hidebysig newslot abstract virtual 
            instance void  Output(valuetype CsExts.UnsafeNativeMethods/OutputModes mask,
                                  string  marshal( lpstr) text) cil managed
    {
    } // end of method IDebugOutputCallbacks::Output

  } // end of class IDebugOutputCallbacks

  .class interface abstract auto ansi import nested public IDebugDataSpaces
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 38 38 66 37 64 66 61 62 2D 33 65 61 37   // ..$88f7dfab-3ea7
                                                                                                    2D 34 63 33 61 2D 61 65 66 62 2D 63 34 65 38 31   // -4c3a-aefb-c4e81
                                                                                                    30 36 31 37 33 61 61 00 00 )                      // 06173aa..
    .custom instance void [mscorlib]System.Security.SuppressUnmanagedCodeSecurityAttribute::.ctor() = ( 01 00 00 00 ) 
    .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ComInterfaceType) = ( 01 00 01 00 00 00 00 00 ) 
    .method public hidebysig newslot abstract virtual 
            instance void  ReadVirtual(uint64 offset,
                                       native int buffer,
                                       int32 bufferSize,
                                       [out] int32& bytesRead) cil managed
    {
    } // end of method IDebugDataSpaces::ReadVirtual

    .method public hidebysig newslot abstract virtual 
            instance void  WriteVirtual() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::WriteVirtual

    .method public hidebysig newslot abstract virtual 
            instance void  SearchVirtual() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::SearchVirtual

    .method public hidebysig newslot abstract virtual 
            instance void  ReadVirtualUncached() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::ReadVirtualUncached

    .method public hidebysig newslot abstract virtual 
            instance void  WriteVirtualUncached() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::WriteVirtualUncached

    .method public hidebysig newslot abstract virtual 
            instance void  ReadPointersVirtual() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::ReadPointersVirtual

    .method public hidebysig newslot abstract virtual 
            instance void  WritePointersVirtual() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::WritePointersVirtual

    .method public hidebysig newslot abstract virtual 
            instance void  ReadPhysical() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::ReadPhysical

    .method public hidebysig newslot abstract virtual 
            instance void  WritePhysical() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::WritePhysical

    .method public hidebysig newslot abstract virtual 
            instance void  ReadControl() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::ReadControl

    .method public hidebysig newslot abstract virtual 
            instance void  WriteControl() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::WriteControl

    .method public hidebysig newslot abstract virtual 
            instance void  ReadIo() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::ReadIo

    .method public hidebysig newslot abstract virtual 
            instance void  WriteIo() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::WriteIo

    .method public hidebysig newslot abstract virtual 
            instance void  ReadMsr() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::ReadMsr

    .method public hidebysig newslot abstract virtual 
            instance void  WriteMsr() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::WriteMsr

    .method public hidebysig newslot abstract virtual 
            instance void  ReadBusData() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::ReadBusData

    .method public hidebysig newslot abstract virtual 
            instance void  WriteBusData() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::WriteBusData

    .method public hidebysig newslot abstract virtual 
            instance void  CheckLowMemory() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::CheckLowMemory

    .method public hidebysig newslot abstract virtual 
            instance void  ReadDebuggerData() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::ReadDebuggerData

    .method public hidebysig newslot abstract virtual 
            instance void  ReadProcessorSystemData() cil managed
    {
      .custom instance void [mscorlib]System.ObsoleteAttribute::.ctor(string,
                                                                      bool) = ( 01 00 08 6E 6F 74 20 75 73 65 64 01 00 00 )       // ...not used...
    } // end of method IDebugDataSpaces::ReadProcessorSystemData

  } // end of class IDebugDataSpaces

  .field static assembly initonly int32 E_FAIL
  .field static assembly initonly int32 E_USER_INTERRUPT
  .method private hidebysig specialname rtspecialname static 
          void  .cctor() cil managed
  {
    // Code size       21 (0x15)
    .maxstack  8
    IL_0000:  ldc.i4     0x80040005
    IL_0005:  stsfld     int32 CsExts.UnsafeNativeMethods::E_FAIL
    IL_000a:  ldc.i4     0xd000013a
    IL_000f:  stsfld     int32 CsExts.UnsafeNativeMethods::E_USER_INTERRUPT
    IL_0014:  ret
  } // end of method UnsafeNativeMethods::.cctor

} // end of class CsExts.UnsafeNativeMethods

.class public abstract auto ansi sealed beforefieldinit CsExts.CsExts
       extends [mscorlib]System.Object
{
  .field private static literal int32 DEBUG_EXTENSION_MAJOR_VERSION = int32(0x00000001)
  .field private static literal int32 DEBUG_EXTENSION_MINOR_VERSION = int32(0x00000000)
  .method public hidebysig static int32  DebugExtensionInitialize([out] int32& Version,
                                                                  [out] int32& Flags) cil managed
  {
    // Code size       17 (0x11)
    .maxstack  2
    .locals init ([0] int32 CS$1$0000)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldc.i4     0x10000
    IL_0007:  stind.i4
    IL_0008:  ldarg.1
    IL_0009:  ldc.i4.0
    IL_000a:  stind.i4
    IL_000b:  ldc.i4.0
    IL_000c:  stloc.0
    IL_000d:  br.s       IL_000f

    IL_000f:  ldloc.0
    IL_0010:  ret
  } // end of method CsExts::DebugExtensionInitialize

  .method public hidebysig static int32  dumppo(native int debugClient4,
                                                native int args) cil managed
  {
    // Code size       172 (0xac)
    .maxstack  5
    .locals init ([0] valuetype CsExts.UnsafeNativeMethods/DEBUG_VALUE 'value',
             [1] int32 cb,
             [2] uint32 remainder,
             [3] int32 bufSize,
             [4] native int buffer,
             [5] class CsExts.UnsafeNativeMethods/IDebugClient4 client,
             [6] string argument,
             [7] class CsExts.UnsafeNativeMethods/IDebugControl control,
             [8] class CsExts.UnsafeNativeMethods/IDebugDataSpaces dataSpaces,
             [9] int32 CS$1$0000)
    IL_0000:  nop
    IL_0001:  ldtoken    [mscorlib]System.UInt64
    IL_0006:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_000b:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::SizeOf(class [mscorlib]System.Type)
    IL_0010:  stloc.3
    IL_0011:  ldtoken    [mscorlib]System.UInt64
    IL_0016:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_001b:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::SizeOf(class [mscorlib]System.Type)
    IL_0020:  call       native int [mscorlib]System.Runtime.InteropServices.Marshal::AllocHGlobal(int32)
    IL_0025:  stloc.s    buffer
    IL_0027:  ldarg.0
    IL_0028:  ldtoken    CsExts.UnsafeNativeMethods/IDebugClient4
    IL_002d:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_0032:  call       object [mscorlib]System.Runtime.InteropServices.Marshal::GetTypedObjectForIUnknown(native int,
                                                                                                            class [mscorlib]System.Type)
    IL_0037:  castclass  CsExts.UnsafeNativeMethods/IDebugClient4
    IL_003c:  stloc.s    client
    IL_003e:  ldarg.1
    IL_003f:  call       string [mscorlib]System.Runtime.InteropServices.Marshal::PtrToStringAnsi(native int)
    IL_0044:  stloc.s    argument
    IL_0046:  ldloc.s    client
    IL_0048:  castclass  CsExts.UnsafeNativeMethods/IDebugControl
    IL_004d:  stloc.s    control
    IL_004f:  ldloc.s    client
    IL_0051:  castclass  CsExts.UnsafeNativeMethods/IDebugDataSpaces
    IL_0056:  stloc.s    dataSpaces
    IL_0058:  ldloc.s    control
    IL_005a:  ldloc.s    argument
    IL_005c:  ldc.i4.3
    IL_005d:  ldloca.s   'value'
    IL_005f:  ldloca.s   remainder
    IL_0061:  callvirt   instance void CsExts.UnsafeNativeMethods/IDebugControl::Evaluate(string,
                                                                                          int32,
                                                                                          valuetype CsExts.UnsafeNativeMethods/DEBUG_VALUE&,
                                                                                          uint32&)
    IL_0066:  nop
    IL_0067:  ldloc.s    dataSpaces
    IL_0069:  ldloca.s   'value'
    IL_006b:  ldfld      int32 CsExts.UnsafeNativeMethods/DEBUG_VALUE::I32
    IL_0070:  conv.i8
    IL_0071:  ldloc.s    buffer
    IL_0073:  ldloc.3
    IL_0074:  ldloca.s   cb
    IL_0076:  callvirt   instance void CsExts.UnsafeNativeMethods/IDebugDataSpaces::ReadVirtual(uint64,
                                                                                                native int,
                                                                                                int32,
                                                                                                int32&)
    IL_007b:  nop
    IL_007c:  ldstr      "PurchaseOrder: Id={0}"
    IL_0081:  ldloc.s    buffer
    IL_0083:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::ReadInt32(native int)
    IL_0088:  box        [mscorlib]System.Int32
    IL_008d:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                  object)
    IL_0092:  nop
    IL_0093:  ldloc.s    buffer
    IL_0095:  call       void [mscorlib]System.Runtime.InteropServices.Marshal::FreeHGlobal(native int)
    IL_009a:  nop
    IL_009b:  ldnull
    IL_009c:  stloc.s    dataSpaces
    IL_009e:  ldnull
    IL_009f:  stloc.s    client
    IL_00a1:  ldnull
    IL_00a2:  stloc.s    control
    IL_00a4:  ldc.i4.0
    IL_00a5:  stloc.s    CS$1$0000
    IL_00a7:  br.s       IL_00a9

    IL_00a9:  ldloc.s    CS$1$0000
    IL_00ab:  ret
  } // end of method CsExts::dumppo

  .method public hidebysig static int32  help(native int debugClient4,
                                              native int args) cil managed
  {
    // Code size       40 (0x28)
    .maxstack  1
    .locals init ([0] int32 CS$1$0000)
    IL_0000:  nop
    IL_0001:  ldstr      "Help for CsExts.dll"
    IL_0006:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_000b:  nop
    IL_000c:  ldstr      "!dumppo <addr>    - dump PurchaseOrder structure f"
    + "or address"
    IL_0011:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0016:  nop
    IL_0017:  ldstr      "!help             - Shows this help"
    IL_001c:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0021:  nop
    IL_0022:  ldc.i4.0
    IL_0023:  stloc.0
    IL_0024:  br.s       IL_0026

    IL_0026:  ldloc.0
    IL_0027:  ret
  } // end of method CsExts::help

} // end of class CsExts.CsExts


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file C:\Users\suwatch\AppData\Local\Temp\DllExporter\input.res
