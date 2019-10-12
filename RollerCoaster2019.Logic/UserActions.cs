using RollerCoaster2019.Contracts;
using RollerCoaster2019.Logic.Builder;
using RollerCoaster2019.Logic.Builder.DataTypes;
using RollerCoaster2019.Logic.DataTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollerCoaster2019.Logic
{
    public class UserActions : IUserActions
    {
        private readonly IActionOrchestrator _buildAction;
        public UserActions(IActionOrchestrator buildActionTypeOrchestrator)
        {
            _buildAction = buildActionTypeOrchestrator;
        }
        public BuildActionDescriptor Build(Coaster coaster, BuildActionType buildActionType)
        {
            return _buildAction.ProcessBuildAction(coaster, buildActionType);
        }
        public Coaster CreateCoaster()
        {
            var coaster = new Coaster
            {
                Chunks = new List<int>(),
                Tracks = new List<Track>()
            };

            _buildAction.ProcessBuildAction(coaster, BuildActionType.CreateStartingTracks);

            return coaster;
        }

    }
}
