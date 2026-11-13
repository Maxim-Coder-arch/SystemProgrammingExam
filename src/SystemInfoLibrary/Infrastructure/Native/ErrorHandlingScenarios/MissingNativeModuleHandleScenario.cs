using System.Runtime.Versioning;
using Variant16.SystemInfoLibrary.Application.Abstractions;

namespace Variant16.SystemInfoLibrary.Infrastructure.Native.ErrorHandlingScenarios;

[SupportedOSPlatform("windows")]
public sealed class MissingNativeModuleHandleScenario : INativeFunctionErrorHandlingScenario
{
    private const string MissingNativeModuleName = "variant16_module_that_is_not_loaded.dll";

    private readonly NativeModuleHandleRetriever _nativeModuleHandleRetriever;

    public MissingNativeModuleHandleScenario(NativeModuleHandleRetriever nativeModuleHandleRetriever)
    {
        _nativeModuleHandleRetriever = nativeModuleHandleRetriever;
    }

    public string NativeFunctionErrorHandlingScenarioTitle => $"GetModuleHandleW для незагруженного модуля {MissingNativeModuleName}";

    public string ExecuteNativeFunctionErrorHandlingScenario()
    {
        var missingNativeModuleHandle = _nativeModuleHandleRetriever.RetrieveLoadedNativeModuleHandle(MissingNativeModuleName);

        var missingNativeModuleHandleDescription = $"Неожиданно получен дескриптор модуля 0x{missingNativeModuleHandle.ToInt64():X}";

        return missingNativeModuleHandleDescription;
    }
}
