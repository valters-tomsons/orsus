using Microsoft.Xna.Framework;

namespace orsus_opengl.Interfaces
{
    public interface IConsole
    {
        void Initialize();
        void ToggleConsole();
        bool CanAcceptInput();
        void TrackVariable(string name, object obj);
    }
}