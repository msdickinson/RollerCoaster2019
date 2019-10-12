namespace RollerCoaster2019.LoadTests.Benchmarks
{
    public interface ICollision
    {
        void BuildStright();
        void IterationCleanup();
        void IterationSetup();
    }
}