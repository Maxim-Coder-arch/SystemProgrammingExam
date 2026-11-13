using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.Application.Services;

public sealed class DynamicLinkLibraryComparisonService : IDynamicLinkLibraryComparisonService
{
    private readonly IDynamicLinkLibraryLocationProvider _dynamicLinkLibraryLocationProvider;

    private readonly IPortableExecutableFileInspector _portableExecutableFileInspector;

    private readonly IDynamicLinkLibraryComparisonCriteriaCatalog _dynamicLinkLibraryComparisonCriteriaCatalog;

    public DynamicLinkLibraryComparisonService(
        IDynamicLinkLibraryLocationProvider dynamicLinkLibraryLocationProvider,
        IPortableExecutableFileInspector portableExecutableFileInspector,
        IDynamicLinkLibraryComparisonCriteriaCatalog dynamicLinkLibraryComparisonCriteriaCatalog)
    {
        _dynamicLinkLibraryLocationProvider = dynamicLinkLibraryLocationProvider;
        _portableExecutableFileInspector = portableExecutableFileInspector;
        _dynamicLinkLibraryComparisonCriteriaCatalog = dynamicLinkLibraryComparisonCriteriaCatalog;
    }

    public DynamicLinkLibraryComparisonReport CompareManagedAndNativeDynamicLinkLibraries()
    {
        var managedDynamicLinkLibraryLocation = _dynamicLinkLibraryLocationProvider.GetManagedDynamicLinkLibraryLocation();
        var nativeDynamicLinkLibraryLocation = _dynamicLinkLibraryLocationProvider.GetNativeDynamicLinkLibraryLocation();

        var managedDynamicLinkLibraryInspectionResult =
            _portableExecutableFileInspector.InspectPortableExecutableFile(managedDynamicLinkLibraryLocation);

        var nativeDynamicLinkLibraryInspectionResult =
            _portableExecutableFileInspector.InspectPortableExecutableFile(nativeDynamicLinkLibraryLocation);

        var dynamicLinkLibraryComparisonCriteria =
            _dynamicLinkLibraryComparisonCriteriaCatalog.GetDynamicLinkLibraryComparisonCriteria();

        var dynamicLinkLibraryComparisonReport = new DynamicLinkLibraryComparisonReport(
            managedDynamicLinkLibraryInspectionResult,
            nativeDynamicLinkLibraryInspectionResult,
            dynamicLinkLibraryComparisonCriteria);

        return dynamicLinkLibraryComparisonReport;
    }
}
