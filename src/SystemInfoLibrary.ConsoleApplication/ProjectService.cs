namespace Variant16.SystemInfoLibrary.ConsoleApplication;

public sealed class ProjectService
{
    public async Task RunAsync()
    {
        Console.WriteLine("Решение разделено на библиотеку и консольное приложение потребитель.");

        await Task.CompletedTask;
    }
}
