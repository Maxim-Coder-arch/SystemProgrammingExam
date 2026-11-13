using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Infrastructure.Runtime;
using Variant16.SystemInfoLibrary.PublicApi;

namespace Variant16.SystemInfoLibrary.Composition;

public static class SystemInformationLibraryFacadeFactory
{
    public static SystemInformationLibraryFacade CreateDefaultSystemInformationLibraryFacade()
    {
        var processIdentifierProvider = CreateProcessIdentifierProvider();
        var operatingSystemPlatformInformationProvider = new RuntimeOperatingSystemPlatformInformationProvider();

        var systemInformationLibraryFacade = new SystemInformationLibraryFacade(
            processIdentifierProvider,
            operatingSystemPlatformInformationProvider);

        return systemInformationLibraryFacade;
    }

    private static IProcessIdentifierProvider CreateProcessIdentifierProvider()
    {
        var managedRuntimeProcessIdentifierProvider = new ManagedRuntimeProcessIdentifierProvider();

        return managedRuntimeProcessIdentifierProvider;
    }
}
