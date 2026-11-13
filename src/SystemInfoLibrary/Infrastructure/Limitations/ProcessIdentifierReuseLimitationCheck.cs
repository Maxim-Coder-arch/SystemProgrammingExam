using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.Infrastructure.Limitations;

public sealed class ProcessIdentifierReuseLimitationCheck : IWindowsApiLimitationCheck
{
    private const string ProcessIdentifierReuseLimitationTitle = "PID уникален только пока процесс жив";

    private const string ProcessIdentifierReuseLimitationDescription =
        "GetCurrentProcessId не сообщает об ошибках и возвращает DWORD, но система переиспользует номер после завершения процесса. " +
        "Хранить PID как постоянный идентификатор нельзя, а для работы с чужим процессом нужен OpenProcess и права доступа.";

    private readonly IProcessIdentifierProvider _processIdentifierProvider;

    public ProcessIdentifierReuseLimitationCheck(IProcessIdentifierProvider processIdentifierProvider)
    {
        _processIdentifierProvider = processIdentifierProvider;
    }

    public WindowsApiLimitationInspectionResult InspectWindowsApiLimitation()
    {
        var currentProcessIdentifierInformation = _processIdentifierProvider.GetCurrentProcessIdentifierInformation();

        var currentEnvironmentObservation =
            $"Текущий PID {currentProcessIdentifierInformation.ProcessIdentifierValue} " +
            $"получен через {currentProcessIdentifierInformation.ProcessIdentifierRetrievalSource}";

        var processIdentifierReuseLimitationInspectionResult = new WindowsApiLimitationInspectionResult(
            ProcessIdentifierReuseLimitationTitle,
            ProcessIdentifierReuseLimitationDescription,
            currentEnvironmentObservation,
            true);

        return processIdentifierReuseLimitationInspectionResult;
    }
}
