using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Infrastructure.Limitations;
using Variant16.SystemInfoLibrary.Infrastructure.Native;

namespace Variant16.SystemInfoLibrary.Composition;

internal static class WindowsApiLimitationChecksFactory
{
    internal static IReadOnlyList<IWindowsApiLimitationCheck> CreateWindowsApiLimitationChecks(
        IProcessIdentifierProvider processIdentifierProvider,
        IOperatingSystemPlatformInformationProvider operatingSystemPlatformInformationProvider,
        NativeFunctionInvocationGuard nativeFunctionInvocationGuard)
    {
        var windowsApiLimitationChecks = new List<IWindowsApiLimitationCheck>
        {
            new OperatingSystemPlatformLimitationCheck(operatingSystemPlatformInformationProvider),
            new ProcessBitnessLimitationCheck(operatingSystemPlatformInformationProvider),
            new NativeTypeSizeLimitationCheck(),
            new ProcessIdentifierReuseLimitationCheck(processIdentifierProvider)
        };

        if (OperatingSystem.IsWindows())
        {
            var nativeModuleHandleRetriever = new NativeModuleHandleRetriever(nativeFunctionInvocationGuard);

            windowsApiLimitationChecks.Add(new NativeErrorReportingLimitationCheck(nativeModuleHandleRetriever));
        }

        return windowsApiLimitationChecks;
    }
}
