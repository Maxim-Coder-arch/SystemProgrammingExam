using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.Infrastructure.Limitations;

public sealed class OperatingSystemPlatformLimitationCheck : IWindowsApiLimitationCheck
{
    private const string OperatingSystemPlatformLimitationTitle = "Windows API доступен только в Windows";

    private const string OperatingSystemPlatformLimitationDescription =
        "Функции kernel32.dll существуют только в Windows. На Linux и macOS такой вызов завершится DllNotFoundException, " +
        "поэтому библиотека проверяет OperatingSystem.IsWindows и в остальных системах использует Environment.ProcessId.";

    private readonly IOperatingSystemPlatformInformationProvider _operatingSystemPlatformInformationProvider;

    public OperatingSystemPlatformLimitationCheck(
        IOperatingSystemPlatformInformationProvider operatingSystemPlatformInformationProvider)
    {
        _operatingSystemPlatformInformationProvider = operatingSystemPlatformInformationProvider;
    }

    public WindowsApiLimitationInspectionResult InspectWindowsApiLimitation()
    {
        var operatingSystemPlatformInformation = _operatingSystemPlatformInformationProvider.GetOperatingSystemPlatformInformation();

        var currentEnvironmentObservation =
            $"Текущая система {operatingSystemPlatformInformation.OperatingSystemDescription}, Windows API доступен: " +
            $"{operatingSystemPlatformInformation.IsWindowsOperatingSystem}";

        var operatingSystemPlatformLimitationInspectionResult = new WindowsApiLimitationInspectionResult(
            OperatingSystemPlatformLimitationTitle,
            OperatingSystemPlatformLimitationDescription,
            currentEnvironmentObservation,
            !operatingSystemPlatformInformation.IsWindowsOperatingSystem);

        return operatingSystemPlatformLimitationInspectionResult;
    }
}
