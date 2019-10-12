using RollerCoaster2019.Contracts;

namespace RollerCoaster2019.Logic.Builder
{
    public interface ITrackRules
    {
        bool Collison(IBuildCoaster coaster, float x, float y, float z);
        bool MaxX(float x);
        bool MaxY(float y);
        bool MinX(float x);
        bool MinY(float y);
        bool MinZ(float yaw, float pitch, float z);
    }
}