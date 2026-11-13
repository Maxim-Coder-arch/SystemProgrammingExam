using System.Runtime.InteropServices;

namespace Variant16.SystemInfoLibrary.Domain.Models;

public sealed record OperatingSystemPlatformInformation(
    string OperatingSystemDescription,
    bool IsWindowsOperatingSystem,
    Architecture OperatingSystemArchitecture,
    Architecture ProcessArchitecture,
    bool IsSixtyFourBitOperatingSystem,
    bool IsSixtyFourBitProcess,
    int NativePointerSizeInBytes,
    string RuntimeFrameworkDescription);
