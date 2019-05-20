using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace TestClient
{
    internal class Program
    {
        private static IServiceProvider _serviceProvider;

        private static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            RegisterServices();

            var service = _serviceProvider.GetService<ITestClient>();
            service.TestVersion();

            DisposeServices();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();

            // Add logging
            collection.AddLogging(configure => configure.AddSerilog(Log.Logger));

            collection.AddScoped<ITestClient, TestClient>();

            // ...
            // Add other services
            // ...

            _serviceProvider = collection.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            switch (_serviceProvider)
            {
                case null:
                    return;

                case IDisposable disposable:
                    disposable.Dispose();
                    break;
            }
        }
    }
}