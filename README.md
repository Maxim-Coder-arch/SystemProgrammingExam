# Вариант 16. Библиотека системной информации

**Покрываемые темы:** Class Library, ProjectReference, P/Invoke, типы, разрядность

## Состав решения

| Проект | Тип | Назначение |
|---|---|---|
| `src/SystemInfoLibrary` | Class Library, `net9.0` | Библиотека системной информации: PID через P/Invoke, сведения о платформе, ограничения Windows API, версии сборок, сравнение DLL |
| `src/SystemInfoLibrary.ConsoleApplication` | Консольное приложение | Основной потребитель. Подключает библиотеку через `ProjectReference` и по шагам показывает все задания |
| `src/SystemInfoLibrary.SecondConsumerApplication` | Консольное приложение | Второй потребитель. Подключает уже собранный файл `SystemInfoLibrary.dll` через `Reference` + `HintPath` |

## Архитектура библиотеки

Слои внутри `SystemInfoLibrary` зависят только «внутрь»:

```
PublicApi        SystemInformationLibraryFacade — единственная точка входа для потребителей
   │
Application      Abstractions (интерфейсы) и Services (сценарии, инспекторы, сравнение DLL)
   │
Domain           Models (неизменяемые record) и Exceptions (NativeFunctionInvocationException)
   ▲
Infrastructure   Native (P/Invoke kernel32), Runtime, Reflection, PortableExecutable,
                 Limitations, FileSystem, Catalogs — реализации интерфейсов Application
   │
Composition      Фабрики, которые собирают реализации и отдают готовый фасад
```

- Domain ничего не знает о Windows, P/Invoke и консоли.
- Application описывает контракты (`IProcessIdentifierProvider`, `IWindowsApiLimitationCheck`, …) и работает только с ними.
- Infrastructure содержит всё платформенно зависимое. Классы с вызовами `kernel32.dll` помечены `[SupportedOSPlatform("windows")]`, а Composition создаёт их только под `OperatingSystem.IsWindows()`.
- Фасад разделён на `partial`-файлы по функциональности: основной, обработка нативных ошибок, ограничения Windows API, версии сборок, совместимые обёртки, сравнение DLL.

Консольное приложение устроено так же: `Program` → `ProjectService` → список шагов `IProjectDemonstrationStep` (по одному классу на задание) → `ProjectDemonstrationStepExecutor`, который ловит исключение шага и выводит его, не прерывая остальные шаги. Вывод отделён интерфейсом `IDemonstrationReportWriter`.

## Где реализовано каждое задание

| № | Задание | Реализация |
|---|---|---|
| 1 | Class Library и консольное приложение потребитель | `src/SystemInfoLibrary`, `src/SystemInfoLibrary.ConsoleApplication` |
| 2 | Подключение через ProjectReference | `SystemInfoLibrary.ConsoleApplication.csproj`, проверка — `LibraryProjectReferenceDemonstrationStep` |
| 3 | Два публичных метода | `SystemInformationLibraryFacade.GetCurrentProcessIdentifierInformation` и `GetOperatingSystemPlatformInformation` |
| 4 | Одна DLL во втором приложении | `src/SystemInfoLibrary.SecondConsumerApplication`, сравнение по MVID и SHA256 |
| 5 | PID через P/Invoke `GetCurrentProcessId` | `Kernel32NativeMethods`, `NativeWindowsProcessIdentifierProvider` |
| 6 | Ограничения Windows API | `Infrastructure/Limitations/*`, `WindowsApiLimitationInspector` |
| 7 | Обработка ошибки нативного вызова | `NativeFunctionInvocationGuard`, `NativeWin32LastErrorExceptionFactory`, `Infrastructure/Native/ErrorHandlingScenarios/*` |
| 8 | AssemblyVersion / FileVersion | свойства в `.csproj`, `ReflectionAssemblyVersionInformationProvider` |
| 9 | Совместимый метод обёртка | `SystemInformationLibraryFacade.CompatibilityWrappers.cs` — `[Obsolete] int GetCurrentProcessId()` из API 1.x |
| 10 | Сравнение управляемой и нативной DLL | `PortableExecutableFileInspector`, `StaticDynamicLinkLibraryComparisonCriteriaCatalog` |

## Ограничения Windows API

1. **Только Windows.** `kernel32.dll` нет в Linux и macOS. Библиотека проверяет `OperatingSystem.IsWindows()` и там использует `Environment.ProcessId`.
2. **Разрядность.** 64-битный процесс не загрузит 32-битную нативную DLL (`BadImageFormatException`). 32-битный процесс на x64 работает через WOW64.
3. **Типы.** `DWORD` всегда 32 бита (`uint`), а `HANDLE` и указатели зависят от разрядности (`IntPtr`).
4. **Ошибки.** Функции возвращают код, а причину сообщает `GetLastError`. Её нужно читать сразу после вызова через `Marshal.GetLastPInvokeError()` и только при `SetLastError = true`.
5. **PID.** `GetCurrentProcessId` не возвращает ошибок, но номер переиспользуется после завершения процесса, поэтому хранить его как постоянный идентификатор нельзя.

## Исправленный дефект

В стартовом проекте был `OutputType=WinExe` с `UseWindowsForms`, а вся программа писала в `Console`. У WinExe нет окна консоли, поэтому при запуске двойным щелчком вывод не был виден. Консольное приложение переведено на `OutputType=Exe` и `net9.0`.

## Запуск

```powershell
dotnet restore
dotnet build
dotnet run --project src/SystemInfoLibrary.ConsoleApplication
dotnet run --project src/SystemInfoLibrary.SecondConsumerApplication
```

Сценарии проверки — в [TESTING.md](TESTING.md).
