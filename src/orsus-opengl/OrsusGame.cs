using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using orsus_opengl.Entities;
using orsus_opengl.Models;
using orsus_opengl.Enums;
using orsus_opengl.Interfaces;
using orsus_opengl.Abstractions;
using orsus_opengl.Bases;

namespace orsus_opengl
{
    public class OrsusGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont _spriteFont;

        private readonly IScene _scene;
        private IEntity _player;

        private double _frameRate = 0;

        public OrsusGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _scene = new SceneBase();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            IsFixedTimeStep = false;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _scene.LoadContent(this, _spriteBatch);

            _spriteFont = Content.Load<SpriteFont>("Roboto");

            var player_idleTexture = Content.Load<Texture2D>("player_idle");
            var player_idleSheet = new LinearSpriteSheet(player_idleTexture, sections: 11, spriteSize: 180);
            var player_walkTexture = Content.Load<Texture2D>("player_walk");
            var player_walkSheet = new LinearSpriteSheet(player_walkTexture, sections: 8, spriteSize: 180);

            var playerEntity = new PlayerEntity();
            playerEntity.AddAnimationFrames(AnimationType.Idle, player_idleSheet, frameDuration: 0.1f);
            playerEntity.AddAnimationFrames(AnimationType.Walk, player_walkSheet, frameDuration: 0.1f);

            _player = playerEntity;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if(Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _player.WalkRight(gameTime);
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _player.WalkLeft(gameTime);
            }
            else{
                _player.Idle();
            }

            _player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            var x = GraphicsDevice.Viewport.Width / 2 ;
            var y = GraphicsDevice.Viewport.Height / 2;

            _frameRate = 1 / gameTime.ElapsedGameTime.TotalSeconds;

            using(new BatchDrawing(_spriteBatch))
            {
                _scene.DrawBackground(gameTime);

                _player.Draw(_spriteBatch, new Vector2(x, y));

                _spriteBatch.DrawString(_spriteFont, $"Framerate: {_frameRate}", new Vector2(20), Color.White);
            }

            base.Draw(gameTime);
        }
    }
}
