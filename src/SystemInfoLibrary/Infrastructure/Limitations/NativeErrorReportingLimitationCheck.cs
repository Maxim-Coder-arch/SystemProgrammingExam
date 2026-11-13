using System.Runtime.Versioning;
using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Domain.Exceptions;
using Variant16.SystemInfoLibrary.Domain.Models;
using Variant16.SystemInfoLibrary.Infrastructure.Native;

namespace Variant16.SystemInfoLibrary.Infrastructure.Limitations;

[SupportedOSPlatform("windows")]
public sealed class NativeErrorReportingLimitationCheck : IWindowsApiLimitationCheck
{
    private const string NativeErrorReportingLimitationTitle = "Ошибки Windows API приходят кодом, а не исключением";

    private const string NativeErrorReportingLimitationDescription =
        "Функция сообщает об ошибке возвращаемым значением, а причину нужно получить через GetLastError. " +
        "В .NET код читается Marshal.GetLastPInvokeError сразу после вызова и только при SetLastError = true в DllImport.";

    private const string NotLoadedNativeModuleName = "variant16_limitation_check_module.dll";

    private readonly NativeModuleHandleRetriever _nativeModuleHandleRetriever;

    public NativeErrorReportingLimitationCheck(NativeModuleHandleRetriever nativeModuleHandleRetriever)
    {
        _nativeModuleHandleRetriever = nativeModuleHandleRetriever;
    }

    public WindowsApiLimitationInspectionResult InspectWindowsApiLimitation()
    {
        var currentEnvironmentObservation = ObserveNativeErrorReportingForNotLoadedModule();

        var nativeErrorReportingLimitationInspectionResult = new WindowsApiLimitationInspectionResult(
            NativeErrorReportingLimitationTitle,
            NativeErrorReportingLimitationDescription,
            currentEnvironmentObservation,
            true);

        return nativeErrorReportingLimitationInspectionResult;
    }

    private string ObserveNativeErrorReportingForNotLoadedModule()
    {
        try
        {
            _nativeModuleHandleRetriever.RetrieveLoadedNativeModuleHandle(NotLoadedNativeModuleName);

            return "GetModuleHandleW неожиданно нашел незагруженный модуль";
        }
        catch (NativeFunctionInvocationException nativeFunctionInvocationException)
        {
            var nativeErrorReportingObservation =
                $"GetModuleHandleW вернул 0, GetLastError вернул код {nativeFunctionInvocationException.NativeWin32ErrorCode}";

            return nativeErrorReportingObservation;
        }
    }
}
