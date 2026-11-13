using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.PublicApi;

public sealed partial class SystemInformationLibraryFacade
{
    public IReadOnlyList<NativeFunctionErrorHandlingScenarioResult> RunNativeFunctionErrorHandlingScenarios()
    {
        var nativeFunctionErrorHandlingScenarioResults =
            _nativeFunctionErrorHandlingScenarioRunner.RunNativeFunctionErrorHandlingScenarios();

        return nativeFunctionErrorHandlingScenarioResults;
    }
}
