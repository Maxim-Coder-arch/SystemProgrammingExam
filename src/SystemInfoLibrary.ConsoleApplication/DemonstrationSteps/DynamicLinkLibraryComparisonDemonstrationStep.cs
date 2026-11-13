using Variant16.SystemInfoLibrary.ConsoleApplication.Presentation;
using Variant16.SystemInfoLibrary.Domain.Models;
using Variant16.SystemInfoLibrary.PublicApi;

namespace Variant16.SystemInfoLibrary.ConsoleApplication.DemonstrationSteps;

public sealed class DynamicLinkLibraryComparisonDemonstrationStep : IProjectDemonstrationStep
{
    private readonly SystemInformationLibraryFacade _systemInformationLibraryFacade;

    private readonly IDemonstrationReportWriter _demonstrationReportWriter;

    public DynamicLinkLibraryComparisonDemonstrationStep(
        SystemInformationLibraryFacade systemInformationLibraryFacade,
        IDemonstrationReportWriter demonstrationReportWriter)
    {
        _systemInformationLibraryFacade = systemInformationLibraryFacade;
        _demonstrationReportWriter = demonstrationReportWriter;
    }

    public string ProjectDemonstrationStepTitle => "Задание 10. Сравнение управляемой и нативной DLL";

    public Task ExecuteProjectDemonstrationStepAsync()
    {
        var dynamicLinkLibraryComparisonReport = _systemInformationLibraryFacade.CompareManagedAndNativeDynamicLinkLibraries();

        WritePortableExecutableFileInspectionResult(
            "Управляемая DLL",
            dynamicLinkLibraryComparisonReport.ManagedDynamicLinkLibraryInspectionResult);

        WritePortableExecutableFileInspectionResult(
            "Нативная DLL",
            dynamicLinkLibraryComparisonReport.NativeDynamicLinkLibraryInspectionResult);

        foreach (var dynamicLinkLibraryComparisonCriterion in dynamicLinkLibraryComparisonReport.DynamicLinkLibraryComparisonCriteria)
        {
            WriteDynamicLinkLibraryComparisonCriterion(dynamicLinkLibraryComparisonCriterion);
        }

        return Task.CompletedTask;
    }

    private void WritePortableExecutableFileInspectionResult(
        string dynamicLinkLibraryKindTitle,
        PortableExecutableFileInspectionResult portableExecutableFileInspectionResult)
    {
        _demonstrationReportWriter.WriteDemonstrationMessage(
            $"{dynamicLinkLibraryKindTitle}: {portableExecutableFileInspectionResult.InspectedFileLocation}");

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Файл найден",
            BooleanDisplayTextFormatter.FormatBooleanAsDisplayText(portableExecutableFileInspectionResult.IsInspectedFileFound));

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Размер в байтах",
            portableExecutableFileInspectionResult.InspectedFileSizeInBytes.ToString());

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Машина в PE заголовке",
            portableExecutableFileInspectionResult.PortableExecutableMachineType);

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Есть заголовок CLR",
            BooleanDisplayTextFormatter.FormatBooleanAsDisplayText(portableExecutableFileInspectionResult.ContainsCommonLanguageRuntimeHeader));

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Флаги CLR",
            portableExecutableFileInspectionResult.CommonLanguageRuntimeFlags);

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Читается как сборка .NET",
            BooleanDisplayTextFormatter.FormatBooleanAsDisplayText(portableExecutableFileInspectionResult.IsReadableAsManagedAssembly));
    }

    private void WriteDynamicLinkLibraryComparisonCriterion(
        DynamicLinkLibraryComparisonCriterion dynamicLinkLibraryComparisonCriterion)
    {
        _demonstrationReportWriter.WriteDemonstrationMessage(dynamicLinkLibraryComparisonCriterion.ComparisonCriterionTitle);

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Управляемая DLL",
            dynamicLinkLibraryComparisonCriterion.ManagedDynamicLinkLibraryCharacteristic);

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Нативная DLL",
            dynamicLinkLibraryComparisonCriterion.NativeDynamicLinkLibraryCharacteristic);
    }
}
