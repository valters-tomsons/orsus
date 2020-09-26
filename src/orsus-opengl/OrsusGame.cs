using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Animations;
using MonoGame.Extended.Animations.SpriteSheets;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;
using orsus_opengl.Entities;
using orsus_opengl.Models;
using orsus_opengl.Enums;
using orsus_opengl.Interfaces;

namespace orsus_opengl
{
    public class OrsusGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont _spriteFont;
        private IEntity _merchant;

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
            _spriteFont = Content.Load<SpriteFont>("Roboto");

            var merchant_IdleTexture = Content.Load<Texture2D>("merchant_idle");
            var merchant_IdleSheet = new SpriteSheet(merchant_IdleTexture, 4, 64);

            var merchant_walkTexture = Content.Load<Texture2D>("merchant_walk");
            var merchant_walkSheet = new SpriteSheet(merchant_walkTexture, 5, 64);

            var merchantEntity = new MerchantEntity();
            merchantEntity.AddAnimationFrames(AnimationType.Idle, merchant_IdleSheet, 0.25f);
            merchantEntity.AddAnimationFrames(AnimationType.Walk, merchant_walkSheet, 0.09f);

            merchantEntity.SetAnimationType(AnimationType.Idle);

            _merchant = merchantEntity;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if(Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _merchant.SetAnimationType(AnimationType.Walk);
            }
            else{
                _merchant.SetAnimationType(AnimationType.Idle);
            }

            _frameRate = 1 / gameTime.ElapsedGameTime.TotalSeconds;
            _merchant.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            var x = (GraphicsDevice.Viewport.Width / 2 ) - _merchant.CurrentAnimation.TextureRegion.Width;
            var y = (GraphicsDevice.Viewport.Height / 2 ) - _merchant.CurrentAnimation.TextureRegion.Height;

            _spriteBatch.Begin(default, default, SamplerState.PointClamp, default, default, default, default);

            _merchant.Draw(_spriteBatch, new Vector2(x, y));

            _spriteBatch.DrawString(_spriteFont, $"Framerate: {_frameRate}", new Vector2(20), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
