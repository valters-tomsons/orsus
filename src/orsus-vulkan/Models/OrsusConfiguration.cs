namespace orsus_engine.Models
{
    public class OrsusConfiguration
    {
        public OrsusConfiguration()
        {
        }

        public bool EnableVulkanDebug { get; set; } = false;
        public string WindowTitle { get; set; } = "Orsus";
    }
}