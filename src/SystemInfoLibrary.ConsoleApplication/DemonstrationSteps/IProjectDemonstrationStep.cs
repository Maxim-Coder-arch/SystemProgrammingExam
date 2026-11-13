namespace Variant16.SystemInfoLibrary.ConsoleApplication.DemonstrationSteps;

public interface IProjectDemonstrationStep
{
    string ProjectDemonstrationStepTitle { get; }

    Task ExecuteProjectDemonstrationStepAsync();
}
