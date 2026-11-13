namespace Variant16.SystemInfoLibrary.Domain.Models;

public sealed record PortableExecutableFileInspectionResult(
    string InspectedFileLocation,
    bool IsInspectedFileFound,
    long InspectedFileSizeInBytes,
    string PortableExecutableMachineType,
    bool ContainsCommonLanguageRuntimeHeader,
    string CommonLanguageRuntimeFlags,
    bool IsReadableAsManagedAssembly);
