using System.Reflection.PortableExecutable;
using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.Infrastructure.PortableExecutable;

public sealed class PortableExecutableFileInspector : IPortableExecutableFileInspector
{
    private const string UnavailablePortableExecutableValueDisplayText = "нет";

    private readonly ManagedAssemblyMetadataReadabilityChecker _managedAssemblyMetadataReadabilityChecker;

    public PortableExecutableFileInspector(ManagedAssemblyMetadataReadabilityChecker managedAssemblyMetadataReadabilityChecker)
    {
        _managedAssemblyMetadataReadabilityChecker = managedAssemblyMetadataReadabilityChecker;
    }

    public PortableExecutableFileInspectionResult InspectPortableExecutableFile(string inspectedFileLocation)
    {
        if (!File.Exists(inspectedFileLocation))
        {
            return CreateMissingFileInspectionResult(inspectedFileLocation);
        }

        var inspectedFileSizeInBytes = new FileInfo(inspectedFileLocation).Length;

        using var inspectedFileStream = File.OpenRead(inspectedFileLocation);
        using var portableExecutableReader = new PEReader(inspectedFileStream);

        var portableExecutableHeaders = portableExecutableReader.PEHeaders;
        var commonLanguageRuntimeHeader = portableExecutableHeaders.CorHeader;

        var commonLanguageRuntimeFlags = commonLanguageRuntimeHeader?.Flags.ToString()
            ?? UnavailablePortableExecutableValueDisplayText;

        var isReadableAsManagedAssembly = _managedAssemblyMetadataReadabilityChecker.IsFileReadableAsManagedAssembly(inspectedFileLocation);

        var portableExecutableFileInspectionResult = new PortableExecutableFileInspectionResult(
            inspectedFileLocation,
            true,
            inspectedFileSizeInBytes,
            portableExecutableHeaders.CoffHeader.Machine.ToString(),
            commonLanguageRuntimeHeader is not null,
            commonLanguageRuntimeFlags,
            isReadableAsManagedAssembly);

        return portableExecutableFileInspectionResult;
    }

    private static PortableExecutableFileInspectionResult CreateMissingFileInspectionResult(string inspectedFileLocation)
    {
        var missingFileInspectionResult = new PortableExecutableFileInspectionResult(
            inspectedFileLocation,
            false,
            0,
            UnavailablePortableExecutableValueDisplayText,
            false,
            UnavailablePortableExecutableValueDisplayText,
            false);

        return missingFileInspectionResult;
    }
}
