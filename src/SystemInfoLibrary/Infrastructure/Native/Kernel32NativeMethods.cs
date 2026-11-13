using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Variant16.SystemInfoLibrary.Infrastructure.Native;

[SupportedOSPlatform("windows")]
internal static class Kernel32NativeMethods
{
    private const string Kernel32NativeLibraryName = "kernel32.dll";

    private const string MissingKernel32NativeEntryPointName = "GetCurrentProcessIdentifierFunctionThatDoesNotExist";

    [DllImport(Kernel32NativeLibraryName, ExactSpelling = true)]
    internal static extern uint GetCurrentProcessId();

    [DllImport(Kernel32NativeLibraryName, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
    internal static extern IntPtr GetModuleHandleW(string nativeModuleName);

    [DllImport(Kernel32NativeLibraryName, EntryPoint = MissingKernel32NativeEntryPointName, ExactSpelling = true)]
    internal static extern uint GetCurrentProcessIdFromMissingNativeEntryPoint();
}
