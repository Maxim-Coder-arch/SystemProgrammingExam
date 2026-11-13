using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.Domain.Exceptions;

public sealed class NativeFunctionInvocationException : Exception
{
    public NativeFunctionInvocationException(
        string nativeFunctionName,
        NativeFunctionFailureKind nativeFunctionFailureKind,
        string nativeFunctionFailureDescription,
        int? nativeWin32ErrorCode,
        Exception? nativeFunctionInnerException)
        : base(
            CreateNativeFunctionInvocationErrorMessage(nativeFunctionName, nativeFunctionFailureKind, nativeFunctionFailureDescription),
            nativeFunctionInnerException)
    {
        NativeFunctionName = nativeFunctionName;
        NativeFunctionFailureKind = nativeFunctionFailureKind;
        NativeWin32ErrorCode = nativeWin32ErrorCode;
    }

    public string NativeFunctionName { get; }

    public NativeFunctionFailureKind NativeFunctionFailureKind { get; }

    public int? NativeWin32ErrorCode { get; }

    private static string CreateNativeFunctionInvocationErrorMessage(
        string nativeFunctionName,
        NativeFunctionFailureKind nativeFunctionFailureKind,
        string nativeFunctionFailureDescription)
    {
        var nativeFunctionInvocationErrorMessage =
            $"Вызов нативной функции {nativeFunctionName} завершился ошибкой {nativeFunctionFailureKind}: {nativeFunctionFailureDescription}";

        return nativeFunctionInvocationErrorMessage;
    }
}
