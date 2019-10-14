using RollerCoaster2019.Contracts;
using RollerCoaster2019.Logic.Builder.DataTypes;
using RollerCoaster2019.Logic.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RollerCoaster2019.Logic.Builder
{
    public class UserActionOrchestrator : IUserActionOrchestrator
    {
        internal const float FINSH_AREA_X = 260f;
        internal const float FINSH_AREA_Y = 5f;
        internal const int FINSH_AREA_WITHIN = 100;

        internal readonly IServiceProvider _serviceProvider;

        internal readonly IBuilderTasks _builderTasks;
        public UserActionOrchestrator(IBuilderTasks builderTasks,
                                           IServiceProvider serviceProvider)
        {
            _builderTasks = builderTasks;
            _serviceProvider = serviceProvider;
        }
        public BuildActionDescriptor ProcessBuildAction(Coaster coaster, UserActionType userActionType)
        {
            var buildActionDescriptor = new BuildActionDescriptor();
            var buildCoaster = new BuildCoaster(coaster);
            var buildActionType = ConvertToBuildActionType(userActionType);

            buildActionDescriptor.BuildActionResult = _builderTasks.BuildAction(buildCoaster, buildActionType);

            if (buildActionDescriptor.BuildActionResult != TaskResults.Successful)
            {
                buildActionDescriptor.AutoCorrectResult = FixBuilderTask(buildCoaster, buildActionDescriptor.BuildActionResult);
            }

            if (buildActionDescriptor.BuildActionResult != TaskResults.Successful &&
                buildActionDescriptor.AutoCorrectResult != TaskResults.Successful)
            {
                buildActionDescriptor.Successful = false;
                return buildActionDescriptor;
            }

            if (CoasterInFinshArea(buildCoaster))
            {
                buildActionDescriptor.FinshedCoaster = _builderTasks.BuildAction(buildCoaster, BuildActionType.FinshCoaster);
            }

            if (AutoLoopDetected(buildCoaster))
            {
                buildActionDescriptor.AutoLooped = _builderTasks.BuildAction(buildCoaster, BuildActionType.AutoLoop);
            }

            return buildActionDescriptor;
        }

        internal bool CoasterInFinshArea(IBuildCoaster buildCoaster)
        {
            var lastTrack = buildCoaster.LastTrack();

            return lastTrack.X < FINSH_AREA_X + (FINSH_AREA_WITHIN / 2) &&
                   lastTrack.X > FINSH_AREA_X - (FINSH_AREA_WITHIN / 2) &&
                   lastTrack.Y < FINSH_AREA_Y + (FINSH_AREA_WITHIN / 2) &&
                   lastTrack.Y > FINSH_AREA_Y - (FINSH_AREA_WITHIN / 2);
        }

        internal bool AutoLoopDetected(IBuildCoaster buildCoaster)
        {
            return false;
            //var trackCount = coaster.TrackCount();

            //if (trackCount > 42)
            //{
            //    return false;
            //}


            //for (int i = 0; i < 42; i++)
            //{
            //    if (coaster.GetTrack(trackCount - 1 - i).TrackType != TrackType.Up)
            //        return false;
            //}
            //return true;
        }

        internal BuildActionType ConvertToBuildActionType(UserActionType userActionType)
        {
            switch (userActionType)
            {
                case UserActionType.Stright:
                    return BuildActionType.Stright;
                case UserActionType.Left:
                    return BuildActionType.Left;
                case UserActionType.Right:
                    return BuildActionType.Right;
                case UserActionType.Up:
                    return BuildActionType.Up;
                case UserActionType.Down:
                    return BuildActionType.Down;
                case UserActionType.Back:
                    return BuildActionType.Back;
                case UserActionType.CreateStartingTracks:
                    return BuildActionType.CreateStartingTracks;
                case UserActionType.FinshCoaster:
                    return BuildActionType.FinshCoaster;
                case UserActionType.Loop:
                    return BuildActionType.Loop;
                case UserActionType.ToGround:
                    return BuildActionType.ToGround;
                case UserActionType.Downward:
                    return BuildActionType.Downward;
                case UserActionType.Upward:
                    return BuildActionType.Upward;
            }

            throw new Exception("Unsupported User Action Type");
        }
        internal TaskResults FixBuilderTask(IBuildCoaster buildCoaster, TaskResults taskResults)
        {
            BuildActionType buildActionType;
            switch (taskResults)
            {
                case TaskResults.MaxX:
                    buildActionType = BuildActionType.FixMaxX;
                    break;
                case TaskResults.MaxY:
                    buildActionType = BuildActionType.FixMaxY;
                    break;
                case TaskResults.MaxZ:
                    buildActionType = BuildActionType.FixMaxZ;
                    break;
                case TaskResults.MinX:
                    buildActionType = BuildActionType.FixMinX;
                    break;
                case TaskResults.MinY:
                    buildActionType = BuildActionType.FixMinY;
                    break;
                case TaskResults.MinZ:
                    buildActionType = BuildActionType.FixMinZ;
                    break;
                case TaskResults.Collison:
                    buildActionType = BuildActionType.FixCollision;
                    break;
                default:
                    return taskResults;
            }

            return _builderTasks.BuildAction(buildCoaster, buildActionType);
        }
    }
}
