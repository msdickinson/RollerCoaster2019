using RollerCoaster2019.Logic.DataTypes;
using RollerCoaster2019.Logic.Rider.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollerCoaster2019.Logic.Rider
{
    public class RiderOrchestrator : IRiderOrchestrator
    {
        public CartLocation Process(Coaster coaster, TimeSpan timeSpan)
        {
            var cartLocation = new CartLocation();

            return cartLocation;
        }
    }
}
