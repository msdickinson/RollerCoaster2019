using Microsoft.Extensions.DependencyInjection;
using RollerCoaster2019.Logic;
using RollerCoaster2019.Logic.Builder;
using System.Threading.Tasks;

namespace RollerCoaster2019.Console
{
    class Program
    {
        static async Task Main()
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
            services.AddSingleton<IUserActionOrchestrator, UserActionOrchestrator>();
            services.AddSingleton<IBuilderTasksOrchestrator, BuilderTasksOrchestrator>();
        }
    }
}
