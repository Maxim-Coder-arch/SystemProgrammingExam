using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Infrastructure.Native;
using Variant16.SystemInfoLibrary.Infrastructure.Native.ErrorHandlingScenarios;

namespace Variant16.SystemInfoLibrary.Composition;

internal static class NativeFunctionErrorHandlingScenariosFactory
{
    internal static IReadOnlyList<INativeFunctionErrorHandlingScenario> CreateNativeFunctionErrorHandlingScenarios(
        NativeFunctionInvocationGuard nativeFunctionInvocationGuard)
    {
        if (!OperatingSystem.IsWindows())
        {
            return Array.Empty<INativeFunctionErrorHandlingScenario>();
        }

        var nativeModuleHandleRetriever = new NativeModuleHandleRetriever(nativeFunctionInvocationGuard);

        var nativeFunctionErrorHandlingScenarios = new List<INativeFunctionErrorHandlingScenario>
        {
            new ExistingNativeModuleHandleScenario(nativeModuleHandleRetriever),
            new MissingNativeModuleHandleScenario(nativeModuleHandleRetriever),
            new MissingNativeEntryPointScenario(nativeFunctionInvocationGuard),
            new MissingNativeLibraryScenario(nativeFunctionInvocationGuard)
        };

        return nativeFunctionErrorHandlingScenarios;
    }
}
