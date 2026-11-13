namespace Variant16.SystemInfoLibrary.ConsoleApplication.Presentation;

public sealed class ConsoleDemonstrationReportWriter : IDemonstrationReportWriter
{
    private const char DemonstrationSectionTitleUnderlineCharacter = '-';

    private const string DemonstrationLabeledValueIndentation = "  ";

    private const string DemonstrationErrorMessagePrefix = "  [ошибка] ";

    public void WriteDemonstrationSectionTitle(string demonstrationSectionTitle)
    {
        var demonstrationSectionTitleUnderline = new string(
            DemonstrationSectionTitleUnderlineCharacter,
            demonstrationSectionTitle.Length);

        Console.WriteLine();
        Console.WriteLine(demonstrationSectionTitle);
        Console.WriteLine(demonstrationSectionTitleUnderline);
    }

    public void WriteDemonstrationLabeledValue(string demonstrationValueLabel, string demonstrationValueText)
    {
        var demonstrationLabeledValueLine = $"{DemonstrationLabeledValueIndentation}{demonstrationValueLabel}: {demonstrationValueText}";

        Console.WriteLine(demonstrationLabeledValueLine);
    }

    public void WriteDemonstrationMessage(string demonstrationMessageText)
    {
        var demonstrationMessageLine = $"{DemonstrationLabeledValueIndentation}{demonstrationMessageText}";

        Console.WriteLine(demonstrationMessageLine);
    }

    public void WriteDemonstrationErrorMessage(string demonstrationErrorMessageText)
    {
        var previousConsoleForegroundColor = Console.ForegroundColor;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{DemonstrationErrorMessagePrefix}{demonstrationErrorMessageText}");
        Console.ForegroundColor = previousConsoleForegroundColor;
    }
}
