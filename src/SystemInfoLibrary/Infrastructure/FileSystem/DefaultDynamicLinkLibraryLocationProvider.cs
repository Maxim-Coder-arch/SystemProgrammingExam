using Variant16.SystemInfoLibrary.Application.Abstractions;

namespace Variant16.SystemInfoLibrary.Infrastructure.FileSystem;

public sealed class DefaultDynamicLinkLibraryLocationProvider : IDynamicLinkLibraryLocationProvider
{
    private const string NativeKernel32DynamicLinkLibraryFileName = "kernel32.dll";

    public string GetManagedDynamicLinkLibraryLocation()
    {
        var managedDynamicLinkLibraryLocation = typeof(DefaultDynamicLinkLibraryLocationProvider).Assembly.Location;

        return managedDynamicLinkLibraryLocation;
    }

    public string GetNativeDynamicLinkLibraryLocation()
    {
        var nativeDynamicLinkLibraryLocation = Path.Combine(
            Environment.SystemDirectory,
            NativeKernel32DynamicLinkLibraryFileName);

        return nativeDynamicLinkLibraryLocation;
    }
}
