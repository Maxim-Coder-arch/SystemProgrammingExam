using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.Infrastructure.Limitations;

public sealed class ProcessBitnessLimitationCheck : IWindowsApiLimitationCheck
{
    private const string ProcessBitnessLimitationTitle = "Разрядность процесса и нативной DLL должна совпадать";

    private const string ProcessBitnessLimitationDescription =
        "64 битный процесс не может загрузить 32 битную нативную DLL и наоборот, загрузчик выбросит BadImageFormatException. " +
        "32 битный процесс на 64 битной Windows работает через WOW64 и получает kernel32.dll из SysWOW64.";

    private readonly IOperatingSystemPlatformInformationProvider _operatingSystemPlatformInformationProvider;

    public ProcessBitnessLimitationCheck(
        IOperatingSystemPlatformInformationProvider operatingSystemPlatformInformationProvider)
    {
        _operatingSystemPlatformInformationProvider = operatingSystemPlatformInformationProvider;
    }

    public WindowsApiLimitationInspectionResult InspectWindowsApiLimitation()
    {
        var operatingSystemPlatformInformation = _operatingSystemPlatformInformationProvider.GetOperatingSystemPlatformInformation();

        var isProcessRunningUnderArchitectureEmulation = operatingSystemPlatformInformation.ProcessArchitecture
            != operatingSystemPlatformInformation.OperatingSystemArchitecture;

        var currentEnvironmentObservation =
            $"Процесс {operatingSystemPlatformInformation.ProcessArchitecture}, " +
            $"система {operatingSystemPlatformInformation.OperatingSystemArchitecture}, " +
            $"размер указателя {operatingSystemPlatformInformation.NativePointerSizeInBytes} байт";

        var processBitnessLimitationInspectionResult = new WindowsApiLimitationInspectionResult(
            ProcessBitnessLimitationTitle,
            ProcessBitnessLimitationDescription,
            currentEnvironmentObservation,
            isProcessRunningUnderArchitectureEmulation);

        return processBitnessLimitationInspectionResult;
    }
}
