using RollerCoaster2019.Contracts;

namespace RollerCoaster2019.Logic.Builder
{
    public interface IActionOrchestrator
    {
        TaskResults AutoCorrect(IBuildCoaster coaster, TaskResults buildActionType);
        TaskResults BuildAction(IBuildCoaster coaster, BuildActionType buildActionType);
        BuildActionDescriptor ProcessBuildAction(Coaster coaster, BuildActionType buildActionType);
    }
}