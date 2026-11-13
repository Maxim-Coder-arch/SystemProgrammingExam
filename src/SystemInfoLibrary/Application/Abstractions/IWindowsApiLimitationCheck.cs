using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.Application.Abstractions;

public interface IWindowsApiLimitationCheck
{
    WindowsApiLimitationInspectionResult InspectWindowsApiLimitation();
}
