using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockLibrary;
using RollerCoaster2019.Logic;
using RollerCoaster2019.Logic.Builder;
using RollerCoaster2019.Logic.Builder.DataTypes;

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
                        uut.Build(coaster, BuildActionType.Left);
                    }

                    for (int i = 0; i < 32; i++)
                    {
                        uut.Build(coaster, BuildActionType.Stright);
                    }

                    var observedBuildActionDescriptor = uut.Build(coaster, BuildActionType.Stright);

                    //Assert
                    Assert.AreEqual(TaskResults.MinX, observedBuildActionDescriptor.BuildActionResult);
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
                        uut.Build(coaster, BuildActionType.Right);
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        uut.Build(coaster, BuildActionType.Stright);
                    }
                    var observedBuildActionDescriptor = uut.Build(coaster, BuildActionType.Stright);

                    //Assert
                    Assert.AreEqual(TaskResults.MaxX, observedBuildActionDescriptor.BuildActionResult);
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
                        uut.Build(coaster, BuildActionType.Left);
                    }

                    uut.Build(coaster, BuildActionType.Stright);
                    uut.Build(coaster, BuildActionType.Stright);
                    var observedBuildActionDescriptor = uut.Build(coaster, BuildActionType.Stright);
                    
                    //Assert
                    Assert.AreEqual(TaskResults.MinY, observedBuildActionDescriptor.BuildActionResult);
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
                        uut.Build(coaster, BuildActionType.Stright);
                    }


                    var observedBuildActionDescriptor = uut.Build(coaster, BuildActionType.Stright);

                    //Assert
                    Assert.AreEqual(TaskResults.MaxY, observedBuildActionDescriptor.BuildActionResult);
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
                        uut.Build(coaster, BuildActionType.Stright);
                    }
                    for (int i = 0; i < 23; i++)
                    {
                        uut.Build(coaster, BuildActionType.Left);
                    }

                    var observedBuildActionDescriptor = uut.Build(coaster, BuildActionType.Left);

                    //Assert
                    Assert.AreEqual(TaskResults.Collison, observedBuildActionDescriptor.BuildActionResult);
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
                    var observedBuildActionDescriptor = uut.Build(coaster, BuildActionType.Down);

                    //Assert
                    Assert.AreEqual(TaskResults.MinZ, observedBuildActionDescriptor.BuildActionResult);
                    Assert.AreEqual(false, observedBuildActionDescriptor.FinshedCoaster);
                    Assert.AreEqual(false, observedBuildActionDescriptor.AutoLooped);
                },
                serviceCollection => ConfigureServices(serviceCollection)
            );
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
