using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using orsus_opengl.Interfaces;

namespace orsus_opengl.Bases
{
    public class SceneBase : IScene
    {
        private Texture2D Background { get; set; }
        private SpriteBatch SpriteBatch {get; set;}

        public void Initialize(SpriteBatch spriteBatch)
        {
            SpriteBatch = spriteBatch;
        }

        public void LoadContent(ContentManager game, SpriteBatch spriteBatch)
        {
            SpriteBatch = spriteBatch;
            Background = game.Load<Texture2D>("background");
        }

        public void DrawBackground(GameTime gameTime)
        {
            SpriteBatch.Draw(Background, new Vector2(0,0), null, Color.White, 0f, default, new Vector2(10), SpriteEffects.None, default);
        }
    }
}