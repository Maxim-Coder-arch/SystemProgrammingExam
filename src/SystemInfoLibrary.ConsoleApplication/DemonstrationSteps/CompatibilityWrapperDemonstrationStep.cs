using Variant16.SystemInfoLibrary.ConsoleApplication.Presentation;
using Variant16.SystemInfoLibrary.PublicApi;

namespace Variant16.SystemInfoLibrary.ConsoleApplication.DemonstrationSteps;

public sealed class CompatibilityWrapperDemonstrationStep : IProjectDemonstrationStep
{
    private readonly SystemInformationLibraryFacade _systemInformationLibraryFacade;

    private readonly IDemonstrationReportWriter _demonstrationReportWriter;

    public CompatibilityWrapperDemonstrationStep(
        SystemInformationLibraryFacade systemInformationLibraryFacade,
        IDemonstrationReportWriter demonstrationReportWriter)
    {
        _systemInformationLibraryFacade = systemInformationLibraryFacade;
        _demonstrationReportWriter = demonstrationReportWriter;
    }

    public string ProjectDemonstrationStepTitle => "Задание 9. Совместимый метод обёртка при изменении API";

    public Task ExecuteProjectDemonstrationStepAsync()
    {
        var currentProcessIdentifierInformation = _systemInformationLibraryFacade.GetCurrentProcessIdentifierInformation();
        var legacyCurrentProcessIdentifierValue = InvokeLegacyGetCurrentProcessIdWrapper();

        var isLegacyWrapperMatchingCurrentApi = legacyCurrentProcessIdentifierValue
            == currentProcessIdentifierInformation.ProcessIdentifierValue;

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Новый API GetCurrentProcessIdentifierInformation",
            currentProcessIdentifierInformation.ToString());

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Старый API GetCurrentProcessId через обёртку",
            legacyCurrentProcessIdentifierValue.ToString());

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Результаты совпадают",
            BooleanDisplayTextFormatter.FormatBooleanAsDisplayText(isLegacyWrapperMatchingCurrentApi));

        return Task.CompletedTask;
    }

    private int InvokeLegacyGetCurrentProcessIdWrapper()
    {
#pragma warning disable CS0618
        var legacyCurrentProcessIdentifierValue = _systemInformationLibraryFacade.GetCurrentProcessId();
#pragma warning restore CS0618

        return legacyCurrentProcessIdentifierValue;
    }
}
