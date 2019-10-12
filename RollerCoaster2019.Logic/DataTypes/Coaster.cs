using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RollerCoaster2019.Logic.DataTypes
{
    public class Coaster 
    {
        public bool TracksStarted { get; set; }
        public bool TracksFinshed { get; set; }
        public bool TracksInFinshArea { get; set; }
        public List<Track> Tracks { get; set; }
        public List<int> Chunks { get; set; }
    }
}
