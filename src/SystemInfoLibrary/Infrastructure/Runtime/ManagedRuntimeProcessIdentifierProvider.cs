using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.Infrastructure.Runtime;

public sealed class ManagedRuntimeProcessIdentifierProvider : IProcessIdentifierProvider
{
    public ProcessIdentifierInformation GetCurrentProcessIdentifierInformation()
    {
        var managedRuntimeProcessIdentifierValue = (uint)Environment.ProcessId;

        var managedRuntimeProcessIdentifierInformation = new ProcessIdentifierInformation(
            managedRuntimeProcessIdentifierValue,
            ProcessIdentifierRetrievalSource.ManagedRuntimeEnvironment);

        return managedRuntimeProcessIdentifierInformation;
    }
}
