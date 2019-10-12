using RollerCoaster2019.Contracts;

namespace RollerCoaster2019.Logic
{
    public interface IUserActions
    {
        BuildActionDescriptor Build(Coaster coaster, BuildActionType buildActionType);
        Coaster CreateCoaster();
    }
}