using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using orsus_opengl.Interfaces;

namespace orsus_opengl.Bases
{
    public class SceneBase : IScene
    {
        private Texture2D Background { get; set; }
        private SpriteBatch _spriteBatch {get; set;}

        public SceneBase()
        {

        }

        public void Initialize(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        public void LoadContent(Game game, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            Background = game.Content.Load<Texture2D>("background");
        }

        public void DrawBackground(GameTime gameTime)
        {
            _spriteBatch.Draw(Background, new Vector2(0,0), null, Color.White, 0f, default, new Vector2(10), SpriteEffects.None, default);
        }
    }
}