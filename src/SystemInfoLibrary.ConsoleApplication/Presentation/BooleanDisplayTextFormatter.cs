namespace Variant16.SystemInfoLibrary.ConsoleApplication.Presentation;

public static class BooleanDisplayTextFormatter
{
    private const string PositiveBooleanDisplayText = "да";

    private const string NegativeBooleanDisplayText = "нет";

    public static string FormatBooleanAsDisplayText(bool booleanValue)
    {
        var booleanDisplayText = booleanValue
            ? PositiveBooleanDisplayText
            : NegativeBooleanDisplayText;

        return booleanDisplayText;
    }
}
