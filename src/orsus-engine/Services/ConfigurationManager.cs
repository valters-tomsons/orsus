using orsus_engine.Models;

namespace orsus_engine.Services
{
    public class ConfigurationManager
    {
        private static readonly OrsusConfiguration _configuration = new OrsusConfiguration();

        public ConfigurationManager()
        {

        }

        public OrsusConfiguration GetConfiguration()
        {
            return _configuration;
        }
    }
}