using Variant16.SystemInfoLibrary.ConsoleApplication.DemonstrationSteps;
using Variant16.SystemInfoLibrary.ConsoleApplication.Presentation;
using Variant16.SystemInfoLibrary.PublicApi;

namespace Variant16.SystemInfoLibrary.ConsoleApplication.Composition;

public sealed class ProjectDemonstrationStepsFactory
{
    private readonly SystemInformationLibraryFacade _systemInformationLibraryFacade;

    private readonly IDemonstrationReportWriter _demonstrationReportWriter;

    public ProjectDemonstrationStepsFactory(
        SystemInformationLibraryFacade systemInformationLibraryFacade,
        IDemonstrationReportWriter demonstrationReportWriter)
    {
        _systemInformationLibraryFacade = systemInformationLibraryFacade;
        _demonstrationReportWriter = demonstrationReportWriter;
    }

    public IReadOnlyList<IProjectDemonstrationStep> CreateProjectDemonstrationSteps()
    {
        var projectDemonstrationSteps = new List<IProjectDemonstrationStep>
        {
            new LibraryProjectReferenceDemonstrationStep(_demonstrationReportWriter),
            new LibraryPublicMethodsDemonstrationStep(_systemInformationLibraryFacade, _demonstrationReportWriter),
            new NativeProcessIdentifierDemonstrationStep(_systemInformationLibraryFacade, _demonstrationReportWriter),
            new WindowsApiLimitationsDemonstrationStep(_systemInformationLibraryFacade, _demonstrationReportWriter),
            new NativeFunctionErrorHandlingDemonstrationStep(_systemInformationLibraryFacade, _demonstrationReportWriter),
            new AssemblyVersionsDemonstrationStep(_systemInformationLibraryFacade, _demonstrationReportWriter),
            new CompatibilityWrapperDemonstrationStep(_systemInformationLibraryFacade, _demonstrationReportWriter)
        };

        return projectDemonstrationSteps;
    }
}
