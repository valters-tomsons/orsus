using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace orsus_opengl.Interfaces
{
    public interface IScene
    {
        void LoadContent(Game game, SpriteBatch spriteBatch);
        void DrawBackground(GameTime gameTime);
    }
}