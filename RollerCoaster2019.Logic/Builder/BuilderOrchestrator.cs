using RollerCoaster2019.Contracts;
using RollerCoaster2019.Logic.Builder.DataTypes;
using RollerCoaster2019.Logic.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RollerCoaster2019.Logic.Builder
{
    public class BuilderOrchestrator : IBuildActionOrchestrator
    {
        internal const float START_X = 500;
        internal const float START_Y = -275;
        internal const float START_Z = 0;

        internal const float START_YAW = 0;
        internal const float START_PITCH = 0;

        internal const float BUILD_AREA_SIZE_X = 1000;
        internal const float BUILD_AREA_SIZE_Y = 1025;
        internal const float BUILD_AREA_SIZE_Z = 10000;
        internal const float CART_HEIGHT = 5f;
        public const float TRACK_LENGTH_2X = (float)7.7 * 2;

        internal const float STANDARD_ANGLE_CHANGE = 7.5f;
        internal const float TRACK_LENGTH = (float)7.7;
        
        public BuilderOrchestrator()
        {

        }

        public TaskResults ProcessBuildActions(IBuildCoaster coaster, IEnumerable<BuildAction> buildActions)
        {
            TaskResults result = TaskResults.Successful;

            foreach (BuildAction buildAction in buildActions)
            {
                result = ProcessBuildAction(coaster, buildAction);
                if (result != TaskResults.Successful)
                    break;
            }

            return result;
        }

        public TaskResults ProcessBuildAction(IBuildCoaster coaster, BuildAction buildAction)
        {
            if(buildAction.RemoveChunk)
            {
               return ProcessRemoveChunk(coaster);
            }

            return ProcessAddTrack(coaster, buildAction);
        }

        public TaskResults ProcessRemoveChunk(IBuildCoaster coaster)
        {
            if(!coaster.TracksBuiltAfterStartingTracks())
            {
                return TaskResults.CannotRemoveStartTracks;
            }

            var count = coaster.GetLastBaseChunk();

            for(int i = 0; i < count; i++)
            {
                coaster.PopTrack();
            }
          
            return TaskResults.Successful;
        }

        public TaskResults ProcessRemoveTracks(IBuildCoaster coaster, int count)
        {
            //for (int i = 0; i < count; i++)
            //{
            //    coaster.PopTrack();
            //}

            return TaskResults.Successful;
        }

        public TaskResults ProcessAddTrack(IBuildCoaster coaster, BuildAction buildAction)
        {
            //Check If Coater Finshed
            float yaw;
            float pitch;
            float x;
            float y;
            float z;

            //Determine Starting Position
            if (coaster.TrackCount() == 0)
            {
                yaw = START_YAW;
                pitch = START_PITCH;
                x = START_X;
                y = START_Y;
                z = START_Z;
            }
            else
            {
                Track track = coaster.LastTrack();
                yaw = track.Yaw;
                pitch = track.Pitch;
                x = track.X;
                y = track.Y;
                z = track.Z;
            }

            //Determine Yaw And Pitch
            switch (buildAction.TrackType)
            {
                case TrackType.Stright:
                    break;
                case TrackType.Left:
                    yaw = yaw + STANDARD_ANGLE_CHANGE;
                    break;
                case TrackType.Right:
                    yaw = yaw - STANDARD_ANGLE_CHANGE;
                    break;
                case TrackType.Up:
                    pitch = pitch + STANDARD_ANGLE_CHANGE;
                    break;
                case TrackType.Down:
                    pitch = pitch - STANDARD_ANGLE_CHANGE;
                    break;
                case TrackType.Custom:
                    yaw = yaw + buildAction.YawOffset;
                    pitch = pitch + buildAction.PitchOffset;
                    break;
            }

            //Determine X, Y, And Z
            x = x + (float)(Math.Cos(ToRadians(yaw)) * Math.Cos(ToRadians(pitch)) * TRACK_LENGTH);
            y = y + (float)(Math.Sin(ToRadians(yaw)) * Math.Cos(ToRadians(pitch)) * TRACK_LENGTH);
            z = z + (float)(Math.Sin(ToRadians(pitch)) * TRACK_LENGTH);

            //Check Rules
            TaskResults result = VaildateRulesForTrack(coaster, x, y, z, yaw, pitch, buildAction.TrackType);


            //Add Track
            if (TaskResults.Successful == result)
            {
                Track track = new Track
                {
                    Pitch = pitch,
                    Yaw = yaw,
                    TrackType = buildAction.TrackType,
                    X = x,
                    Y = y,
                    Z = z
                };

                coaster.PushTrack(track);
            }

            return result;
        }

        internal TaskResults VaildateRulesForTrack(IBuildCoaster coaster, float x, float y, float z, float yaw, float pitch, TrackType trackType)
        {
            TaskResults result = TaskResults.Successful;

            if (coaster.TracksStarted == false || coaster.TracksFinshed == true)
                return result;

            if (!Collison(coaster, x, y, z))
                return TaskResults.Collison;

            if (!MaxX(x))
                return TaskResults.MaxX;

            if (!MaxY(y))
                return TaskResults.MaxY;

            if (!MinX(x))
                return TaskResults.MinX;

            if (!MinY(y))
                return TaskResults.MinY;

            if (!MinZ(yaw, pitch, z))
                return TaskResults.MinZ;

            return result;
        }

        public float ToRadians(float degrees)
        {
            return (float)(Math.PI * degrees / 180.0);
        }

        public bool MaxX(float x)
        {
            if (x > BUILD_AREA_SIZE_X)
                return false;
            else
                return true;
        }

        public bool MaxY(float y)
        {
            if (y > BUILD_AREA_SIZE_Y)
                return false;
            else
                return true;
        }

        public bool MinX(float x)
        {
            if (x < 0)
                return false;
            else
                return true;
        }

        public bool MinY(float y)
        {
            if (y < 0)
                return false;
            else
                return true;
        }

        public bool MinZ(float yaw, float pitch, float z)
        {
            if (pitch > 90 &&
                pitch < 270 &&
                z < (0 + CART_HEIGHT * -1 * (Math.PI / 180) * pitch))
                return false;
            else if (z < 0)
                return false;
            else
                return true;
        }
        public bool Collison(IBuildCoaster coaster, float x, float y, float z)
        {
            var getFirstSetCount = coaster.GetFirstSetCount();
            var trackCount = coaster.TrackCount() - 3;
            Track track;

            for (int i = getFirstSetCount; i < trackCount; i++)
            {
                track = coaster.GetTrack(i);
                if (Math.Sqrt(
                                (x - track.X) * (x - track.X) +
                                (y - track.Y) * (y - track.Y) +
                                (z - track.Z) * (z - track.Z)
                              ) <= TRACK_LENGTH_2X)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
