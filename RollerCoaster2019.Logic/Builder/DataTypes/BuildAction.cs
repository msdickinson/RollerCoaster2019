using RollerCoaster2019.Logic.DataTypes;

namespace RollerCoaster2019.Logic.Builder.DataTypes
{
    public class BuildAction
    {
        public bool RemoveChunk = false;
        public bool RemoveTracks = false;
        public TrackType TrackType;
        public float YawOffset = 0;
        public float PitchOffset = 0;
        public int RemoveTrackCount;
    }
}
