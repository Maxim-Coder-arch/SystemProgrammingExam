using System.Runtime.Versioning;
using Variant16.SystemInfoLibrary.Application.Abstractions;

namespace Variant16.SystemInfoLibrary.Infrastructure.Native.ErrorHandlingScenarios;

[SupportedOSPlatform("windows")]
public sealed class MissingNativeEntryPointScenario : INativeFunctionErrorHandlingScenario
{
    private const string MissingNativeEntryPointFunctionName = "GetCurrentProcessIdentifierFunctionThatDoesNotExist";

    private readonly NativeFunctionInvocationGuard _nativeFunctionInvocationGuard;

    public MissingNativeEntryPointScenario(NativeFunctionInvocationGuard nativeFunctionInvocationGuard)
    {
        _nativeFunctionInvocationGuard = nativeFunctionInvocationGuard;
    }

    public string NativeFunctionErrorHandlingScenarioTitle => "Вызов отсутствующей точки входа в kernel32.dll";

    public string ExecuteNativeFunctionErrorHandlingScenario()
    {
        var unexpectedProcessIdentifierValue = _nativeFunctionInvocationGuard.InvokeNativeFunctionSafely(
            MissingNativeEntryPointFunctionName,
            Kernel32NativeMethods.GetCurrentProcessIdFromMissingNativeEntryPoint);

        var unexpectedProcessIdentifierDescription = $"Неожиданно получено значение {unexpectedProcessIdentifierValue}";

        return unexpectedProcessIdentifierDescription;
    }
}
