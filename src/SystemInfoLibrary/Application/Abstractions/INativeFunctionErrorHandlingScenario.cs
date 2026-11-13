namespace Variant16.SystemInfoLibrary.Application.Abstractions;

public interface INativeFunctionErrorHandlingScenario
{
    string NativeFunctionErrorHandlingScenarioTitle { get; }

    string ExecuteNativeFunctionErrorHandlingScenario();
}
