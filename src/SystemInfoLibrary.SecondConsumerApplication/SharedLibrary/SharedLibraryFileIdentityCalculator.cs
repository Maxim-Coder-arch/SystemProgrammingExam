using System.Reflection;
using System.Security.Cryptography;

namespace Variant16.SystemInfoLibrary.SecondConsumerApplication.SharedLibrary;

public sealed class SharedLibraryFileIdentityCalculator
{
    public SharedLibraryFileIdentity CalculateSharedLibraryFileIdentity(Assembly sharedLibraryAssembly)
    {
        var sharedLibraryFileLocation = sharedLibraryAssembly.Location;
        var sharedLibraryModuleVersionIdentifier = sharedLibraryAssembly.ManifestModule.ModuleVersionId;
        var sharedLibraryFileSha256Hash = CalculateSharedLibraryFileSha256Hash(sharedLibraryFileLocation);

        var sharedLibraryFileIdentity = new SharedLibraryFileIdentity(
            sharedLibraryFileLocation,
            sharedLibraryModuleVersionIdentifier,
            sharedLibraryFileSha256Hash);

        return sharedLibraryFileIdentity;
    }

    private static string CalculateSharedLibraryFileSha256Hash(string sharedLibraryFileLocation)
    {
        using var sharedLibraryFileStream = File.OpenRead(sharedLibraryFileLocation);

        var sharedLibraryFileSha256HashBytes = SHA256.HashData(sharedLibraryFileStream);
        var sharedLibraryFileSha256Hash = Convert.ToHexString(sharedLibraryFileSha256HashBytes);

        return sharedLibraryFileSha256Hash;
    }
}
