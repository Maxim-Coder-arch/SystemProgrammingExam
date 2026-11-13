using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Variant16.SystemInfoLibrary.Infrastructure.Native;

[SupportedOSPlatform("windows")]
internal static class Kernel32NativeMethods
{
    private const string Kernel32NativeLibraryName = "kernel32.dll";

    [DllImport(Kernel32NativeLibraryName, ExactSpelling = true)]
    internal static extern uint GetCurrentProcessId();
}
