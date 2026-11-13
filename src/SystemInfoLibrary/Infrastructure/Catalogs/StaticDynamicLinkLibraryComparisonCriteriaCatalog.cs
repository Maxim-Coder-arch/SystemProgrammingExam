using Variant16.SystemInfoLibrary.Application.Abstractions;
using Variant16.SystemInfoLibrary.Domain.Models;

namespace Variant16.SystemInfoLibrary.Infrastructure.Catalogs;

public sealed class StaticDynamicLinkLibraryComparisonCriteriaCatalog : IDynamicLinkLibraryComparisonCriteriaCatalog
{
    private static readonly IReadOnlyList<DynamicLinkLibraryComparisonCriterion> DynamicLinkLibraryComparisonCriteria =
    [
        new DynamicLinkLibraryComparisonCriterion(
            "Содержимое",
            "IL код и метаданные CLR, машинный код создает JIT во время выполнения",
            "Готовый машинный код под конкретную архитектуру процессора"),

        new DynamicLinkLibraryComparisonCriterion(
            "Подключение",
            "ProjectReference или Reference, типы и сигнатуры видны компилятору",
            "DllImport, сигнатуру и сопоставление типов описывает программист"),

        new DynamicLinkLibraryComparisonCriterion(
            "Разрядность",
            "Сборка AnyCPU работает и в 32, и в 64 битном процессе",
            "Собрана под одну архитектуру и должна совпадать с разрядностью процесса"),

        new DynamicLinkLibraryComparisonCriterion(
            "Ошибки",
            "Исключения .NET со стеком вызовов",
            "Коды возврата и GetLastError, исключений нет"),

        new DynamicLinkLibraryComparisonCriterion(
            "Память и ресурсы",
            "Объекты освобождает сборщик мусора",
            "Ресурсы освобождаются вручную через CloseHandle, FreeLibrary и аналоги"),

        new DynamicLinkLibraryComparisonCriterion(
            "Версии",
            "AssemblyVersion участвует в привязке сборок, FileVersion описывает файл",
            "Есть только ресурс VERSIONINFO, загрузчик версию не проверяет")
    ];

    public IReadOnlyList<DynamicLinkLibraryComparisonCriterion> GetDynamicLinkLibraryComparisonCriteria()
    {
        return DynamicLinkLibraryComparisonCriteria;
    }
}
