using System.Collections.Generic;
using RollerCoaster2019.Logic.Builder;

namespace RollerCoaster2019.Contracts
{
    public interface IBuildCoaster
    {
        int TrackCountAfterStartingArea { get; set; }
        bool TracksBuiltAfterStartingArea { get; set; }
        bool TracksFinshed { get; set; }
        bool TracksInFinshArea { get; set; }
        bool TracksStarted { get; set; }

        int GetFirstSetCount();
        int GetLastBaseChunk();
        Track GetTrack(int index);
        Track LastTrack();
        MergeDescriptor Merge();
        int NewTrackCount();
        void PopTrack();
        void PushTrack(Track track);
        void ResetCoaster();
        int TrackCount();
        bool TracksBuiltAfterStartingTracks();
    }
}