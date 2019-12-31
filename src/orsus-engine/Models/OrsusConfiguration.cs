namespace orsus_engine.Models
{
    public class OrsusConfiguration
    {
        public OrsusConfiguration()
        {
        }

        public bool EnableVulkanDebug { get; private set; } = false;
        public string WindowTitle { get; private set; } = "Orsus";
    }
}