using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Application.Services;
using Variant16.SystemInfoLibrary.Infrastructure.Catalogs;
using Variant16.SystemInfoLibrary.Infrastructure.FileSystem;
using Variant16.SystemInfoLibrary.Infrastructure.Native;
using Variant16.SystemInfoLibrary.Infrastructure.PortableExecutable;
using Variant16.SystemInfoLibrary.Infrastructure.Reflection;
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

        var nativeFunctionErrorHandlingScenarioRunner = CreateNativeFunctionErrorHandlingScenarioRunner(
            nativeFunctionInvocationGuard);

        var windowsApiLimitationInspector = CreateWindowsApiLimitationInspector(
            processIdentifierProvider,
            operatingSystemPlatformInformationProvider,
            nativeFunctionInvocationGuard);

        var assemblyVersionInformationProvider = new ReflectionAssemblyVersionInformationProvider();
        var dynamicLinkLibraryComparisonService = CreateDynamicLinkLibraryComparisonService();

        var systemInformationLibraryFacade = new SystemInformationLibraryFacade(
            processIdentifierProvider,
            operatingSystemPlatformInformationProvider,
            nativeFunctionErrorHandlingScenarioRunner,
            windowsApiLimitationInspector,
            assemblyVersionInformationProvider,
            dynamicLinkLibraryComparisonService);

        return systemInformationLibraryFacade;
    }

    private static IDynamicLinkLibraryComparisonService CreateDynamicLinkLibraryComparisonService()
    {
        var dynamicLinkLibraryLocationProvider = new DefaultDynamicLinkLibraryLocationProvider();
        var managedAssemblyMetadataReadabilityChecker = new ManagedAssemblyMetadataReadabilityChecker();
        var portableExecutableFileInspector = new PortableExecutableFileInspector(managedAssemblyMetadataReadabilityChecker);
        var dynamicLinkLibraryComparisonCriteriaCatalog = new StaticDynamicLinkLibraryComparisonCriteriaCatalog();

        var dynamicLinkLibraryComparisonService = new DynamicLinkLibraryComparisonService(
            dynamicLinkLibraryLocationProvider,
            portableExecutableFileInspector,
            dynamicLinkLibraryComparisonCriteriaCatalog);

        return dynamicLinkLibraryComparisonService;
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

    private static INativeFunctionErrorHandlingScenarioRunner CreateNativeFunctionErrorHandlingScenarioRunner(
        NativeFunctionInvocationGuard nativeFunctionInvocationGuard)
    {
        var nativeFunctionErrorHandlingScenarios =
            NativeFunctionErrorHandlingScenariosFactory.CreateNativeFunctionErrorHandlingScenarios(nativeFunctionInvocationGuard);

        var nativeFunctionErrorHandlingScenarioRunner =
            new NativeFunctionErrorHandlingScenarioRunner(nativeFunctionErrorHandlingScenarios);

        return nativeFunctionErrorHandlingScenarioRunner;
    }

    private static IWindowsApiLimitationInspector CreateWindowsApiLimitationInspector(
        IProcessIdentifierProvider processIdentifierProvider,
        IOperatingSystemPlatformInformationProvider operatingSystemPlatformInformationProvider,
        NativeFunctionInvocationGuard nativeFunctionInvocationGuard)
    {
        var windowsApiLimitationChecks = WindowsApiLimitationChecksFactory.CreateWindowsApiLimitationChecks(
            processIdentifierProvider,
            operatingSystemPlatformInformationProvider,
            nativeFunctionInvocationGuard);

        var windowsApiLimitationInspector = new WindowsApiLimitationInspector(windowsApiLimitationChecks);

        return windowsApiLimitationInspector;
    }
}
