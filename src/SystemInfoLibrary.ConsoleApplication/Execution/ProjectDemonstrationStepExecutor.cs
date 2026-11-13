using Variant16.SystemInfoLibrary.ConsoleApplication.DemonstrationSteps;
using Variant16.SystemInfoLibrary.ConsoleApplication.Presentation;

namespace Variant16.SystemInfoLibrary.ConsoleApplication.Execution;

public sealed class ProjectDemonstrationStepExecutor
{
    private readonly IDemonstrationReportWriter _demonstrationReportWriter;

    public ProjectDemonstrationStepExecutor(IDemonstrationReportWriter demonstrationReportWriter)
    {
        _demonstrationReportWriter = demonstrationReportWriter;
    }

    public async Task ExecuteProjectDemonstrationStepSafelyAsync(IProjectDemonstrationStep projectDemonstrationStep)
    {
        _demonstrationReportWriter.WriteDemonstrationSectionTitle(projectDemonstrationStep.ProjectDemonstrationStepTitle);

        try
        {
            await projectDemonstrationStep.ExecuteProjectDemonstrationStepAsync();
        }
        catch (Exception projectDemonstrationStepException)
        {
            var projectDemonstrationStepErrorMessage =
                $"Шаг завершился с ошибкой {projectDemonstrationStepException.GetType().Name}: {projectDemonstrationStepException.Message}";

            _demonstrationReportWriter.WriteDemonstrationErrorMessage(projectDemonstrationStepErrorMessage);
        }
    }
}
