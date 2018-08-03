using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebJobsSample
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
               .UseEnvironment("Development")
               .ConfigureWebJobsHost()
               .AddAzureStorage()
               .ConfigureAppConfiguration(b =>
               {
                   b.AddJsonFile("appsettings.json");
                   b.AddCommandLine(args);
               })
               .ConfigureLogging(b =>
               {
                   b.SetMinimumLevel(LogLevel.Trace);
                   b.AddConsole();
               })
               .UseConsoleLifetime();

            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
