using System.Reflection;
using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.Infrastructure.Reflection;

public sealed class ReflectionAssemblyVersionInformationProvider : IAssemblyVersionInformationProvider
{
    private const string MissingAssemblyAttributeDisplayText = "не задана";

    public AssemblyVersionInformation GetAssemblyVersionInformation(Assembly inspectedAssembly)
    {
        var inspectedAssemblyName = inspectedAssembly.GetName();

        var inspectedAssemblyVersion = inspectedAssemblyName.Version?.ToString()
            ?? MissingAssemblyAttributeDisplayText;

        var inspectedAssemblyFileVersion = inspectedAssembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version
            ?? MissingAssemblyAttributeDisplayText;

        var inspectedAssemblyInformationalVersion = inspectedAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion
            ?? MissingAssemblyAttributeDisplayText;

        var assemblyVersionInformation = new AssemblyVersionInformation(
            inspectedAssemblyName.Name ?? MissingAssemblyAttributeDisplayText,
            inspectedAssemblyVersion,
            inspectedAssemblyFileVersion,
            inspectedAssemblyInformationalVersion,
            inspectedAssembly.Location);

        return assemblyVersionInformation;
    }
}
