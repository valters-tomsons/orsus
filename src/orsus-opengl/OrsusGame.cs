using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using orsus_opengl.Models;

namespace orsus_opengl
{
    public class OrsusGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteSheet _character;

        public OrsusGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var charTex = Content.Load<Texture2D>("idle");
            _character = new SpriteSheet(charTex, 4, 64);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        private int charState = 0;

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            var x = (GraphicsDevice.Viewport.Width / 2 ) - 64;
            var y = (GraphicsDevice.Viewport.Height / 2 ) - 64;

            _spriteBatch.Begin(default, default, SamplerState.PointClamp, default, default, default, default);

            Rectangle spriteRec;

            if(charState < 4)
            {
                spriteRec = _character.SpriteSections[charState];
                charState++;
            }
            else{
                charState = 0;
                spriteRec = _character.SpriteSections[charState];
            }

            _spriteBatch.Draw(_character.SheetTexture,
                                new Rectangle(x, y, 256, 256),
                                spriteRec,
                                Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
