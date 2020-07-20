using orsus_engine.Scenes;
using orsus_engine.Services;
using orsus_engine.Structs;

namespace orsus_engine
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var scene = new ColorQuad();
            // var scene = new TextureCube();

            var engine = new Orsus(scene);

            var resolution = new ScreenResolution(1920, 1080);
            engine.Start(resolution);
        }
    }
}