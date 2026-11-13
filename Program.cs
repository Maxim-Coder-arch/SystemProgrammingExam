using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Channels;

namespace Variant16;

internal static class Program
{
    private static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Зачётный проект 16: Библиотека системной информации");
        Console.WriteLine(new string('=', 64));

        // Стартовый сценарий нужен для проверки структуры проекта.
        // Реализацию индивидуальных требований выполняйте в ProjectService.
        var service = new ProjectService();
        await service.RunAsync();

        Console.WriteLine();
        Console.WriteLine("Нажмите Enter для завершения.");
        Console.ReadLine();
    }
}

public sealed class ProjectService
{
    public async Task RunAsync()
    {
        // TODO: перенесите предметную логику в отдельные методы и классы.
        // TODO: не размещайте весь проект в Main.
        // TODO 1: Создать Class Library и консольное приложение-потребитель.
        // TODO 2: Подключить библиотеку через ProjectReference.
        // TODO 3: Добавить в библиотеку два публичных метода.
        // TODO 4: Использовать одну DLL из второго приложения.
        // TODO 5: Получить PID через P/Invoke GetCurrentProcessId.
        // TODO 6: Проверить и описать ограничения Windows API.
        // TODO 7: Обработать ошибку вызова нативной функции.

        // TODO 8: Добавить AssemblyVersion/FileVersion и вывести их.
        // TODO 9: Добавить совместимый метод-обёртку при изменении API.
        // TODO 10: Сравнить управляемую DLL и нативную DLL.

        Console.WriteLine("Стартовый проект собран. Реализуйте задания варианта.");
        await Task.CompletedTask;
    }
}
