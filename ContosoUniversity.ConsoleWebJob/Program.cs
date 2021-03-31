using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ContosoUniversity.ConsoleWebJob
{
    class Program
    {
        static async Task Main()
        {
            // https://docs.microsoft.com/en-us/azure/app-service/webjobs-sdk-get-started

            Console.WriteLine("Start");

            var builder = new HostBuilder();
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddAzureStorage();
            });

            builder.ConfigureLogging((context, b) =>
            {
                b.AddConsole();
            });

            var host = builder.Build();
            
            using (host)
            {
                await host.RunAsync();
            }
            
            Console.WriteLine("End");
        }
    }
}