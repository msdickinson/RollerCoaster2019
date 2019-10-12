using RollerCoaster2019.Contracts;
using System.Collections.Generic;

namespace RollerCoaster2019.Logic.Builder
{
    public class BuilderTasks : IBuilderTasks
    {
        internal readonly IBuildActionOrchestrator _buildActionOrchestrator;
        public BuilderTasks(IBuildActionOrchestrator buildActionOrchestrator)
        {
            _buildActionOrchestrator = buildActionOrchestrator;
        }

        public TaskResults BuildStartingTracks(IBuildCoaster coaster)
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

        public TaskResults BuildDown(IBuildCoaster coaster)
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

        public TaskResults BuildUp(IBuildCoaster coaster)
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

        public TaskResults BuildStright(IBuildCoaster coaster)
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

        public TaskResults BuildLeft(IBuildCoaster coaster)
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

        public TaskResults BuildRight(IBuildCoaster coaster)
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

        public TaskResults RemoveChunk(IBuildCoaster coaster)
        {
            List<BuildAction> buildActions = new List<BuildAction>();

            buildActions.Add(new BuildAction{ RemoveChunk = true });

            return _buildActionOrchestrator.ProcessBuildActions(coaster, buildActions);
        }

    }
}
