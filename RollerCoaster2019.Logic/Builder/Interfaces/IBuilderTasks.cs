using RollerCoaster2019.Contracts;

namespace RollerCoaster2019.Logic.Builder
{
    public interface IBuilderTasks
    {
        TaskResults BuildStright(IBuildCoaster coaster);
        TaskResults BuildUp(IBuildCoaster coaster);
        TaskResults BuildDown(IBuildCoaster coaster);
        TaskResults BuildLeft(IBuildCoaster coaster);
        TaskResults BuildRight(IBuildCoaster coaster);
        TaskResults RemoveChunk(IBuildCoaster coaster);
        TaskResults BuildStartingTracks(IBuildCoaster coaster);
    }
}