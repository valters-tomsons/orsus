using System;
using Microsoft.Xna.Framework.Graphics;

namespace orsus_opengl.Abstractions
{
    public class BatchDrawing : IDisposable
    {
        private readonly SpriteBatch _spriteBatch;

        public BatchDrawing(SpriteBatch spriteBatch, SamplerState state)
        {
            _spriteBatch = spriteBatch;
            _spriteBatch.Begin(default, default, state, default, default, default, default);
        }

        public void Dispose()
        {
            _spriteBatch.End();
        }
    }
}