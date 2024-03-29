﻿using RollerCoaster2019.Contracts;
using RollerCoaster2019.Logic.Builder.DataTypes;

namespace RollerCoaster2019.Logic.Builder
{
    public interface IBuilderTasksOrchestrator
    {
        TaskResults BuildAction(IBuildCoaster coaster, BuildActionType buildActionType);
    }
}