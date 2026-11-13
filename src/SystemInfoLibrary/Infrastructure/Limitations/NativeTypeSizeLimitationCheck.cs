using System.Runtime.InteropServices;
using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.Infrastructure.Limitations;

public sealed class NativeTypeSizeLimitationCheck : IWindowsApiLimitationCheck
{
    private const string NativeTypeSizeLimitationTitle = "Типы Windows API нужно сопоставлять точно";

    private const string NativeTypeSizeLimitationDescription =
        "DWORD всегда занимает 32 бита и описывается как uint, а HANDLE и указатели зависят от разрядности и описываются как IntPtr. " +
        "Если объявить HANDLE как int, в 64 битном процессе значение обрежется.";

    public WindowsApiLimitationInspectionResult InspectWindowsApiLimitation()
    {
        var doubleWordNativeTypeSizeInBytes = Marshal.SizeOf<uint>();
        var handleNativeTypeSizeInBytes = IntPtr.Size;

        var isHandleSizeDifferentFromDoubleWordSize = handleNativeTypeSizeInBytes != doubleWordNativeTypeSizeInBytes;

        var currentEnvironmentObservation =
            $"DWORD как uint занимает {doubleWordNativeTypeSizeInBytes} байта, HANDLE как IntPtr занимает {handleNativeTypeSizeInBytes} байт";

        var nativeTypeSizeLimitationInspectionResult = new WindowsApiLimitationInspectionResult(
            NativeTypeSizeLimitationTitle,
            NativeTypeSizeLimitationDescription,
            currentEnvironmentObservation,
            isHandleSizeDifferentFromDoubleWordSize);

        return nativeTypeSizeLimitationInspectionResult;
    }
}
