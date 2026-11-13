using System.Reflection;
using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.PublicApi;

public sealed partial class SystemInformationLibraryFacade
{
    public AssemblyVersionInformation GetSystemInformationLibraryAssemblyVersionInformation()
    {
        var systemInformationLibraryAssembly = typeof(SystemInformationLibraryFacade).Assembly;

        var systemInformationLibraryAssemblyVersionInformation =
            _assemblyVersionInformationProvider.GetAssemblyVersionInformation(systemInformationLibraryAssembly);

        return systemInformationLibraryAssemblyVersionInformation;
    }

    public AssemblyVersionInformation GetAssemblyVersionInformation(Assembly inspectedAssembly)
    {
        var inspectedAssemblyVersionInformation = _assemblyVersionInformationProvider.GetAssemblyVersionInformation(inspectedAssembly);

        return inspectedAssemblyVersionInformation;
    }
}
