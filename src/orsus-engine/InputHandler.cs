using System;
using Veldrid;

namespace orsus_engine
{
    public class InputHandler
    {
        public Action resPlus;

        public InputHandler()
        {

        }

        public void HandleInputs(InputSnapshot inputs)
        {
            var keys = inputs.KeyEvents;
            
            foreach (var key in keys)
            {
                if(key.Key == Key.Plus && key.Down)
                {
                    resPlus();
                }
            }
        }
    }
}