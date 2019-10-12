using RollerCoaster2019.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollerCoaster2019.Logic.Builder
{
    public class TrackRules : ITrackRules
    {
        internal readonly IMathHelper _mathHelper;

        internal const float BUILD_AREA_SIZE_X = 1000;
        internal const float BUILD_AREA_SIZE_Y = 1025;
        internal const float BUILD_AREA_SIZE_Z = 10000;
        internal const float CART_HEIGHT = 5f;
        public const float TRACK_LENGTH_2X = (float)7.7 * 2;

        public TrackRules(IMathHelper mathHelper)
        {
            _mathHelper = mathHelper;
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
            if ((pitch > 90 && pitch < 270) && (z < (0 + CART_HEIGHT * -1 * Math.Cos(_mathHelper.ToRadians(pitch)))))
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
            track = coaster.GetTrack(0);
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
