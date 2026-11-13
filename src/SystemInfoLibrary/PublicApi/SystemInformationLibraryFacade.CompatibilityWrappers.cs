namespace Variant16.SystemInfoLibrary.PublicApi;

public sealed partial class SystemInformationLibraryFacade
{
    private const string GetCurrentProcessIdObsoleteMessage =
        "Метод из версии 1.x оставлен для совместимости. Используйте GetCurrentProcessIdentifierInformation.";

    [Obsolete(GetCurrentProcessIdObsoleteMessage)]
    public int GetCurrentProcessId()
    {
        var currentProcessIdentifierInformation = GetCurrentProcessIdentifierInformation();
        var legacyCurrentProcessIdentifierValue = checked((int)currentProcessIdentifierInformation.ProcessIdentifierValue);

        return legacyCurrentProcessIdentifierValue;
    }
}
