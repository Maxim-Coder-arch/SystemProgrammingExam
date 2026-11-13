using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.PublicApi;

public sealed partial class SystemInformationLibraryFacade
{
    private readonly IProcessIdentifierProvider _processIdentifierProvider;

    private readonly IOperatingSystemPlatformInformationProvider _operatingSystemPlatformInformationProvider;

    private readonly INativeFunctionErrorHandlingScenarioRunner _nativeFunctionErrorHandlingScenarioRunner;

    private readonly IWindowsApiLimitationInspector _windowsApiLimitationInspector;

    public SystemInformationLibraryFacade(
        IProcessIdentifierProvider processIdentifierProvider,
        IOperatingSystemPlatformInformationProvider operatingSystemPlatformInformationProvider,
        INativeFunctionErrorHandlingScenarioRunner nativeFunctionErrorHandlingScenarioRunner,
        IWindowsApiLimitationInspector windowsApiLimitationInspector)
    {
        _processIdentifierProvider = processIdentifierProvider;
        _operatingSystemPlatformInformationProvider = operatingSystemPlatformInformationProvider;
        _nativeFunctionErrorHandlingScenarioRunner = nativeFunctionErrorHandlingScenarioRunner;
        _windowsApiLimitationInspector = windowsApiLimitationInspector;
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
