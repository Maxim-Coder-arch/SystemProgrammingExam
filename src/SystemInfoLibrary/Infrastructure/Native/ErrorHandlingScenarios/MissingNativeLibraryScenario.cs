using System.Runtime.Versioning;
using Variant16.SystemInfoLibrary.Application.Abstractions;

namespace Variant16.SystemInfoLibrary.Infrastructure.Native.ErrorHandlingScenarios;

[SupportedOSPlatform("windows")]
public sealed class MissingNativeLibraryScenario : INativeFunctionErrorHandlingScenario
{
    private const string MissingNativeLibraryFunctionName = "GetCurrentProcessId";

    private readonly NativeFunctionInvocationGuard _nativeFunctionInvocationGuard;

    public MissingNativeLibraryScenario(NativeFunctionInvocationGuard nativeFunctionInvocationGuard)
    {
        _nativeFunctionInvocationGuard = nativeFunctionInvocationGuard;
    }

    public string NativeFunctionErrorHandlingScenarioTitle =>
        $"Вызов функции из отсутствующей библиотеки {MissingNativeLibraryNativeMethods.MissingNativeLibraryName}";

    public string ExecuteNativeFunctionErrorHandlingScenario()
    {
        var unexpectedProcessIdentifierValue = _nativeFunctionInvocationGuard.InvokeNativeFunctionSafely(
            MissingNativeLibraryFunctionName,
            MissingNativeLibraryNativeMethods.GetCurrentProcessId);

        var unexpectedProcessIdentifierDescription = $"Неожиданно получено значение {unexpectedProcessIdentifierValue}";

        return unexpectedProcessIdentifierDescription;
    }
}
