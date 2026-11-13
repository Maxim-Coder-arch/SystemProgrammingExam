using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Variant16.SystemInfoLibrary.Infrastructure.Native;

[SupportedOSPlatform("windows")]
internal static class MissingNativeLibraryNativeMethods
{
    internal const string MissingNativeLibraryName = "variant16_missing_system_information_library.dll";

    [DllImport(MissingNativeLibraryName, ExactSpelling = true)]
    internal static extern uint GetCurrentProcessId();
}
