using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Animations;
using MonoGame.Extended.Animations.SpriteSheets;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;
using orsus_opengl.Entities;
using orsus_opengl.Interfaces;
using orsus_opengl.Models;

namespace orsus_opengl
{
    public class OrsusGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private AnimatedSprite _merchantIdle;
        private SpriteFont _spriteFont;

        private double _frameRate = 0;

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

            var merchantTexture = Content.Load<Texture2D>("merchant_idle");
            var merchantSprites = new SpriteSheet(merchantTexture, 4, 64);

            _spriteFont = Content.Load<SpriteFont>("Roboto");

            var regions = new TextureRegion2D[merchantSprites.SpriteSections.Length];

            for(var i = 0; i < regions.Length; i++)
            {
                regions[i] = new TextureRegion2D(merchantTexture, merchantSprites.SpriteSections[i]);
            }

            var animFac = new SpriteSheetAnimationFactory(regions);

            animFac.Add("idle", new SpriteSheetAnimationData(new[] {0, 1, 2, 3}, isLooping: true));
            _merchantIdle = new AnimatedSprite(animFac, "idle");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _frameRate = 1 / gameTime.ElapsedGameTime.TotalSeconds;
            _merchantIdle.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            var x = (GraphicsDevice.Viewport.Width / 2 ) - _merchantIdle.TextureRegion.Width;
            var y = (GraphicsDevice.Viewport.Height / 2 ) - _merchantIdle.TextureRegion.Height;

            _spriteBatch.Begin(default, default, SamplerState.PointClamp, default, default, default, default);

            _merchantIdle.Draw(_spriteBatch, new Vector2(x, y), 0f, new Vector2(18));

            _spriteBatch.DrawString(_spriteFont, _frameRate.ToString(), new Vector2(20), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
