using RollerCoaster2019.Logic.Builder;
using RollerCoaster2019.Logic.Builder.DataTypes;
using RollerCoaster2019.Logic.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RollerCoaster2019.Contracts
{
    public class BuildCoaster : IBuildCoaster
    {
        private readonly Coaster _baseCoaster;
        private readonly Coaster _extensionCoaster;
        int trackOffset = 0;
        //int chunkOffset = 0;

        public BuildCoaster(Coaster coaster)
        {
            _baseCoaster = coaster;
            _extensionCoaster = new Coaster
            {
                Chunks = new List<int>(),
                Tracks = new List<Track>(),
                TracksFinshed = _baseCoaster.TracksFinshed,
                TracksStarted = _baseCoaster.TracksStarted
            };

            _totalBaseTracks = _baseCoaster.Tracks.Count() - trackOffset;
        }

        public bool TracksFinshed
        {
            get => _extensionCoaster.TracksFinshed;
            set => _extensionCoaster.TracksFinshed = value;
        }

        public bool TracksStarted
        {
            get => _extensionCoaster.TracksStarted;
            set => _extensionCoaster.TracksStarted = value;
        }
        public bool TracksBuiltAfterStartingArea { get; set; }
        public int TrackCountAfterStartingArea { get; set; }
        private int _totalBaseTracks = 0;
        public int TrackCount()
        {
            return _baseCoaster.Tracks.Count() + _extensionCoaster.Tracks.Count() - trackOffset;
        }
        public int NewTrackCount()
        {
            return _extensionCoaster.Tracks.Count();
        }

        public Track GetTrack(int index)
        {
            if (_totalBaseTracks > index)
            {
                return _baseCoaster.Tracks[index];
            }

            return _extensionCoaster.Tracks[index];
        }

        public Track LastTrack()
        {
            if (_extensionCoaster.Tracks.Count > 0)
            {
                return _extensionCoaster.Tracks.Last();
            }
            else if (_baseCoaster.Tracks.Count > 0)
            {
                return _baseCoaster.Tracks.Last();
            }

            throw (new Exception("No Tracks Exist"));
            
        }

        public MergeDescriptor Merge()
        {

            //Misc
            _baseCoaster.TracksFinshed = _extensionCoaster.TracksFinshed;
            _baseCoaster.TracksStarted = _extensionCoaster.TracksStarted;


            //Tracks
            _baseCoaster.Tracks.RemoveRange(_baseCoaster.Tracks.Count() + trackOffset, Math.Abs(trackOffset));
            _baseCoaster.Tracks.AddRange(_extensionCoaster.Tracks);

            //Chunk
            var trackCount = _baseCoaster.Tracks.Count();
            while (_baseCoaster.Chunks.Sum() > trackCount)
            {
                _baseCoaster.Chunks.Remove(_baseCoaster.Chunks.Last());

            }
            if (_baseCoaster.Chunks.Sum() < trackCount)
            {
                _baseCoaster.Chunks.Add(trackCount - _baseCoaster.Chunks.Sum());

            }

            return new MergeDescriptor
            {
                TracksAdded = _extensionCoaster.Tracks.Count(),
                TracksRemoved = Math.Abs(trackOffset)
            };
        }

        public int GetFirstSetCount()
        {
            return _baseCoaster.Chunks.FirstOrDefault();
        }
        public void PushTrack(Track track)
        {

            _extensionCoaster.Tracks.Add(track);
            _totalBaseTracks = _baseCoaster.Tracks.Count() - trackOffset;
        }

        public void PopTrack()
        {
            if (_extensionCoaster.Tracks.Count() >= 1)
            {
                _extensionCoaster.Tracks.Remove(_extensionCoaster.Tracks.Last());
                _totalBaseTracks = _baseCoaster.Tracks.Count() - trackOffset;
                return;
            }

            if (_baseCoaster.Chunks.Count() >= 2)
            {
                trackOffset--;
                _totalBaseTracks = _baseCoaster.Tracks.Count() - trackOffset;
                return;
            }

            throw (new Exception("Cannot Remove Starting Tracks"));


        }

        public bool TracksBuiltAfterStartingTracks()
        {
            return _baseCoaster.Chunks.Count >= 2;
        }

        public void ResetCoaster()
        {
            trackOffset = 0;
            _extensionCoaster.Chunks.Clear();
            _extensionCoaster.Tracks.Clear();
            _extensionCoaster.TracksFinshed = _baseCoaster.TracksFinshed;
            _extensionCoaster.TracksStarted = _baseCoaster.TracksStarted;
        }

        public int GetLastBaseChunk()
        {
            return _baseCoaster.Chunks.Last();
        }

        //public bool TryPopBaseChunk()
        //{
        //    if(_baseCoaster.Chunks.Count() >= 2)
        //    {
        //        trackOffset = trackOffset - 1;
        //        //_baseCoaster.Tracks.RemoveRange(_baseCoaster.Tracks.Count() - _baseCoaster.Chunks.Last(), _baseCoaster.Chunks.Last());
        //        // _baseCoaster.Chunks.Remove(_baseCoaster.Chunks.Last());
        //        return true;
        //    }

        //    return false;
        //}
    }
}
