﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockLibrary;
using RollerCoaster2019.Logic;
using RollerCoaster2019.Logic.Builder;
using System.Linq;

namespace RollerCoaster2019.IntegrationTests
{
    [TestClass]
    public class BuildTests : BaseTest
    {
        [TestMethod]
        public void CreateCoaster_Runs_ReturnsCoasterWithStartingTracks()
        {
            //Setup
            RunDependencyInjectedTest
            (
                (serviceProvider) =>
                {
                    //Setup
                    var uut = serviceProvider.GetRequiredService<IUserActions>();
                    var uutConcrete = (UserActions)uut;
                    var expectedTrackCount = 64;

                    //Act
                    var coaster = uut.CreateCoaster();

                    //Assert
                    Assert.AreEqual(expectedTrackCount, coaster.Tracks.Count());
                },
                serviceCollection => ConfigureServices(serviceCollection)
            );
        }

        [TestMethod]
        public void ProcessBuildAction_Stright_AddsThreeNewStrightTracks()
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
                    var observedBuildActionDescriptor = uut.Build(coaster, Contracts.BuildActionType.Stright);

                    //Assert
                    Assert.AreEqual(3, observedBuildActionDescriptor.TracksAdded);
                    Assert.AreEqual(0, observedBuildActionDescriptor.TracksRemoved);
                    Assert.AreEqual(Contracts.TaskResults.Successful, observedBuildActionDescriptor.BuildActionResult);
                    Assert.AreEqual(Contracts.TaskResults.NotSet, observedBuildActionDescriptor.AutoCorrectResult);
                    Assert.AreEqual(false, observedBuildActionDescriptor.FinshedCoaster);
                    Assert.AreEqual(false, observedBuildActionDescriptor.AutoLooped);
                    Assert.AreEqual(Contracts.TrackType.Stright, coaster.Tracks[66].TrackType);
                    Assert.AreEqual(Contracts.TrackType.Stright, coaster.Tracks[65].TrackType);
                    Assert.AreEqual(Contracts.TrackType.Stright, coaster.Tracks[64].TrackType);
                },
                serviceCollection => ConfigureServices(serviceCollection)
            );
        }

        [TestMethod]
        public void ProcessBuildAction_Left_AddsThreeNewLeftTracks()
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
                    var observedBuildActionDescriptor = uut.Build(coaster, Contracts.BuildActionType.Left);

                    //Assert
                    Assert.AreEqual(3, observedBuildActionDescriptor.TracksAdded);
                    Assert.AreEqual(0, observedBuildActionDescriptor.TracksRemoved);
                    Assert.AreEqual(Contracts.TaskResults.Successful, observedBuildActionDescriptor.BuildActionResult);
                    Assert.AreEqual(Contracts.TaskResults.NotSet, observedBuildActionDescriptor.AutoCorrectResult);
                    Assert.AreEqual(false, observedBuildActionDescriptor.FinshedCoaster);
                    Assert.AreEqual(false, observedBuildActionDescriptor.AutoLooped);
                    Assert.AreEqual(Contracts.TrackType.Left, coaster.Tracks[66].TrackType);
                    Assert.AreEqual(Contracts.TrackType.Left, coaster.Tracks[65].TrackType);
                    Assert.AreEqual(Contracts.TrackType.Left, coaster.Tracks[64].TrackType);
                },
                serviceCollection => ConfigureServices(serviceCollection)
            );
        }

        [TestMethod]
        public void ProcessBuildAction_Right_AddsThreeNewRightTracks()
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
                    var observedBuildActionDescriptor = uut.Build(coaster, Contracts.BuildActionType.Right);

                    //Assert
                    Assert.AreEqual(3, observedBuildActionDescriptor.TracksAdded);
                    Assert.AreEqual(0, observedBuildActionDescriptor.TracksRemoved);
                    Assert.AreEqual(Contracts.TaskResults.Successful, observedBuildActionDescriptor.BuildActionResult);
                    Assert.AreEqual(Contracts.TaskResults.NotSet, observedBuildActionDescriptor.AutoCorrectResult);
                    Assert.AreEqual(false, observedBuildActionDescriptor.FinshedCoaster);
                    Assert.AreEqual(false, observedBuildActionDescriptor.AutoLooped);
                    Assert.AreEqual(Contracts.TrackType.Right, coaster.Tracks[66].TrackType);
                    Assert.AreEqual(Contracts.TrackType.Right, coaster.Tracks[65].TrackType);
                    Assert.AreEqual(Contracts.TrackType.Right, coaster.Tracks[64].TrackType);
                },
                serviceCollection => ConfigureServices(serviceCollection)
            );
        }

        [TestMethod]
        public void ProcessBuildAction_Up_AddsThreeNewUpTracks()
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
                    var observedBuildActionDescriptor = uut.Build(coaster, Contracts.BuildActionType.Up);

                    //Assert
                    Assert.AreEqual(3, observedBuildActionDescriptor.TracksAdded);
                    Assert.AreEqual(0, observedBuildActionDescriptor.TracksRemoved);
                    Assert.AreEqual(Contracts.TaskResults.Successful, observedBuildActionDescriptor.BuildActionResult);
                    Assert.AreEqual(Contracts.TaskResults.NotSet, observedBuildActionDescriptor.AutoCorrectResult);
                    Assert.AreEqual(false, observedBuildActionDescriptor.FinshedCoaster);
                    Assert.AreEqual(false, observedBuildActionDescriptor.AutoLooped);
                    Assert.AreEqual(Contracts.TrackType.Up, coaster.Tracks[66].TrackType);
                    Assert.AreEqual(Contracts.TrackType.Up, coaster.Tracks[65].TrackType);
                    Assert.AreEqual(Contracts.TrackType.Up, coaster.Tracks[64].TrackType);
                },
                serviceCollection => ConfigureServices(serviceCollection)
            );
        }

        [TestMethod]
        public void ProcessBuildAction_Down_AddsThreeNewUpTracks()
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
                    uut.Build(coaster, Contracts.BuildActionType.Up);
                    var observedBuildActionDescriptor = uut.Build(coaster, Contracts.BuildActionType.Down);

                    //Assert
                    Assert.AreEqual(3, observedBuildActionDescriptor.TracksAdded);
                    Assert.AreEqual(0, observedBuildActionDescriptor.TracksRemoved);
                    Assert.AreEqual(Contracts.TaskResults.Successful, observedBuildActionDescriptor.BuildActionResult);
                    Assert.AreEqual(Contracts.TaskResults.NotSet, observedBuildActionDescriptor.AutoCorrectResult);
                    Assert.AreEqual(false, observedBuildActionDescriptor.FinshedCoaster);
                    Assert.AreEqual(false, observedBuildActionDescriptor.AutoLooped);
                    Assert.AreEqual(Contracts.TrackType.Down, coaster.Tracks[69].TrackType);
                    Assert.AreEqual(Contracts.TrackType.Down, coaster.Tracks[68].TrackType);
                    Assert.AreEqual(Contracts.TrackType.Down, coaster.Tracks[67].TrackType);
                },
                serviceCollection => ConfigureServices(serviceCollection)
            );
        }

        [TestMethod]
        public void ProcessBuildAction_Back_RemovesChunk()
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
                    var x = uut.Build(coaster, Contracts.BuildActionType.Stright);
                    var observedBuildActionDescriptor = uut.Build(coaster, Contracts.BuildActionType.Back);

                    //Assert
                    Assert.AreEqual(0, observedBuildActionDescriptor.TracksAdded);
                    Assert.AreEqual(3, observedBuildActionDescriptor.TracksRemoved);
                    Assert.AreEqual(Contracts.TaskResults.Successful, observedBuildActionDescriptor.BuildActionResult);
                    Assert.AreEqual(Contracts.TaskResults.NotSet, observedBuildActionDescriptor.AutoCorrectResult);
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