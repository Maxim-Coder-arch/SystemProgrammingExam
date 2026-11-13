using System.ComponentModel;
using System.Runtime.InteropServices;
using Variant16.SystemInfoLibrary.Domain.Exceptions;
using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.Infrastructure.Native;

internal static class NativeWin32LastErrorExceptionFactory
{
    internal static NativeFunctionInvocationException CreateExceptionFromLastNativeWin32Error(string nativeFunctionName)
    {
        var lastNativeWin32ErrorCode = Marshal.GetLastPInvokeError();
        var lastNativeWin32ErrorException = new Win32Exception(lastNativeWin32ErrorCode);

        var nativeFunctionInvocationException = new NativeFunctionInvocationException(
            nativeFunctionName,
            NativeFunctionFailureKind.NativeFunctionReturnedWin32Error,
            lastNativeWin32ErrorException.Message,
            lastNativeWin32ErrorCode,
            lastNativeWin32ErrorException);

        return nativeFunctionInvocationException;
    }
}
