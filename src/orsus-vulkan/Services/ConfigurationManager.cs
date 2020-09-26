using System.IO;
using System.Text.Json;
using orsus_engine.Models;

namespace orsus_engine.Services
{
    public class ConfigurationManager
    {
        private OrsusConfiguration _configuration;
        private static readonly string ConfigurationPath = "orsus.config.json";

        public ConfigurationManager()
        {
            var config = SetConfigFromFile();
            if(!config)
            {
                _configuration = new OrsusConfiguration();
            }
        }

        public OrsusConfiguration GetConfiguration()
        {
            return _configuration;
        }

        private bool SetConfigFromFile()
        {
            if (!File.Exists(ConfigurationPath))
            {
                return false;
            }

            var config = File.ReadAllText(ConfigurationPath);
            var serializedConfig = JsonSerializer.Deserialize<OrsusConfiguration>(config);
            _configuration = serializedConfig;
            System.Console.WriteLine($"[ConfigurationManager] Configuration read from {ConfigurationPath}");
            return true;
        }
    }
}