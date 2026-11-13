using Variant16.SystemInfoLibrary.Composition;
using Variant16.SystemInfoLibrary.PublicApi;
using Variant16.SystemInfoLibrary.SecondConsumerApplication.Presentation;
using Variant16.SystemInfoLibrary.SecondConsumerApplication.SharedLibrary;

namespace Variant16.SystemInfoLibrary.SecondConsumerApplication;

public sealed class SecondConsumerApplicationService
{
    private const string SecondConsumerApplicationTitle = "Задание 4. Второе приложение использует ту же DLL";

    private readonly SystemInformationLibraryFacade _systemInformationLibraryFacade;

    private readonly SharedLibraryFileIdentityCalculator _sharedLibraryFileIdentityCalculator;

    private readonly SecondConsumerConsoleOutputWriter _secondConsumerConsoleOutputWriter;

    public SecondConsumerApplicationService()
    {
        _systemInformationLibraryFacade = SystemInformationLibraryFacadeFactory.CreateDefaultSystemInformationLibraryFacade();
        _sharedLibraryFileIdentityCalculator = new SharedLibraryFileIdentityCalculator();
        _secondConsumerConsoleOutputWriter = new SecondConsumerConsoleOutputWriter();
    }

    public void RunSecondConsumerApplication()
    {
        _secondConsumerConsoleOutputWriter.WriteSecondConsumerTitle(SecondConsumerApplicationTitle);

        WriteSharedLibraryFileIdentity();
        WriteSharedLibraryVersion();
        WriteCurrentProcessIdentifier();
    }

    private void WriteSharedLibraryFileIdentity()
    {
        var sharedLibraryAssembly = typeof(SystemInformationLibraryFacade).Assembly;
        var sharedLibraryFileIdentity = _sharedLibraryFileIdentityCalculator.CalculateSharedLibraryFileIdentity(sharedLibraryAssembly);

        _secondConsumerConsoleOutputWriter.WriteSecondConsumerLabeledValue(
            "Файл библиотеки",
            sharedLibraryFileIdentity.SharedLibraryFileLocation);

        _secondConsumerConsoleOutputWriter.WriteSecondConsumerLabeledValue(
            "MVID библиотеки",
            sharedLibraryFileIdentity.SharedLibraryModuleVersionIdentifier.ToString());

        _secondConsumerConsoleOutputWriter.WriteSecondConsumerLabeledValue(
            "SHA256 файла библиотеки",
            sharedLibraryFileIdentity.SharedLibraryFileSha256Hash);
    }

    private void WriteSharedLibraryVersion()
    {
        var sharedLibraryAssemblyVersionInformation =
            _systemInformationLibraryFacade.GetSystemInformationLibraryAssemblyVersionInformation();

        _secondConsumerConsoleOutputWriter.WriteSecondConsumerLabeledValue(
            "AssemblyVersion библиотеки",
            sharedLibraryAssemblyVersionInformation.AssemblyVersion);

        _secondConsumerConsoleOutputWriter.WriteSecondConsumerLabeledValue(
            "FileVersion библиотеки",
            sharedLibraryAssemblyVersionInformation.AssemblyFileVersion);
    }

    private void WriteCurrentProcessIdentifier()
    {
        var currentProcessIdentifierInformation = _systemInformationLibraryFacade.GetCurrentProcessIdentifierInformation();

        _secondConsumerConsoleOutputWriter.WriteSecondConsumerLabeledValue(
            "PID второго приложения",
            currentProcessIdentifierInformation.ProcessIdentifierValue.ToString());

        _secondConsumerConsoleOutputWriter.WriteSecondConsumerLabeledValue(
            "Источник PID",
            currentProcessIdentifierInformation.ProcessIdentifierRetrievalSource.ToString());
    }
}
