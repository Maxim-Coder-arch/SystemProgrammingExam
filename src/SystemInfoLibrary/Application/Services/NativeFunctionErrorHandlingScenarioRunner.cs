using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Domain.Exceptions;
using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.Application.Services;

public sealed class NativeFunctionErrorHandlingScenarioRunner : INativeFunctionErrorHandlingScenarioRunner
{
    private readonly IReadOnlyList<INativeFunctionErrorHandlingScenario> _nativeFunctionErrorHandlingScenarios;

    public NativeFunctionErrorHandlingScenarioRunner(
        IReadOnlyList<INativeFunctionErrorHandlingScenario> nativeFunctionErrorHandlingScenarios)
    {
        _nativeFunctionErrorHandlingScenarios = nativeFunctionErrorHandlingScenarios;
    }

    public IReadOnlyList<NativeFunctionErrorHandlingScenarioResult> RunNativeFunctionErrorHandlingScenarios()
    {
        var nativeFunctionErrorHandlingScenarioResults = _nativeFunctionErrorHandlingScenarios
            .Select(RunSingleNativeFunctionErrorHandlingScenario)
            .ToList();

        return nativeFunctionErrorHandlingScenarioResults;
    }

    private static NativeFunctionErrorHandlingScenarioResult RunSingleNativeFunctionErrorHandlingScenario(
        INativeFunctionErrorHandlingScenario nativeFunctionErrorHandlingScenario)
    {
        try
        {
            var successfulNativeFunctionInvocationDescription =
                nativeFunctionErrorHandlingScenario.ExecuteNativeFunctionErrorHandlingScenario();

            var successfulNativeFunctionErrorHandlingScenarioResult = new NativeFunctionErrorHandlingScenarioResult(
                nativeFunctionErrorHandlingScenario.NativeFunctionErrorHandlingScenarioTitle,
                true,
                successfulNativeFunctionInvocationDescription,
                null,
                null);

            return successfulNativeFunctionErrorHandlingScenarioResult;
        }
        catch (NativeFunctionInvocationException nativeFunctionInvocationException)
        {
            var failedNativeFunctionErrorHandlingScenarioResult = new NativeFunctionErrorHandlingScenarioResult(
                nativeFunctionErrorHandlingScenario.NativeFunctionErrorHandlingScenarioTitle,
                false,
                nativeFunctionInvocationException.Message,
                nativeFunctionInvocationException.NativeFunctionFailureKind,
                nativeFunctionInvocationException.NativeWin32ErrorCode);

            return failedNativeFunctionErrorHandlingScenarioResult;
        }
    }
}
