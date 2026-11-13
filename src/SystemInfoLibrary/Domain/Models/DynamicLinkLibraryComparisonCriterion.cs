namespace Variant16.SystemInfoLibrary.Domain.Models;

public sealed record DynamicLinkLibraryComparisonCriterion(
    string ComparisonCriterionTitle,
    string ManagedDynamicLinkLibraryCharacteristic,
    string NativeDynamicLinkLibraryCharacteristic);
