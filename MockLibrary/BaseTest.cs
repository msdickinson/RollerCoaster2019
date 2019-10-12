using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MoreLinq;
using System;
using System.Threading.Tasks;

namespace MockLibrary
{
    public class BaseTest
    {
        public void RunDependencyInjectedTest(Action<IServiceProvider> callback, params Action<IServiceCollection>[] serviceCollectionConfigurators)
        {
            RunDependencyInjectedTestAsync(async serviceProvider => { callback(serviceProvider); await Task.CompletedTask.ConfigureAwait(false); }, serviceCollectionConfigurators).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public async Task RunDependencyInjectedTestAsync(Func<IServiceProvider, Task> callback, params Action<IServiceCollection>[] serviceCollectionConfigurators)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOptions();

            var IConfigurationRootMock = new Mock<IConfiguration>();
            serviceCollection.AddSingleton(IConfigurationRootMock.Object);

            serviceCollectionConfigurators.ForEach(serviceCollectionConfigurator => serviceCollectionConfigurator(serviceCollection));

            using (var applicationLifetime = new ApplicationLifetime())
            {
                serviceCollection.AddSingleton((IApplicationLifetime)applicationLifetime);
                using (var serviceProvider = serviceCollection.BuildServiceProvider())
                {
                    applicationLifetime.Started();
                    await callback(serviceProvider).ConfigureAwait(false);
                }
            }
        }
    }
}
