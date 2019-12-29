using orsus_engine.Services;
using Veldrid.StartupUtilities;

namespace orsus_engine
{
    class Program
    {
        static readonly Orsus engine = new Orsus();

        static void Main(string[] args)
        {
            var windowInfo = new WindowCreateInfo()
            {
                WindowWidth = 1920,
                WindowHeight = 1080,
                WindowTitle = "Orsus",
            };

            engine.Start(windowInfo);
        }
    }
}