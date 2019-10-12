//using RollerCoaster2019.Contracts;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace RollerCoaster2019.Logic.Builder.BuildCoaster
//{
//    public class BuildIBuildCoaster : IBuildCoaster
//    {
//        private IBuildCoaster _baseCoaster;
//        private IBuildCoaster _IBuildCoaster;
//        int offset = 0;

//        public BuildIBuildCoaster(IBuildCoaster baseCoaster)
//        {
//            _baseCoaster = baseCoaster;
//        }

//        public bool TracksFinshed 
//        { 
//            get => _baseCoaster.TracksFinshed;
//            set => _baseCoaster.TracksFinshed = value;
//        }
//        public bool TracksInFinshArea
//        {
//            get => _baseCoaster.TracksInFinshArea;
//            set => _baseCoaster.TracksInFinshArea = value;
//        }
//        public bool TracksStarted
//        {
//            get => _baseCoaster.TracksStarted;
//            set => _baseCoaster.TracksStarted = value;
//        }

//        public Track GetTrack(int index)
//        {
//            if (index < 0 || index >= this.TrackCount())
//            {
//                throw (new Exception("Out Of Range"));
//            }

//            if (_baseCoaster.TrackCount() - offset > index)
//            {
//                return _baseCoaster.GetTrack(index);
//            }

//            return _IBuildCoaster.GetTrack(index);
//        }

//        public Track LastTrack()
//        {
//            if (_IBuildCoaster.TrackCount() > 0)
//            {
//                return _IBuildCoaster.LastTrack();
//            }
//            else if (_baseCoaster.TrackCount() > 0)
//            {
//                return _baseCoaster.LastTrack();
//            }

//            throw (new Exception("No Tracks Exist"));
//        }

//        public void Merge()
//        {
//            ////Might be off by one
//            //_baseCoaster.Tracks.RemoveRange(_baseCoaster.Tracks.Count() + offset, Math.Abs(offset));
//            //_baseCoaster.Tracks.AddRange(_IBuildCoaster.Tracks);

//            ////Chunk
//            //var trackCount = _baseCoaster.Tracks.Count();
//            //var chunkSum = _baseCoaster.Chunks.Sum();

//            //while (chunkSum > trackCount)
//            //{
//            //    _baseCoaster.Chunks.Remove(_baseCoaster.Chunks.Last());
//            //}
//            //if (chunkSum < trackCount)
//            //{
//            //    _baseCoaster.Chunks.Add(trackCount - chunkSum);
//            //}
//        }

//        public void PopTrack()
//        {
//            throw new NotImplementedException();
//        }

//        public void PushTrack(Track track)
//        {
//            //_IBuildCoaster.Tracks.Add(track);
//        }

//        public void ResetCoaster()
//        {
//            throw new NotImplementedException();
//        }

//        public int TrackCount()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
