using System;
using RollerCoaster2019.Logic.DataTypes;
using RollerCoaster2019.Logic.Rider.DataTypes;

namespace RollerCoaster2019.Logic.Rider
{
    public interface IRiderOrchestrator
    {
        CartLocation Process(Coaster coaster, TimeSpan timeSpan);
    }
}