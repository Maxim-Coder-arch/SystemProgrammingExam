using System.Runtime.Versioning;

namespace Variant16.SystemInfoLibrary.Infrastructure.Native;

[SupportedOSPlatform("windows")]
public sealed class NativeModuleHandleRetriever
{
    private const string GetModuleHandleNativeFunctionName = "GetModuleHandleW";

    private readonly NativeFunctionInvocationGuard _nativeFunctionInvocationGuard;

    public NativeModuleHandleRetriever(NativeFunctionInvocationGuard nativeFunctionInvocationGuard)
    {
        _nativeFunctionInvocationGuard = nativeFunctionInvocationGuard;
    }

    public IntPtr RetrieveLoadedNativeModuleHandle(string nativeModuleName)
    {
        var loadedNativeModuleHandle = _nativeFunctionInvocationGuard.InvokeNativeFunctionSafely(
            GetModuleHandleNativeFunctionName,
            () => Kernel32NativeMethods.GetModuleHandleW(nativeModuleName));

        if (loadedNativeModuleHandle == IntPtr.Zero)
        {
            throw NativeWin32LastErrorExceptionFactory.CreateExceptionFromLastNativeWin32Error(GetModuleHandleNativeFunctionName);
        }

        return loadedNativeModuleHandle;
    }
}
