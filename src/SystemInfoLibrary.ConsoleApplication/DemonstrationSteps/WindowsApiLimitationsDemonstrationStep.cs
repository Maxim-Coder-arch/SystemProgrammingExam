using Variant16.SystemInfoLibrary.ConsoleApplication.Presentation;
using Variant16.SystemInfoLibrary.Domain.Models;
using Variant16.SystemInfoLibrary.PublicApi;

namespace Variant16.SystemInfoLibrary.ConsoleApplication.DemonstrationSteps;

public sealed class WindowsApiLimitationsDemonstrationStep : IProjectDemonstrationStep
{
    private readonly SystemInformationLibraryFacade _systemInformationLibraryFacade;

    private readonly IDemonstrationReportWriter _demonstrationReportWriter;

    public WindowsApiLimitationsDemonstrationStep(
        SystemInformationLibraryFacade systemInformationLibraryFacade,
        IDemonstrationReportWriter demonstrationReportWriter)
    {
        _systemInformationLibraryFacade = systemInformationLibraryFacade;
        _demonstrationReportWriter = demonstrationReportWriter;
    }

    public string ProjectDemonstrationStepTitle => "Задание 6. Ограничения Windows API";

    public Task ExecuteProjectDemonstrationStepAsync()
    {
        var windowsApiLimitationInspectionResults = _systemInformationLibraryFacade.InspectWindowsApiLimitations();

        foreach (var windowsApiLimitationInspectionResult in windowsApiLimitationInspectionResults)
        {
            WriteWindowsApiLimitationInspectionResult(windowsApiLimitationInspectionResult);
        }

        return Task.CompletedTask;
    }

    private void WriteWindowsApiLimitationInspectionResult(
        WindowsApiLimitationInspectionResult windowsApiLimitationInspectionResult)
    {
        _demonstrationReportWriter.WriteDemonstrationMessage(windowsApiLimitationInspectionResult.WindowsApiLimitationTitle);

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Описание",
            windowsApiLimitationInspectionResult.WindowsApiLimitationDescription);

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Проверка",
            windowsApiLimitationInspectionResult.CurrentEnvironmentObservation);

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Проявляется сейчас",
            BooleanDisplayTextFormatter.FormatBooleanAsDisplayText(windowsApiLimitationInspectionResult.IsLimitationObservedInCurrentEnvironment));
    }
}
