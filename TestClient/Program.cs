using System;
using Microsoft.Extensions.DependencyInjection;

namespace TestClient
{
    internal class Program
    {
        private static IServiceProvider _serviceProvider;

        private static void Main(string[] args)
        {
            RegisterServices();
            var service = _serviceProvider.GetService<ITestClient>();
            service.TestVersion();
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
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