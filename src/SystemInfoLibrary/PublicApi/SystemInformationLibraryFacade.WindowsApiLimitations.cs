using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.PublicApi;

public sealed partial class SystemInformationLibraryFacade
{
    public IReadOnlyList<WindowsApiLimitationInspectionResult> InspectWindowsApiLimitations()
    {
        var windowsApiLimitationInspectionResults = _windowsApiLimitationInspector.InspectWindowsApiLimitations();

        return windowsApiLimitationInspectionResults;
    }
}
