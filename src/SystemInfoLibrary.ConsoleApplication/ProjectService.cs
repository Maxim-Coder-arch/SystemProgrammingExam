using Variant16.SystemInfoLibrary.Composition;
using Variant16.SystemInfoLibrary.ConsoleApplication.Composition;
using Variant16.SystemInfoLibrary.ConsoleApplication.Execution;
using Variant16.SystemInfoLibrary.ConsoleApplication.Presentation;

namespace Variant16.SystemInfoLibrary.ConsoleApplication;

public sealed class ProjectService
{
    private readonly ProjectDemonstrationStepsFactory _projectDemonstrationStepsFactory;

    private readonly ProjectDemonstrationStepExecutor _projectDemonstrationStepExecutor;

    public ProjectService()
    {
        var systemInformationLibraryFacade = SystemInformationLibraryFacadeFactory.CreateDefaultSystemInformationLibraryFacade();
        var demonstrationReportWriter = new ConsoleDemonstrationReportWriter();

        _projectDemonstrationStepsFactory = new ProjectDemonstrationStepsFactory(
            systemInformationLibraryFacade,
            demonstrationReportWriter);

        _projectDemonstrationStepExecutor = new ProjectDemonstrationStepExecutor(demonstrationReportWriter);
    }

    public async Task RunAsync()
    {
        var projectDemonstrationSteps = _projectDemonstrationStepsFactory.CreateProjectDemonstrationSteps();

        foreach (var projectDemonstrationStep in projectDemonstrationSteps)
        {
            await _projectDemonstrationStepExecutor.ExecuteProjectDemonstrationStepSafelyAsync(projectDemonstrationStep);
        }
    }
}
