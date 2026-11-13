namespace Variant16.SystemInfoLibrary.Domain.Models;

public sealed record NativeFunctionErrorHandlingScenarioResult(
    string NativeFunctionErrorHandlingScenarioTitle,
    bool IsNativeFunctionInvocationSuccessful,
    string NativeFunctionInvocationOutcomeDescription,
    NativeFunctionFailureKind? NativeFunctionFailureKind,
    int? NativeWin32ErrorCode);
