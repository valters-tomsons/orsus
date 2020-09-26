using System;
using Veldrid;

namespace orsus_engine.Services
{
    public class InputHandler
    {
        public Action orsusCallback;

        public InputHandler()
        {

        }

        public void HandleInputs(InputSnapshot inputs)
        {
            var keys = inputs.KeyEvents;
            
            foreach (var key in keys)
            {
                if(key.Key == Key.F11 && key.Down)
                {
                    orsusCallback();
                }
            }
        }
    }
}