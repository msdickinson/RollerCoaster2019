using BenchmarkDotNet.Running;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RollerCoaster2019.Logic;
using RollerCoaster2019.Logic.Builder;
using System;
using System.Threading.Tasks;

namespace RollerCoaster2019.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var app = serviceProvider.GetService<IApp>();
            await app.Run();
        }

        static void ConfigureServices(IServiceCollection services)
        {
            //Presentation
            services.AddSingleton<IApp, App>();

            //Logic
            services.AddSingleton<IUserActions, UserActions>();
            services.AddSingleton<IBuildActionOrchestrator, BuilderOrchestrator>();
            services.AddSingleton<IActionOrchestrator, ActionOrchestrator>();
            services.AddSingleton<IBuilderTasks, BuilderTasks>();
            services.AddSingleton<ITrackRules, TrackRules>();
        }
    }
}
