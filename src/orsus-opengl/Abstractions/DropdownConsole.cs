using Microsoft.Xna.Framework;
using orsus_opengl.Interfaces;
using QuakeConsole;

namespace orsus_opengl.Abstractions
{
    public class DropdownConsole : ConsoleComponent, IConsole
    {
        public DropdownConsole(Game game) : base(game)
        {
            Interpreter = new OrsusInterpreter(game);
            game.Components.Add(this);
        }

        public void ToggleConsole()
        {
            ToggleOpenClose();
        }

        public bool CanAcceptInput()
        {
            return IsAcceptingInput;
        }

        new public void Initialize()
        {
            base.Initialize();
        }
    }
}