namespace Variant16.SystemInfoLibrary.Domain.Models;

public sealed record AssemblyVersionInformation(
    string AssemblyDisplayName,
    string AssemblyVersion,
    string AssemblyFileVersion,
    string AssemblyInformationalVersion,
    string AssemblyFileLocation);
