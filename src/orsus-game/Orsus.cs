using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;

namespace orsus_game
{
    public class Orsus
    {
        GraphicsManager _manager = new GraphicsManager();
        

        public Orsus()
        {
            var window = CreateWindow();
            var device = InitializeGraphicsDevice(window);
            StartOrsus(window, device);
        }

        public void StartOrsus(Sdl2Window window, GraphicsDevice device)
        {
            CreateResources(device);

            while(window.Exists)
            {
                window.PumpEvents();
                _manager.Draw(device);
            }

            DisposeResources(device);
        }

        private void CreateResources(GraphicsDevice device)
        {
            _manager.CreateResources(device);
        }

        private void DisposeResources(GraphicsDevice device)
        {
            System.Console.WriteLine("Disposing");
            _manager.DisposeResources();
            device.Dispose();
        }

        private Sdl2Window CreateWindow()
        {
            var windowCi = new WindowCreateInfo()
            {
                X = 100,
                Y = 100,
                WindowWidth = 1280,
                WindowHeight = 720,
                WindowTitle = "Orsus Window"
            };

            var window = VeldridStartup.CreateWindow(ref windowCi);
            return window;
        }

        private GraphicsDevice InitializeGraphicsDevice(Sdl2Window window)
        {
            var options = new GraphicsDeviceOptions
            {
                Debug = false,
                PreferStandardClipSpaceYDirection = true
            };

            var device = VeldridStartup.CreateVulkanGraphicsDevice(options, window);
            return device;
        }
    }
}