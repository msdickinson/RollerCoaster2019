using RollerCoaster2019.Contracts;
using RollerCoaster2019.Logic.Builder.DataTypes;
using RollerCoaster2019.Logic.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RollerCoaster2019.Logic.Builder
{
    public class ActionOrchestrator : IActionOrchestrator
    {
        const float FINSH_AREA_X = 260f;
        const float FINSH_AREA_Y = 5f;
        const int FINSH_AREA_WITHIN = 100;


        internal readonly IServiceProvider _serviceProvider;
        
        internal readonly IBuilderTasks _builderTasks;
        public ActionOrchestrator(IBuilderTasks builderTasks,
                                           IServiceProvider serviceProvider)
        {
            _builderTasks = builderTasks;
            _serviceProvider = serviceProvider;
        }
        public BuildActionDescriptor ProcessBuildAction(Coaster coaster, BuildActionType buildActionType)
        {
            var buildActionDescriptor = new BuildActionDescriptor();
            var buildCoaster = new BuildCoaster(coaster);

            buildActionDescriptor.BuildActionResult = BuildAction(buildCoaster, buildActionType);

            if (buildActionDescriptor.BuildActionResult != TaskResults.Successful)
            {
                buildActionDescriptor.AutoCorrectResult = AutoCorrect(buildCoaster, buildActionDescriptor.BuildActionResult);
            }

            if (buildActionDescriptor.BuildActionResult != TaskResults.Successful &&
                buildActionDescriptor.AutoCorrectResult != TaskResults.Successful)
            {
                return buildActionDescriptor;
            }

            var mergeDescriptor = buildCoaster.Merge();
            buildActionDescriptor.TracksAdded = mergeDescriptor.TracksAdded;
            buildActionDescriptor.TracksRemoved = mergeDescriptor.TracksRemoved;


            if (CoasterInFinshArea(buildCoaster))
            {
                FinshCoaster(buildCoaster);
                var mergeDescriptorResult = buildCoaster.Merge();

                buildActionDescriptor.TracksAdded = mergeDescriptorResult.TracksAdded;
                buildActionDescriptor.TracksRemoved = mergeDescriptorResult.TracksRemoved;
                buildActionDescriptor.FinshedCoaster = true;

                return buildActionDescriptor;
            }

            if (CanAutoLoop(buildCoaster))
            {
                AutoLoopCoaster(buildCoaster);
                var mergeDescriptorResult = buildCoaster.Merge();

                buildActionDescriptor.TracksAdded = mergeDescriptorResult.TracksAdded;
                buildActionDescriptor.TracksRemoved = mergeDescriptorResult.TracksRemoved;
                buildActionDescriptor.AutoLooped = true;
            }

            return buildActionDescriptor;
        }

        private void FinshCoaster(IBuildCoaster buildCoaster)
        {
            throw new NotImplementedException();
        }

        private bool CoasterInFinshArea(IBuildCoaster coaster)
        {
            var lastTrack = coaster.LastTrack();

            return lastTrack.X < FINSH_AREA_X + (FINSH_AREA_WITHIN / 2)    &&
                   lastTrack.X > FINSH_AREA_X - (FINSH_AREA_WITHIN / 2)    && 
                   lastTrack.Y < FINSH_AREA_Y + (FINSH_AREA_WITHIN / 2)    && 
                   lastTrack.Y > FINSH_AREA_Y - (FINSH_AREA_WITHIN / 2);
        }

        private bool CanAutoLoop(IBuildCoaster coaster)
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

        private void AutoLoopCoaster(IBuildCoaster buildCoaster)
        {
            throw new NotImplementedException();
        }

        public TaskResults BuildAction(IBuildCoaster coaster, BuildActionType buildActionType)
        {
            switch (buildActionType)
            {
                case BuildActionType.CreateStartingTracks:
                    return _builderTasks.BuildStartingTracks(coaster);
                case BuildActionType.Stright:
                    return _builderTasks.BuildStright(coaster);
                case BuildActionType.Left:
                    return _builderTasks.BuildLeft(coaster);
                case BuildActionType.Right:
                    return _builderTasks.BuildRight(coaster);
                case BuildActionType.Up:
                    return _builderTasks.BuildUp(coaster);
                case BuildActionType.Down:
                    return _builderTasks.BuildDown(coaster);
                case BuildActionType.Back:
                    return _builderTasks.RemoveChunk(coaster);
                default:
                    return TaskResults.UnsupportedTaskType;
            }
        }

        public TaskResults AutoCorrect(IBuildCoaster coaster, TaskResults taskResults)
        {
            switch (taskResults)
            {
                //case TaskResults.MaxX:
                //    return FixMaxX.Run(coaster);
                //case TaskResults.MaxY:
                //    return FixMaxY.Run(coaster);
                //case TaskResults.MinX:
                //    return FixMinX.Run(coaster);
                //case TaskResults.MinY:
                //    return FixMinY.Run(coaster);
                //case TaskResults.MinZ:
                //    return FixMinZ.Run(coaster);
                //case TaskResults.Collison:
                //    return FixTrackCollison.Run(coaster);
                default:
                    return taskResults;
            }
        }
    }
}
