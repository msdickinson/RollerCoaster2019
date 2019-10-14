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
            var taskResults = TaskResults.NotSet;
            switch (buildActionType)
            {
                case BuildActionType.CreateStartingTracks:
                    taskResults = BuildStartingTracks(coaster);    //Done
                    break;
                case BuildActionType.Stright:
                    taskResults = BuildStright(coaster);           //Done
                    break;
                case BuildActionType.Left:
                    taskResults = BuildLeft(coaster);              //Done
                    break;
                case BuildActionType.Right:
                    taskResults = BuildRight(coaster);             //Done
                    break;
                case BuildActionType.Up:
                    taskResults = BuildUp(coaster);                //Done
                    break;
                case BuildActionType.Down:
                    taskResults = BuildDown(coaster);              //Done
                    break;
                case BuildActionType.Back:
                    taskResults = RemoveChunk(coaster);            //Done
                    break;
                case BuildActionType.AutoLoop:
                    taskResults = AutoLoop(coaster);               //TODO
                    break;
                case BuildActionType.Loop:
                    taskResults = BuildLoop(coaster);              //TODO
                    break;
                case BuildActionType.FinshCoaster:
                    taskResults = FinshCoaster(coaster);           //TODO
                    break;
                case BuildActionType.ToGround:
                    taskResults = BuildToGround(coaster);          //TODO
                    break;
                case BuildActionType.Downward:
                    taskResults = BuildDownward(coaster);          //TODO
                    break;
                case BuildActionType.Upward:
                    taskResults = BuildUpward(coaster);            //TODO
                    break;
                case BuildActionType.FixMinX:
                    taskResults = FixMinX(coaster);                //TODO
                    break;
                case BuildActionType.FixMinY:
                    taskResults = FixMinY(coaster);                //TODO
                    break;
                case BuildActionType.FixMinZ:
                    taskResults = FixMinZ(coaster);                //TODO
                    break;
                case BuildActionType.FixMaxX:
                    taskResults = FixMaxX(coaster);                //TODO
                    break;
                case BuildActionType.FixMaxY:
                    taskResults = FixMaxY(coaster);                //TODO
                    break;
                case BuildActionType.FixMaxZ:
                    taskResults = FixMaxZ(coaster);                //TODO
                    break;
                case BuildActionType.FixCollision:
                    taskResults = FixCollision(coaster);           //TODO
                    break;
                default:
                    return TaskResults.UnsupportedTaskType;
            }

            if(taskResults == TaskResults.Successful)
            {
                coaster.Merge();
            }
            else
            {
                coaster.ResetCoaster();
            }

            return taskResults;
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
