using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace RollerCoaster2019.Console
{
    class Program
    { 
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            var startup = new Startup();
            startup.ConfigureServices(serviceCollection, null);
            var serviceProvider = serviceCollection.BuildServiceProvider();


            var app = serviceProvider.GetService<IApp>();
            await app.Run();
        }

    }
}
