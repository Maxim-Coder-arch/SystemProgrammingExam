namespace Variant16.SystemInfoLibrary.ConsoleApplication.Presentation;

public interface IDemonstrationReportWriter
{
    void WriteDemonstrationSectionTitle(string demonstrationSectionTitle);

    void WriteDemonstrationLabeledValue(string demonstrationValueLabel, string demonstrationValueText);

    void WriteDemonstrationMessage(string demonstrationMessageText);

    void WriteDemonstrationErrorMessage(string demonstrationErrorMessageText);
}
