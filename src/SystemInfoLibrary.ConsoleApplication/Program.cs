using System.Text;

namespace Variant16.SystemInfoLibrary.ConsoleApplication;

internal static class Program
{
    private const string ApplicationTitle = "Зачётный проект 16: Библиотека системной информации";

    private const int ApplicationTitleUnderlineLength = 64;

    private static async Task Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine(ApplicationTitle);
        Console.WriteLine(new string('=', ApplicationTitleUnderlineLength));

        var projectService = new ProjectService();

        await projectService.RunAsync();

        Console.WriteLine();
        Console.WriteLine("Нажмите Enter для завершения.");
        Console.ReadLine();
    }
}
