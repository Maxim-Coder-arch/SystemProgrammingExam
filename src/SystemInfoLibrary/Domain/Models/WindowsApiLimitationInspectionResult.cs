namespace Variant16.SystemInfoLibrary.Domain.Models;

public sealed record WindowsApiLimitationInspectionResult(
    string WindowsApiLimitationTitle,
    string WindowsApiLimitationDescription,
    string CurrentEnvironmentObservation,
    bool IsLimitationObservedInCurrentEnvironment);
