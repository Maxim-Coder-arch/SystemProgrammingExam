using System.Reflection;
using Variant16.SystemInfoLibrary.ConsoleApplication.Presentation;
using Variant16.SystemInfoLibrary.PublicApi;

namespace Variant16.SystemInfoLibrary.ConsoleApplication.DemonstrationSteps;

public sealed class LibraryProjectReferenceDemonstrationStep : IProjectDemonstrationStep
{
    private readonly IDemonstrationReportWriter _demonstrationReportWriter;

    public LibraryProjectReferenceDemonstrationStep(IDemonstrationReportWriter demonstrationReportWriter)
    {
        _demonstrationReportWriter = demonstrationReportWriter;
    }

    public string ProjectDemonstrationStepTitle => "Задания 1 и 2. Библиотека классов и ProjectReference";

    public Task ExecuteProjectDemonstrationStepAsync()
    {
        var systemInformationLibraryAssembly = typeof(SystemInformationLibraryFacade).Assembly;
        var systemInformationLibraryAssemblyName = systemInformationLibraryAssembly.GetName();
        var consumerApplicationAssembly = Assembly.GetExecutingAssembly();

        var isSystemInformationLibraryReferencedByConsumerApplication = consumerApplicationAssembly
            .GetReferencedAssemblies()
            .Any(referencedAssemblyName => AssemblyName.ReferenceMatchesDefinition(
                referencedAssemblyName,
                systemInformationLibraryAssemblyName));

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Приложение потребитель",
            consumerApplicationAssembly.GetName().Name ?? string.Empty);

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Подключенная библиотека",
            systemInformationLibraryAssemblyName.Name ?? string.Empty);

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Файл библиотеки",
            systemInformationLibraryAssembly.Location);

        _demonstrationReportWriter.WriteDemonstrationLabeledValue(
            "Библиотека есть в ссылках сборки потребителя",
            BooleanDisplayTextFormatter.FormatBooleanAsDisplayText(isSystemInformationLibraryReferencedByConsumerApplication));

        return Task.CompletedTask;
    }
}
