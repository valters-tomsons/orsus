using System.Reflection;
using System.Collections.Generic;
using System;
using QuakeConsole;

namespace orsus_opengl.Abstractions
{
    public class OrsusInterpreter : ICommandInterpreter
    {
        private readonly RoslynInterpreter _roslynInterpreter;
        private readonly Dictionary<string, Action<IConsoleOutput>> _commands = new Dictionary<string, Action<IConsoleOutput>>();

        public OrsusInterpreter()
        {
            _roslynInterpreter = new RoslynInterpreter()
            {
                EchoEnabled = false
            };

            _roslynInterpreter.AddAssembly(Assembly.GetEntryAssembly());

            _commands.Add("info", DisplayInfo);
        }

        public void AddVariable(string name, object obj)
        {
            _roslynInterpreter.AddVariable(name, obj);
        }

        public void Autocomplete(IConsoleInput input, bool forward)
        {
            throw new NotSupportedException();
        }

        public void Execute(IConsoleOutput output, string command)
        {
            var splitCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            output.Append($"> {command}");

            if(_commands.ContainsKey(splitCommand[0]))
            {
                _commands[splitCommand[0]](output);
            }
            else
            {
                command = $"globals.{command}";
                RedirectToRoslyn(output, command);
            }
        }

        public void DisplayInfo(IConsoleOutput output)
        {
            output.Append("OrsusGame 2020");
        }

        private void RedirectToRoslyn(IConsoleOutput output, string command)
        {
            _roslynInterpreter.Execute(output, command);
        }
    }
}