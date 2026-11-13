using Variant16.SystemInfoLibrary.ConsoleApplication.Presentation;
using Variant16.SystemInfoLibrary.Domain.Models;
using Variant16.SystemInfoLibrary.PublicApi;

namespace Variant16.SystemInfoLibrary.ConsoleApplication.DemonstrationSteps;

public sealed class NativeProcessIdentifierDemonstrationStep : IProjectDemonstrationStep
{
    private readonly SystemInformationLibraryFacade _systemInformationLibraryFacade;

    private readonly IDemonstrationReportWriter _demonstrationReportWriter;

    public NativeProcessIdentifierDemonstrationStep(
        SystemInformationLibraryFacade systemInformationLibraryFacade,
        IDemonstrationReportWriter demonstrationReportWriter)
    {
        _systemInformationLibraryFacade = systemInformationLibraryFacade;
        _demonstrationReportWriter = demonstrationReportWriter;
    }

    public string ProjectDemonstrationStepTitle => "Задание 5. PID через P/Invoke GetCurrentProcessId";

    public Task ExecuteProjectDemonstrationStepAsync()
    {
        var currentProcessIdentifierInformation = _systemInformationLibraryFacade.GetCurrentProcessIdentifierInformation();
        var managedRuntimeProcessIdentifierValue = (uint)Environment.ProcessId;

        var isNativeWindowsApiFunctionUsed = currentProcessIdentifierInformation.ProcessIdentifierRetrievalSource
            == ProcessIdentifierRetrievalSource.NativeWindowsApiFunction;

        var isProcessIdentifierMatchingManagedRuntime = currentProcessIdentifierInformation.ProcessIdentifierValue
            == managedRuntimeProcessIdentifierValue;

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "PID из kernel32 GetCurrentProcessId",
            currentProcessIdentifierInformation.ProcessIdentifierValue.ToString());

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Использован нативный вызов",
            BooleanDisplayTextFormatter.FormatBooleanAsDisplayText(isNativeWindowsApiFunctionUsed));

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "PID из Environment.ProcessId",
            managedRuntimeProcessIdentifierValue.ToString());

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Значения совпадают",
            BooleanDisplayTextFormatter.FormatBooleanAsDisplayText(isProcessIdentifierMatchingManagedRuntime));

        return Task.CompletedTask;
    }
}
