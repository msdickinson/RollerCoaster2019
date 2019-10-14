using RollerCoaster2019.Logic.Builder.DataTypes;
using RollerCoaster2019.Logic.DataTypes;

namespace RollerCoaster2019.Logic.Builder
{
    public interface IActionOrchestrator
    {
        BuildActionDescriptor ProcessBuildAction(Coaster coaster, UserActionType userActionType);
    }
}