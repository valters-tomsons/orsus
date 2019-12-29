namespace orsus_engine.Models
{
    public class OrsusConfiguration
    {
        public OrsusConfiguration()
        {
            EnableVulkanDebug = false;
            WindowTitle = "Orsus";
        }

        public bool EnableVulkanDebug { get; private set; }
        public string WindowTitle { get; private set; }
    }
}