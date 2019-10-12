using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockLibrary;
using RollerCoaster2019.Logic;
using RollerCoaster2019.Logic.Builder;

namespace RollerCoaster2019.LoadTests
{
    [TestClass]
    public class TrackRuleTests : BaseTest
    {
        [TestMethod]
        public void ProcessBuildAction_MinX_ReturnsMinX()
        {
            //Setup
            RunDependencyInjectedTest
            (
                (serviceProvider) =>
                {
                    //Setup
                    var uut = serviceProvider.GetRequiredService<IUserActions>();
                    var uutConcrete = (UserActions)uut;

                    //Act
                    var coaster = uut.CreateCoaster();

                    for (int i = 0; i < 3; i++)
                    {
                        uut.Build(coaster, Contracts.BuildActionType.Left);
                    }

                    for (int i = 0; i < 32; i++)
                    {
                        uut.Build(coaster, Contracts.BuildActionType.Stright);
                    }

                    var observedBuildActionDescriptor = uut.Build(coaster, Contracts.BuildActionType.Stright);

                    //Assert
                    Assert.AreEqual(Contracts.TaskResults.MinX, observedBuildActionDescriptor.BuildActionResult);
                    Assert.AreEqual(false, observedBuildActionDescriptor.FinshedCoaster);
                    Assert.AreEqual(false, observedBuildActionDescriptor.AutoLooped);
                },
                serviceCollection => ConfigureServices(serviceCollection)
            );
        }

        [TestMethod]
        public void ProcessBuildAction_MaxX_ReturnsMaxX()
        {
            //Setup
            RunDependencyInjectedTest
            (
                (serviceProvider) =>
                {
                    //Setup
                    var uut = serviceProvider.GetRequiredService<IUserActions>();
                    var uutConcrete = (UserActions)uut;

                    //Act
                    var coaster = uut.CreateCoaster();

                    for (int i = 0; i < 3; i++)
                    {
                        uut.Build(coaster, Contracts.BuildActionType.Right);
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        uut.Build(coaster, Contracts.BuildActionType.Stright);
                    }
                    var observedBuildActionDescriptor = uut.Build(coaster, Contracts.BuildActionType.Stright);

                    //Assert
                    Assert.AreEqual(Contracts.TaskResults.MaxX, observedBuildActionDescriptor.BuildActionResult);
                    Assert.AreEqual(false, observedBuildActionDescriptor.FinshedCoaster);
                    Assert.AreEqual(false, observedBuildActionDescriptor.AutoLooped);
                },
                serviceCollection => ConfigureServices(serviceCollection)
            );
        }

        [TestMethod]
        public void ProcessBuildAction_MinY_ReturnsMinY()
        {
            //Setup
            RunDependencyInjectedTest
            (
                (serviceProvider) =>
                {
                    //Setup
                    var uut = serviceProvider.GetRequiredService<IUserActions>();
                    var uutConcrete = (UserActions)uut;

                    //Act
                    var coaster = uut.CreateCoaster();

                    for (int i = 0; i < 6; i++)
                    {
                        uut.Build(coaster, Contracts.BuildActionType.Left);
                    }

                    uut.Build(coaster, Contracts.BuildActionType.Stright);
                    uut.Build(coaster, Contracts.BuildActionType.Stright);
                    var observedBuildActionDescriptor = uut.Build(coaster, Contracts.BuildActionType.Stright);
                    
                    //Assert
                    Assert.AreEqual(Contracts.TaskResults.MinY, observedBuildActionDescriptor.BuildActionResult);
                    Assert.AreEqual(false, observedBuildActionDescriptor.FinshedCoaster);
                    Assert.AreEqual(false, observedBuildActionDescriptor.AutoLooped);
                },
                serviceCollection => ConfigureServices(serviceCollection)
            );
        }

        [TestMethod]
        public void ProcessBuildAction_MaxY_ReturnsMaxY()
        {
            //Setup
            RunDependencyInjectedTest
            (
                (serviceProvider) =>
                {
                    //Setup
                    var uut = serviceProvider.GetRequiredService<IUserActions>();
                    var uutConcrete = (UserActions)uut;

                    //Act
                    var coaster = uut.CreateCoaster();

                    for (int i = 0; i < 44; i++)
                    {
                        uut.Build(coaster, Contracts.BuildActionType.Stright);
                    }


                    var observedBuildActionDescriptor = uut.Build(coaster, Contracts.BuildActionType.Stright);

                    //Assert
                    Assert.AreEqual(Contracts.TaskResults.MaxY, observedBuildActionDescriptor.BuildActionResult);
                    Assert.AreEqual(false, observedBuildActionDescriptor.FinshedCoaster);
                    Assert.AreEqual(false, observedBuildActionDescriptor.AutoLooped);
                },
                serviceCollection => ConfigureServices(serviceCollection)
            );
        }

        [TestMethod]
        public void ProcessBuildAction_Collison_ReturnsCollison()
        {
            //Setup
            RunDependencyInjectedTest
            (
                (serviceProvider) =>
                {
                    //Setup
                    var uut = serviceProvider.GetRequiredService<IUserActions>();
                    var uutConcrete = (UserActions)uut;

                    //Act
                    var coaster = uut.CreateCoaster();

                    for (int i = 0; i < 6; i++)
                    {
                        uut.Build(coaster, Contracts.BuildActionType.Stright);
                    }
                    for (int i = 0; i < 23; i++)
                    {
                        uut.Build(coaster, Contracts.BuildActionType.Left);
                    }

                    var observedBuildActionDescriptor = uut.Build(coaster, Contracts.BuildActionType.Left);

                    //Assert
                    Assert.AreEqual(Contracts.TaskResults.Collison, observedBuildActionDescriptor.BuildActionResult);
                    Assert.AreEqual(false, observedBuildActionDescriptor.FinshedCoaster);
                    Assert.AreEqual(false, observedBuildActionDescriptor.AutoLooped);
                },
                serviceCollection => ConfigureServices(serviceCollection)
            );
        }

        [TestMethod]
        public void ProcessBuildAction_MinZ_ReturnsMaxX()
        {
            //Setup
            RunDependencyInjectedTest
            (
                (serviceProvider) =>
                {
                    //Setup
                    var uut = serviceProvider.GetRequiredService<IUserActions>();
                    var uutConcrete = (UserActions)uut;

                    //Act
                    var coaster = uut.CreateCoaster();
                    var observedBuildActionDescriptor = uut.Build(coaster, Contracts.BuildActionType.Down);

                    //Assert
                    Assert.AreEqual(Contracts.TaskResults.MinZ, observedBuildActionDescriptor.BuildActionResult);
                    Assert.AreEqual(false, observedBuildActionDescriptor.FinshedCoaster);
                    Assert.AreEqual(false, observedBuildActionDescriptor.AutoLooped);
                },
                serviceCollection => ConfigureServices(serviceCollection)
            );
        }

        private IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IMathHelper, MathHelper>();
            serviceCollection.AddSingleton<IUserActions, UserActions>();
            serviceCollection.AddSingleton<IBuildActionOrchestrator, BuilderOrchestrator>();
            serviceCollection.AddSingleton<IActionOrchestrator, ActionOrchestrator>();
            serviceCollection.AddSingleton<IBuilderTasks, BuilderTasks>();
            serviceCollection.AddSingleton<ITrackRules, TrackRules>();

            return serviceCollection;
        }
    }
}
