using System;
using Microsoft.Xna.Framework.Graphics;

namespace orsus_opengl.Abstractions
{
    public class BatchDrawing : IDisposable
    {
        private readonly SpriteBatch _spriteBatch;

        public BatchDrawing(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _spriteBatch.Begin(default, default, SamplerState.PointClamp, default, default, default, default);
        }

        public void Dispose()
        {
            _spriteBatch.End();
        }
    }
}