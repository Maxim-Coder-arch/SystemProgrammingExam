namespace Variant16.SystemInfoLibrary.Domain.Models;

public enum NativeFunctionFailureKind
{
    NativeLibraryNotFound,

    NativeEntryPointNotFound,

    NativeLibraryArchitectureMismatch,

    NativeFunctionReturnedWin32Error
}
