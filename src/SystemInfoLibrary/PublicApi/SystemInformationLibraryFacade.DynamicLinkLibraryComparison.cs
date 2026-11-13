using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.PublicApi;

public sealed partial class SystemInformationLibraryFacade
{
    public DynamicLinkLibraryComparisonReport CompareManagedAndNativeDynamicLinkLibraries()
    {
        var dynamicLinkLibraryComparisonReport = _dynamicLinkLibraryComparisonService.CompareManagedAndNativeDynamicLinkLibraries();

        return dynamicLinkLibraryComparisonReport;
    }
}
