using BenchmarkDotNet.Running;
using RollerCoaster2019.LoadTests.Benchmarks;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        BenchmarkRunner.Run<Collision>();
    }
}