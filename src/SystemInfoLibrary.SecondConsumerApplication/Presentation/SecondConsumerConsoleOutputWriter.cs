namespace Variant16.SystemInfoLibrary.SecondConsumerApplication.Presentation;

public sealed class SecondConsumerConsoleOutputWriter
{
    private const string SecondConsumerLabeledValueIndentation = "  ";

    public void WriteSecondConsumerTitle(string secondConsumerTitle)
    {
        var secondConsumerTitleUnderline = new string('=', secondConsumerTitle.Length);

        Console.WriteLine(secondConsumerTitle);
        Console.WriteLine(secondConsumerTitleUnderline);
    }

    public void WriteSecondConsumerLabeledValue(string secondConsumerValueLabel, string secondConsumerValueText)
    {
        var secondConsumerLabeledValueLine =
            $"{SecondConsumerLabeledValueIndentation}{secondConsumerValueLabel}: {secondConsumerValueText}";

        Console.WriteLine(secondConsumerLabeledValueLine);
    }
}
