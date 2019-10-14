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
        private readonly IUserActionOrchestrator _buildAction;
        public UserActions(IUserActionOrchestrator buildActionTypeOrchestrator)
        {
            _buildAction = buildActionTypeOrchestrator;
        }
        public BuildActionDescriptor Build(Coaster coaster, UserActionType uerActionType)
        {
            return _buildAction.ProcessBuildAction(coaster, uerActionType);
        }
        public Coaster CreateCoaster()
        {
            var coaster = new Coaster
            {
                Chunks = new List<int>(),
                Tracks = new List<Track>()
            };

            _buildAction.ProcessBuildAction(coaster, UserActionType.CreateStartingTracks);

            return coaster;
        }

    }
}
