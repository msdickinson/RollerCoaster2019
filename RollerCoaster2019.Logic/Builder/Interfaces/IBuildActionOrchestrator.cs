using System.Collections.Generic;
using RollerCoaster2019.Contracts;

namespace RollerCoaster2019.Logic.Builder
{
    public interface IBuildActionOrchestrator
    {
        TaskResults ProcessBuildAction(IBuildCoaster coaster, BuildAction buildAction);
        TaskResults ProcessBuildActions(IBuildCoaster coaster, IEnumerable<BuildAction> buildActions);
    }
}