using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.Application.Services;

public sealed class WindowsApiLimitationInspector : IWindowsApiLimitationInspector
{
    private readonly IReadOnlyList<IWindowsApiLimitationCheck> _windowsApiLimitationChecks;

    public WindowsApiLimitationInspector(IReadOnlyList<IWindowsApiLimitationCheck> windowsApiLimitationChecks)
    {
        _windowsApiLimitationChecks = windowsApiLimitationChecks;
    }

    public IReadOnlyList<WindowsApiLimitationInspectionResult> InspectWindowsApiLimitations()
    {
        var windowsApiLimitationInspectionResults = _windowsApiLimitationChecks
            .Select(windowsApiLimitationCheck => windowsApiLimitationCheck.InspectWindowsApiLimitation())
            .ToList();

        return windowsApiLimitationInspectionResults;
    }
}
