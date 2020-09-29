using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace orsus_opengl.Interfaces
{
    public interface IScene
    {
        void LoadContent(ContentManager content, SpriteBatch spriteBatch);
        void DrawBackground(GameTime gameTime);
    }
}