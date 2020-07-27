using System;
using System.Text;
using orsus_engine.Interfaces;
using orsus_engine.Scenes;
using orsus_engine.Structs;
using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;
using Vulkan;

namespace orsus_engine.Services
{
    public class Orsus
    {
        private Sdl2Window _window;
        private GraphicsDevice _device;
        private readonly IOrsusScene _scene;
        private readonly InputHandler _inputHandler = new InputHandler();
        private readonly ConfigurationManager _configuration = new ConfigurationManager();

        public Orsus(IOrsusScene scene)
        {
            _scene = scene;
            _inputHandler.orsusCallback = InputCallback;
        }

        public void Start(ScreenResolution resolution)
        {
            _window = CreateWindow(resolution);
            _device = InitializeGraphicsDevice(_window);

            PrintGraphicsDeviceName(_device);

            Start(_window, _device);
        }

        private unsafe void PrintGraphicsDeviceName(GraphicsDevice device)
        {
            var vkInfo = device.GetVulkanInfo();
            VulkanNative.vkGetPhysicalDeviceProperties(vkInfo.PhysicalDevice, out VkPhysicalDeviceProperties properties);

            const uint max = RawConstants.VK_MAX_PHYSICAL_DEVICE_NAME_SIZE;

            var kk = properties.deviceName;
            var nameArray = new byte[max];

            int lastEmptyIndex = 0;

            for (int i = 0; i < max; i++)
            {
                var val = kk[i];

                if (val != 0)
                {
                    nameArray[i] = kk[i];
                }
                else if(val == 0 && kk[i-1] != 0)
                {
                    lastEmptyIndex = i;
                }
            }

            var str = Encoding.UTF8.GetString(nameArray, 0, lastEmptyIndex);
            Console.WriteLine(str);
        }

        private void InputCallback()
        {
            if (_window.WindowState == WindowState.Normal)
            {
                _window.WindowState = WindowState.BorderlessFullScreen;
            }
            else if (_window.WindowState == WindowState.BorderlessFullScreen)
            {
                _window.WindowState = WindowState.Normal;
            }
        }

        private void Start(Sdl2Window window, GraphicsDevice device)
        {
            _scene.CreateResources(device);

            while (window.Exists)
            {
                var input = window.PumpEvents();
                _inputHandler.HandleInputs(input);

                _scene.Draw(device);
            }

            DisposeResources(device);
        }

        private void DisposeResources(GraphicsDevice device)
        {
            _scene.DisposeResources();
            device.Dispose();
        }

        private Sdl2Window CreateWindow(ScreenResolution resolution)
        {
            var osDesc = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            var windowInfo = new WindowCreateInfo
            {
                WindowWidth = resolution.Width,
                WindowHeight = resolution.Height,
                WindowTitle = $"{_configuration.GetConfiguration().WindowTitle} ({osDesc})",
                X = Sdl2Native.SDL_WINDOWPOS_CENTERED,
                Y = Sdl2Native.SDL_WINDOWPOS_CENTERED
            };

            var window = VeldridStartup.CreateWindow(ref windowInfo);
            return window;
        }

        private GraphicsDevice InitializeGraphicsDevice(Sdl2Window window)
        {
            var options = new GraphicsDeviceOptions
            {
                Debug = _configuration.GetConfiguration().EnableVulkanDebug,
            };

            var device = VeldridStartup.CreateVulkanGraphicsDevice(options, window);
            return device;
        }
    }
}