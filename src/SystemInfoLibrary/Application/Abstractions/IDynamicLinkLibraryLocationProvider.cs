namespace Variant16.SystemInfoLibrary.Application.Abstractions;

public interface IDynamicLinkLibraryLocationProvider
{
    string GetManagedDynamicLinkLibraryLocation();

    string GetNativeDynamicLinkLibraryLocation();
}
