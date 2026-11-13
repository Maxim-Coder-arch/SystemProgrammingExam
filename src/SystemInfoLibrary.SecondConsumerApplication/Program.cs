using System.Text;

namespace Variant16.SystemInfoLibrary.SecondConsumerApplication;

internal static class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        var secondConsumerApplicationService = new SecondConsumerApplicationService();

        secondConsumerApplicationService.RunSecondConsumerApplication();
    }
}
