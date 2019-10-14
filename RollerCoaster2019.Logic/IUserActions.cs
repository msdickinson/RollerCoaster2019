using RollerCoaster2019.Logic.Builder.DataTypes;
using RollerCoaster2019.Logic.DataTypes;

namespace RollerCoaster2019.Logic
{
    public interface IUserActions
    {
        BuildActionDescriptor Build(Coaster coaster, UserActionType uerActionType);
        Coaster CreateCoaster();
    }
}