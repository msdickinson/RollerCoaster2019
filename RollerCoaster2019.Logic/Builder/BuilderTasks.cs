using RollerCoaster2019.Contracts;
using RollerCoaster2019.Logic.Builder.DataTypes;
using RollerCoaster2019.Logic.DataTypes;
using System.Collections.Generic;

namespace RollerCoaster2019.Logic.Builder
{
    public class BuilderTasks : IBuilderTasks
    {
        internal readonly IBuildActionOrchestrator _buildActionOrchestrator;
        internal readonly float UP_PITCH = 90;
        internal readonly float DOWN_PITCH = 270;
        internal readonly float FLAT_PITCH = 0;

        public BuilderTasks(IBuildActionOrchestrator buildActionOrchestrator)
        {
            _buildActionOrchestrator = buildActionOrchestrator;
        }

        public TaskResults BuildAction(IBuildCoaster coaster, BuildActionType buildActionType)
        {
            switch (buildActionType)
            {
                case BuildActionType.CreateStartingTracks:
                    return BuildStartingTracks(coaster);
                case BuildActionType.Stright:
                    return BuildStright(coaster);
                case BuildActionType.Left:
                    return BuildLeft(coaster);
                case BuildActionType.Right:
                    return BuildRight(coaster);
                case BuildActionType.Up:
                    return BuildUp(coaster);
                case BuildActionType.Down:
                    return BuildDown(coaster);
                case BuildActionType.Back:
                    return RemoveChunk(coaster);
                case BuildActionType.AutoLoop:
                    return AutoLoop(coaster);
                case BuildActionType.Loop:
                    return BuildLoop(coaster);
                case BuildActionType.FinshCoaster:
                    return FinshCoaster(coaster);
                case BuildActionType.ToGround:
                    return BuildToGround(coaster);
                case BuildActionType.Downward:
                    return BuildDownward(coaster);
                case BuildActionType.Upward:
                    return BuildUpward(coaster);
                case BuildActionType.FixMinX:
                    return FixMinX(coaster);
                case BuildActionType.FixMinY:
                    return FixMinY(coaster);
                case BuildActionType.FixMinZ:
                    return FixMinZ(coaster);
                case BuildActionType.FixMaxX:
                    return FixMaxX(coaster);
                case BuildActionType.FixMaxY:
                    return FixMaxY(coaster);
                case BuildActionType.FixMaxZ:
                    return FixMaxZ(coaster);
                case BuildActionType.FixCollision:
                    return FixCollision(coaster);
                default:
                    return TaskResults.UnsupportedTaskType;
            }
        }

        internal TaskResults BuildStartingTracks(IBuildCoaster coaster)
        {
            List<BuildAction> buildActions = new List<BuildAction>();

            var buildActionStright = new BuildAction { TrackType = TrackType.Stright };
            var buildActionleft = new BuildAction { TrackType = TrackType.Left };

            for (int i = 0; i < 24; i++)
            {
                buildActions.Add(buildActionStright);
            }

            for (int i = 0; i < 12; i++)
            {
                buildActions.Add(buildActionleft);
            }

            for (int i = 0; i < 28; i++)
            {
                buildActions.Add(buildActionStright);
            }

            _buildActionOrchestrator.ProcessBuildActions(coaster, buildActions);
            coaster.TracksStarted = true;

            return TaskResults.Successful;
        }

        internal TaskResults BuildDown(IBuildCoaster coaster)
        {
            var buildActionDown = new BuildAction { TrackType = TrackType.Down };

            List<BuildAction> buildActions = new List<BuildAction>
            {
                buildActionDown,
                buildActionDown,
                buildActionDown
            };

            return _buildActionOrchestrator.ProcessBuildActions(coaster, buildActions);
        }

        internal TaskResults BuildUp(IBuildCoaster coaster)
        {
            var buildActionUp = new BuildAction{ TrackType = TrackType.Up };

            List<BuildAction> buildActions = new List<BuildAction>
            {
                buildActionUp,
                buildActionUp,
                buildActionUp
            };

            return _buildActionOrchestrator.ProcessBuildActions(coaster, buildActions);
        }

        internal TaskResults BuildStright(IBuildCoaster coaster)
        {
            var buildActionStright = new BuildAction { TrackType = TrackType.Stright };

            List<BuildAction> buildActions = new List<BuildAction>
            {
                buildActionStright,
                buildActionStright,
                buildActionStright
            };

            return _buildActionOrchestrator.ProcessBuildActions(coaster, buildActions);
        }

        internal TaskResults BuildLeft(IBuildCoaster coaster)
        {
            var buildActionLeft = new BuildAction { TrackType = TrackType.Left };

            List<BuildAction> buildActions = new List<BuildAction>
            {
                buildActionLeft,
                buildActionLeft,
                buildActionLeft
            };

            return _buildActionOrchestrator.ProcessBuildActions(coaster, buildActions);
        }

        internal TaskResults BuildRight(IBuildCoaster coaster)
        {
            var buildActionRight = new BuildAction { TrackType = TrackType.Right };

            List<BuildAction> buildActions = new List<BuildAction>
            {
                buildActionRight,
                buildActionRight,
                buildActionRight
            };

            return _buildActionOrchestrator.ProcessBuildActions(coaster, buildActions);
        }

        internal TaskResults BuildUpward(IBuildCoaster coaster)
        {

            if (BuildToPitch(coaster, UP_PITCH) != TaskResults.Successful)
            {
                return TaskResults.Fail;
            }

           return BuildStright(coaster);
        }

        internal TaskResults BuildDownward(IBuildCoaster coaster)
        {
            if (BuildToPitch(coaster, DOWN_PITCH) != TaskResults.Successful)
            {
                return TaskResults.Fail;
            }

            return BuildStright(coaster);
        }

        internal TaskResults BuildToGround(IBuildCoaster coaster)
        {
            while (BuildDownward(coaster) == TaskResults.Successful);
            
            if (BuildToPitch(coaster, DOWN_PITCH, 15) != TaskResults.Successful)
            {
                return TaskResults.Fail;
            }

            return BuildStright(coaster);
        }

        internal TaskResults RemoveChunk(IBuildCoaster coaster)
        {
            List<BuildAction> buildActions = new List<BuildAction>();

            buildActions.Add(new BuildAction{ RemoveChunk = true });

            return _buildActionOrchestrator.ProcessBuildActions(coaster, buildActions);
        }

        internal TaskResults FinshCoaster(IBuildCoaster coaster)
        {
            return TaskResults.Fail;
        }

        internal TaskResults AutoLoop(IBuildCoaster coaster)
        {
            return TaskResults.Fail;
        }

        internal TaskResults BuildLoop(IBuildCoaster coaster)
        {
            return TaskResults.Fail;
        }

        internal TaskResults BuildToPitch(IBuildCoaster coaster, float pitch, int totalTracksCanBeRemoved = 0)
        {
            return TaskResults.Fail;
        }

        internal TaskResults BuildToYaw(IBuildCoaster coaster, float yaw, int totalTracksCanBeRemoved = 0)
        {
            return TaskResults.Fail;
        }

        internal TaskResults BuildToX(IBuildCoaster coaster, float x)
        {
            return TaskResults.Fail;
        }

        internal TaskResults BuildToY(IBuildCoaster coaster, float y)
        {
            return TaskResults.Fail;
        }

        internal TaskResults BuildToZ(IBuildCoaster coaster, float z)
        {
            return TaskResults.Fail;
        }

        internal TaskResults BuildToXY(IBuildCoaster coaster, float x, float y)
        {
            return TaskResults.Fail;
        }

        internal TaskResults FixMaxX(IBuildCoaster coaster)
        {
            return TaskResults.Fail;
        }

        internal TaskResults FixMaxY(IBuildCoaster coaster)
        {
            return TaskResults.Fail;
        }

        internal TaskResults FixMaxZ(IBuildCoaster coaster)
        {
            return TaskResults.Fail;
        }

        internal TaskResults FixMinX(IBuildCoaster coaster)
        {
            return TaskResults.Fail;
        }

        internal TaskResults FixMinY(IBuildCoaster coaster)
        {
            return TaskResults.Fail;
        }

        internal TaskResults FixMinZ(IBuildCoaster coaster)
        {
            return TaskResults.Fail;
        }

        internal TaskResults FixCollision(IBuildCoaster coaster)
        {
            return TaskResults.Fail;
        }

    }
}
