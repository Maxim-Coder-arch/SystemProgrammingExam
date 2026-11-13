using Variant16.SystemInfoLibrary.ConsoleApplication.Presentation;
using Variant16.SystemInfoLibrary.PublicApi;

namespace Variant16.SystemInfoLibrary.ConsoleApplication.DemonstrationSteps;

public sealed class LibraryPublicMethodsDemonstrationStep : IProjectDemonstrationStep
{
    private readonly SystemInformationLibraryFacade _systemInformationLibraryFacade;

    private readonly IDemonstrationReportWriter _demonstrationReportWriter;

    public LibraryPublicMethodsDemonstrationStep(
        SystemInformationLibraryFacade systemInformationLibraryFacade,
        IDemonstrationReportWriter demonstrationReportWriter)
    {
        _systemInformationLibraryFacade = systemInformationLibraryFacade;
        _demonstrationReportWriter = demonstrationReportWriter;
    }

    public string ProjectDemonstrationStepTitle => "Задание 3. Два публичных метода библиотеки";

    public Task ExecuteProjectDemonstrationStepAsync()
    {
        WriteCurrentProcessIdentifierInformation();
        WriteOperatingSystemPlatformInformation();

        return Task.CompletedTask;
    }

    private void WriteCurrentProcessIdentifierInformation()
    {
        var currentProcessIdentifierInformation = _systemInformationLibraryFacade.GetCurrentProcessIdentifierInformation();

        _demonstrationReportWriter.WriteDemonstrationMessage("Метод GetCurrentProcessIdentifierInformation:");

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Идентификатор процесса",
            currentProcessIdentifierInformation.ProcessIdentifierValue.ToString());

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Источник идентификатора",
            currentProcessIdentifierInformation.ProcessIdentifierRetrievalSource.ToString());
    }

    private void WriteOperatingSystemPlatformInformation()
    {
        var operatingSystemPlatformInformation = _systemInformationLibraryFacade.GetOperatingSystemPlatformInformation();

        _demonstrationReportWriter.WriteDemonstrationMessage("Метод GetOperatingSystemPlatformInformation:");

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Операционная система",
            operatingSystemPlatformInformation.OperatingSystemDescription);

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Это Windows",
            BooleanDisplayTextFormatter.FormatBooleanAsDisplayText(operatingSystemPlatformInformation.IsWindowsOperatingSystem));

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Архитектура системы",
            operatingSystemPlatformInformation.OperatingSystemArchitecture.ToString());

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Архитектура процесса",
            operatingSystemPlatformInformation.ProcessArchitecture.ToString());

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "64 битная система",
            BooleanDisplayTextFormatter.FormatBooleanAsDisplayText(operatingSystemPlatformInformation.IsSixtyFourBitOperatingSystem));

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "64 битный процесс",
            BooleanDisplayTextFormatter.FormatBooleanAsDisplayText(operatingSystemPlatformInformation.IsSixtyFourBitProcess));

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Размер указателя в байтах",
            operatingSystemPlatformInformation.NativePointerSizeInBytes.ToString());

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Среда выполнения",
            operatingSystemPlatformInformation.RuntimeFrameworkDescription);
    }
}
