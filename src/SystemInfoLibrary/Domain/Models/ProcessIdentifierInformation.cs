namespace Variant16.SystemInfoLibrary.Domain.Models;

public sealed record ProcessIdentifierInformation(
    uint ProcessIdentifierValue,
    ProcessIdentifierRetrievalSource ProcessIdentifierRetrievalSource);
