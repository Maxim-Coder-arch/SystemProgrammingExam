using System.Runtime.Versioning;
using Variant16.SystemInfoLibrary.Application.Abstractions;

namespace Variant16.SystemInfoLibrary.Infrastructure.Native.ErrorHandlingScenarios;

[SupportedOSPlatform("windows")]
public sealed class ExistingNativeModuleHandleScenario : INativeFunctionErrorHandlingScenario
{
    private const string ExistingNativeModuleName = "kernel32.dll";

    private readonly NativeModuleHandleRetriever _nativeModuleHandleRetriever;

    public ExistingNativeModuleHandleScenario(NativeModuleHandleRetriever nativeModuleHandleRetriever)
    {
        _nativeModuleHandleRetriever = nativeModuleHandleRetriever;
    }

    public string NativeFunctionErrorHandlingScenarioTitle => $"GetModuleHandleW для загруженного модуля {ExistingNativeModuleName}";

    public string ExecuteNativeFunctionErrorHandlingScenario()
    {
        var existingNativeModuleHandle = _nativeModuleHandleRetriever.RetrieveLoadedNativeModuleHandle(ExistingNativeModuleName);

        var existingNativeModuleHandleDescription = $"Получен дескриптор модуля 0x{existingNativeModuleHandle.ToInt64():X}";

        return existingNativeModuleHandleDescription;
    }
}
