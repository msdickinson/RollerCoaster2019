using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RollerCoaster2019.Contracts;
using RollerCoaster2019.Logic;
using RollerCoaster2019.Logic.Builder;
using RollerCoaster2019.Services;
using RollerCoaster2019.Services.ManageCoaster;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RollerCoaster2019.Console
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services, IConfiguration _configuration)
        {
            //Configuration
            var configurationRoot = GetConfigurationRoot();


            //Presentation
            services.AddSingleton<IApp, App>();

            //Logic
            services.AddSingleton<IMathHelper, MathHelper>();
            services.AddSingleton<IUserActions, UserActions>();
            services.AddSingleton<IBuildActionOrchestrator, BuilderOrchestrator>();
            services.AddSingleton<IActionOrchestrator, ActionOrchestrator>();
            services.AddSingleton<IBuilderTasks, BuilderTasks>();
            services.AddSingleton<ITrackRules, TrackRules>();
            //services.AddTransient<IBuildCoaster>((a) => new BuildCoaster(a.));

            //Services
            services.AddLogging(configure => configure.AddConsole());
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IManageCoasterService, ManageCoasterService>();
            services.Configure<DBConnection>(configurationRoot);

        }

        public IConfigurationRoot GetConfigurationRoot()
        {
            var enviorment = Environment.GetEnvironmentVariable("BUILD_CONFIGURATION");

            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{enviorment}.json", false)
                .Build();
        }
    }
}
