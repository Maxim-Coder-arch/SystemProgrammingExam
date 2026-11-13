using System.Reflection;

namespace Variant16.SystemInfoLibrary.Infrastructure.PortableExecutable;

public sealed class ManagedAssemblyMetadataReadabilityChecker
{
    public bool IsFileReadableAsManagedAssembly(string inspectedFileLocation)
    {
        try
        {
            AssemblyName.GetAssemblyName(inspectedFileLocation);

            return true;
        }
        catch (BadImageFormatException)
        {
            return false;
        }
    }
}
