using orsus_engine.Structs;
using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;

namespace orsus_engine.Services
{
    public class Orsus
    {
        private Sdl2Window _window;
        private GraphicsDevice _device;
        private readonly GraphicsManager _manager = new GraphicsManager();
        private readonly InputHandler _inputHandler = new InputHandler();
        private readonly ConfigurationManager _configuration = new ConfigurationManager();
        
        public Orsus()
        {

        }

        public void Start(ScreenResolution resolution)
        {
            _window = CreateWindow(resolution);
            _device = InitializeGraphicsDevice(_window);

            Start(_window, _device);
        }

        private void Start(Sdl2Window window, GraphicsDevice device)
        {
            _manager.CreateResources(device);

            while(window.Exists)
            {
                var input = window.PumpEvents();
                _inputHandler.HandleInputs(input);

                _manager.Draw(device);
            }

            DisposeResources(device);
        }

        private void DisposeResources(GraphicsDevice device)
        {
            _manager.DisposeResources();
            device.Dispose();
        }

        private Sdl2Window CreateWindow(ScreenResolution resolution)
        {
            var osDesc = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            var windowInfo = new WindowCreateInfo
            {
                WindowWidth = resolution.Width,
                WindowHeight = resolution.Height,
                WindowTitle = $"{_configuration.GetConfiguration().WindowTitle} ({osDesc})"
            };

            var window = VeldridStartup.CreateWindow(ref windowInfo);
            return window;
        }

        private GraphicsDevice InitializeGraphicsDevice(Sdl2Window window)
        {
            var options = new GraphicsDeviceOptions
            {
                Debug = _configuration.GetConfiguration().EnableVulkanDebug
            };

            var device = VeldridStartup.CreateVulkanGraphicsDevice(options, window);
            return device;
        }
    }
}