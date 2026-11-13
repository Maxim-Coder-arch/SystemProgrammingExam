using Variant16.SystemInfoLibrary.ConsoleApplication.Presentation;
using Variant16.SystemInfoLibrary.Domain.Models;
using Variant16.SystemInfoLibrary.PublicApi;

namespace Variant16.SystemInfoLibrary.ConsoleApplication.DemonstrationSteps;

public sealed class NativeFunctionErrorHandlingDemonstrationStep : IProjectDemonstrationStep
{
    private const string EmptyNativeValueDisplayText = "отсутствует";

    private readonly SystemInformationLibraryFacade _systemInformationLibraryFacade;

    private readonly IDemonstrationReportWriter _demonstrationReportWriter;

    public NativeFunctionErrorHandlingDemonstrationStep(
        SystemInformationLibraryFacade systemInformationLibraryFacade,
        IDemonstrationReportWriter demonstrationReportWriter)
    {
        _systemInformationLibraryFacade = systemInformationLibraryFacade;
        _demonstrationReportWriter = demonstrationReportWriter;
    }

    public string ProjectDemonstrationStepTitle => "Задание 7. Обработка ошибки вызова нативной функции";

    public Task ExecuteProjectDemonstrationStepAsync()
    {
        var nativeFunctionErrorHandlingScenarioResults = _systemInformationLibraryFacade.RunNativeFunctionErrorHandlingScenarios();

        if (nativeFunctionErrorHandlingScenarioResults.Count == 0)
        {
            _demonstrationReportWriter.WriteDemonstrationMessage("Нативные сценарии доступны только в Windows.");

            return Task.CompletedTask;
        }

        foreach (var nativeFunctionErrorHandlingScenarioResult in nativeFunctionErrorHandlingScenarioResults)
        {
            WriteNativeFunctionErrorHandlingScenarioResult(nativeFunctionErrorHandlingScenarioResult);
        }

        return Task.CompletedTask;
    }

    private void WriteNativeFunctionErrorHandlingScenarioResult(
        NativeFunctionErrorHandlingScenarioResult nativeFunctionErrorHandlingScenarioResult)
    {
        var nativeFunctionFailureKindDisplayText = nativeFunctionErrorHandlingScenarioResult.NativeFunctionFailureKind?.ToString()
            ?? EmptyNativeValueDisplayText;

        var nativeWin32ErrorCodeDisplayText = nativeFunctionErrorHandlingScenarioResult.NativeWin32ErrorCode?.ToString()
            ?? EmptyNativeValueDisplayText;

        _demonstrationReportWriter.WriteDemonstrationMessage(nativeFunctionErrorHandlingScenarioResult.NativeFunctionErrorHandlingScenarioTitle);

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Вызов успешен",
            BooleanDisplayTextFormatter.FormatBooleanAsDisplayText(nativeFunctionErrorHandlingScenarioResult.IsNativeFunctionInvocationSuccessful));

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Вид ошибки",
            nativeFunctionFailureKindDisplayText);

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Код ошибки Win32",
            nativeWin32ErrorCodeDisplayText);

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Результат",
            nativeFunctionErrorHandlingScenarioResult.NativeFunctionInvocationOutcomeDescription);
    }
}
