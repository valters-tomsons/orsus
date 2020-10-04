using Microsoft.Xna.Framework;
using orsus_opengl.Interfaces;
using QuakeConsole;

namespace orsus_opengl.Abstractions
{
    public class DropdownConsole : ConsoleComponent, IConsole
    {
        private readonly OrsusInterpreter interpreter;

        public DropdownConsole(Game game) : base(game)
        {
            interpreter = new OrsusInterpreter(game);
            Interpreter = interpreter;

            InputPrefix = "~> ";
            InputPrefixColor = Color.Pink;
            FontColor = Color.White;

            game.Components.Add(this);
        }

        public void TrackVariable(string name, object obj)
        {
            interpreter.AddVariable(name, obj);
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