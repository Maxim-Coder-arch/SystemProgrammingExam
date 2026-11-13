using Variant16.SystemInfoLibrary.Domain.Exceptions;
using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.Infrastructure.Native;

public sealed class NativeFunctionInvocationGuard
{
    public TNativeFunctionResult InvokeNativeFunctionSafely<TNativeFunctionResult>(
        string nativeFunctionName,
        Func<TNativeFunctionResult> nativeFunctionInvocation)
    {
        try
        {
            var nativeFunctionResult = nativeFunctionInvocation();

            return nativeFunctionResult;
        }
        catch (DllNotFoundException nativeLibraryNotFoundException)
        {
            throw CreateNativeFunctionInvocationException(
                nativeFunctionName,
                NativeFunctionFailureKind.NativeLibraryNotFound,
                nativeLibraryNotFoundException);
        }
        catch (EntryPointNotFoundException nativeEntryPointNotFoundException)
        {
            throw CreateNativeFunctionInvocationException(
                nativeFunctionName,
                NativeFunctionFailureKind.NativeEntryPointNotFound,
                nativeEntryPointNotFoundException);
        }
        catch (BadImageFormatException nativeLibraryArchitectureMismatchException)
        {
            throw CreateNativeFunctionInvocationException(
                nativeFunctionName,
                NativeFunctionFailureKind.NativeLibraryArchitectureMismatch,
                nativeLibraryArchitectureMismatchException);
        }
    }

    private static NativeFunctionInvocationException CreateNativeFunctionInvocationException(
        string nativeFunctionName,
        NativeFunctionFailureKind nativeFunctionFailureKind,
        Exception nativeInteropException)
    {
        var nativeFunctionInvocationException = new NativeFunctionInvocationException(
            nativeFunctionName,
            nativeFunctionFailureKind,
            nativeInteropException.Message,
            null,
            nativeInteropException);

        return nativeFunctionInvocationException;
    }
}
