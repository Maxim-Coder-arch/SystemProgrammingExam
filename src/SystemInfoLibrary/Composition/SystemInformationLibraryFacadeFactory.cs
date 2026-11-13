using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Application.Services;
using Variant16.SystemInfoLibrary.Infrastructure.Native;
using Variant16.SystemInfoLibrary.Infrastructure.Runtime;
using Variant16.SystemInfoLibrary.PublicApi;

namespace Variant16.SystemInfoLibrary.Composition;

public static class SystemInformationLibraryFacadeFactory
{
    public static SystemInformationLibraryFacade CreateDefaultSystemInformationLibraryFacade()
    {
        var nativeFunctionInvocationGuard = new NativeFunctionInvocationGuard();
        var processIdentifierProvider = CreateProcessIdentifierProvider(nativeFunctionInvocationGuard);
        var operatingSystemPlatformInformationProvider = new RuntimeOperatingSystemPlatformInformationProvider();

        var nativeFunctionErrorHandlingScenarios =
            NativeFunctionErrorHandlingScenariosFactory.CreateNativeFunctionErrorHandlingScenarios(nativeFunctionInvocationGuard);

        var nativeFunctionErrorHandlingScenarioRunner =
            new NativeFunctionErrorHandlingScenarioRunner(nativeFunctionErrorHandlingScenarios);

        var systemInformationLibraryFacade = new SystemInformationLibraryFacade(
            processIdentifierProvider,
            operatingSystemPlatformInformationProvider,
            nativeFunctionErrorHandlingScenarioRunner);

        return systemInformationLibraryFacade;
    }

    private static IProcessIdentifierProvider CreateProcessIdentifierProvider(
        NativeFunctionInvocationGuard nativeFunctionInvocationGuard)
    {
        if (OperatingSystem.IsWindows())
        {
            var nativeWindowsProcessIdentifierProvider = new NativeWindowsProcessIdentifierProvider(nativeFunctionInvocationGuard);

            return nativeWindowsProcessIdentifierProvider;
        }

        var managedRuntimeProcessIdentifierProvider = new ManagedRuntimeProcessIdentifierProvider();

        return managedRuntimeProcessIdentifierProvider;
    }
}
