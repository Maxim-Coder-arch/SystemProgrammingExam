using System.Reflection;
using Variant16.SystemInfoLibrary.ConsoleApplication.Presentation;
using Variant16.SystemInfoLibrary.Domain.Models;
using Variant16.SystemInfoLibrary.PublicApi;

namespace Variant16.SystemInfoLibrary.ConsoleApplication.DemonstrationSteps;

public sealed class AssemblyVersionsDemonstrationStep : IProjectDemonstrationStep
{
    private readonly SystemInformationLibraryFacade _systemInformationLibraryFacade;

    private readonly IDemonstrationReportWriter _demonstrationReportWriter;

    public AssemblyVersionsDemonstrationStep(
        SystemInformationLibraryFacade systemInformationLibraryFacade,
        IDemonstrationReportWriter demonstrationReportWriter)
    {
        _systemInformationLibraryFacade = systemInformationLibraryFacade;
        _demonstrationReportWriter = demonstrationReportWriter;
    }

    public string ProjectDemonstrationStepTitle => "Задание 8. AssemblyVersion и FileVersion";

    public Task ExecuteProjectDemonstrationStepAsync()
    {
        var systemInformationLibraryAssemblyVersionInformation =
            _systemInformationLibraryFacade.GetSystemInformationLibraryAssemblyVersionInformation();

        var consumerApplicationAssemblyVersionInformation =
            _systemInformationLibraryFacade.GetAssemblyVersionInformation(Assembly.GetExecutingAssembly());

        WriteAssemblyVersionInformation(systemInformationLibraryAssemblyVersionInformation);
        WriteAssemblyVersionInformation(consumerApplicationAssemblyVersionInformation);

        return Task.CompletedTask;
    }

    private void WriteAssemblyVersionInformation(AssemblyVersionInformation assemblyVersionInformation)
    {
        _demonstrationReportWriter.WriteDemonstrationMessage($"Сборка {assemblyVersionInformation.AssemblyDisplayName}");

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "AssemblyVersion",
            assemblyVersionInformation.AssemblyVersion);

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "FileVersion",
            assemblyVersionInformation.AssemblyFileVersion);

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "InformationalVersion",
            assemblyVersionInformation.AssemblyInformationalVersion);

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Файл",
            assemblyVersionInformation.AssemblyFileLocation);
    }
}
