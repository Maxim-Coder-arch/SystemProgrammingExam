using System.Runtime.InteropServices;
using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.Infrastructure.Runtime;

public sealed class RuntimeOperatingSystemPlatformInformationProvider : IOperatingSystemPlatformInformationProvider
{
    public OperatingSystemPlatformInformation GetOperatingSystemPlatformInformation()
    {
        var operatingSystemPlatformInformation = new OperatingSystemPlatformInformation(
            RuntimeInformation.OSDescription,
            OperatingSystem.IsWindows(),
            RuntimeInformation.OSArchitecture,
            RuntimeInformation.ProcessArchitecture,
            Environment.Is64BitOperatingSystem,
            Environment.Is64BitProcess,
            IntPtr.Size,
            RuntimeInformation.FrameworkDescription);

        return operatingSystemPlatformInformation;
    }
}
