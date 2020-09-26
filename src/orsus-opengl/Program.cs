using System;

namespace orsus_opengl
{
    public static class Program
    {
        [STAThread]
        internal static void Main()
        {
            using var game = new OrsusGame();
            game.Run();
        }
    }
}
