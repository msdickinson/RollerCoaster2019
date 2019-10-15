using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using RollerCoaster2019.Contracts;
using RollerCoaster2019.Logic;
using RollerCoaster2019.Logic.Builder;
using RollerCoaster2019.Logic.Builder.DataTypes;
using RollerCoaster2019.Logic.DataTypes;

namespace RollerCoaster2019.LoadTests.Benchmarks
{
    [RPlotExporter, RankColumn]
    public class Collision : ICollision
    {
        private readonly IUserActions _userActions;
        private Coaster _coaster;

        public Collision()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            _userActions = serviceProvider.GetService<IUserActions>();
        }

        [IterationSetup]
        public void IterationSetup()
        {
            _coaster = _userActions.CreateCoaster();
        }

        [IterationCleanup]
        public void IterationCleanup()
        {
            _coaster = null;
        }

        [Benchmark]
        public void BuildStright()
        {
            for (int i = 0; i < 5000; i++)
            {
                _userActions.Build(_coaster, UserActionType.Stright);
            }
        }

        private IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IUserActions, UserActions>();
            serviceCollection.AddSingleton<IBuildActionOrchestrator, BuilderOrchestrator>();
            serviceCollection.AddSingleton<IUserActionOrchestrator, UserActionOrchestrator>();
            serviceCollection.AddSingleton<IBuilderTasksOrchestrator, BuilderTasksOrchestrator>();

            return serviceCollection;
        }
    }
}
