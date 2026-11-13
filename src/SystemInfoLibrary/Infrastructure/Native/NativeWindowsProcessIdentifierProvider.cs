using System.Runtime.Versioning;
using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.Infrastructure.Native;

[SupportedOSPlatform("windows")]
public sealed class NativeWindowsProcessIdentifierProvider : IProcessIdentifierProvider
{
    private const string GetCurrentProcessIdNativeFunctionName = "GetCurrentProcessId";

    private readonly NativeFunctionInvocationGuard _nativeFunctionInvocationGuard;

    public NativeWindowsProcessIdentifierProvider(NativeFunctionInvocationGuard nativeFunctionInvocationGuard)
    {
        _nativeFunctionInvocationGuard = nativeFunctionInvocationGuard;
    }

    public ProcessIdentifierInformation GetCurrentProcessIdentifierInformation()
    {
        var nativeProcessIdentifierValue = _nativeFunctionInvocationGuard.InvokeNativeFunctionSafely(
            GetCurrentProcessIdNativeFunctionName,
            Kernel32NativeMethods.GetCurrentProcessId);

        var nativeProcessIdentifierInformation = new ProcessIdentifierInformation(
            nativeProcessIdentifierValue,
            ProcessIdentifierRetrievalSource.NativeWindowsApiFunction);

        return nativeProcessIdentifierInformation;
    }
}
