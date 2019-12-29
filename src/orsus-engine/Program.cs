using orsus_engine.Scenes;
using orsus_engine.Services;
using orsus_engine.Structs;
using Veldrid.StartupUtilities;

namespace orsus_engine
{
    class Program
    {
        static void Main(string[] args)
        {
            var scene = new ColorQuad();
            var engine = new Orsus(scene);

            var resolution = new ScreenResolution(1920,1080);
            engine.Start(resolution);
        }
    }
}