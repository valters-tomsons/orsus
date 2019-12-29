using orsus_engine.Services;
using orsus_engine.Structs;
using Veldrid.StartupUtilities;

namespace orsus_engine
{
    class Program
    {
        static readonly Orsus engine = new Orsus();

        static void Main(string[] args)
        {
            var resolution = new ScreenResolution(1920,1080);
            engine.Start(resolution);
        }
    }
}