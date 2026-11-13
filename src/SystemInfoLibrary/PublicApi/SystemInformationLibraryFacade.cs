using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.PublicApi;

public sealed partial class SystemInformationLibraryFacade
{
    private readonly IProcessIdentifierProvider _processIdentifierProvider;

    private readonly IOperatingSystemPlatformInformationProvider _operatingSystemPlatformInformationProvider;

    public SystemInformationLibraryFacade(
        IProcessIdentifierProvider processIdentifierProvider,
        IOperatingSystemPlatformInformationProvider operatingSystemPlatformInformationProvider)
    {
        _processIdentifierProvider = processIdentifierProvider;
        _operatingSystemPlatformInformationProvider = operatingSystemPlatformInformationProvider;
    }

    public ProcessIdentifierInformation GetCurrentProcessIdentifierInformation()
    {
        var currentProcessIdentifierInformation = _processIdentifierProvider.GetCurrentProcessIdentifierInformation();

        return currentProcessIdentifierInformation;
    }

    public OperatingSystemPlatformInformation GetOperatingSystemPlatformInformation()
    {
        var operatingSystemPlatformInformation = _operatingSystemPlatformInformationProvider.GetOperatingSystemPlatformInformation();

        return operatingSystemPlatformInformation;
    }
}
