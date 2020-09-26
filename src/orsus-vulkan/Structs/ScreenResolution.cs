namespace orsus_engine.Structs
{
    public struct ScreenResolution
    {
        public ScreenResolution(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; set; }
        public int Height {get; set;}
    }
}