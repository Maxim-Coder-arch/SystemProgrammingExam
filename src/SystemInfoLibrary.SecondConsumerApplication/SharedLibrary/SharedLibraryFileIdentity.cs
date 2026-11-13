namespace Variant16.SystemInfoLibrary.SecondConsumerApplication.SharedLibrary;

public sealed record SharedLibraryFileIdentity(
    string SharedLibraryFileLocation,
    Guid SharedLibraryModuleVersionIdentifier,
    string SharedLibraryFileSha256Hash);
