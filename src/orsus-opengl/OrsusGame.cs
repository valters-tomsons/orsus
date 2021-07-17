using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using orsus_opengl.Entities;
using orsus_opengl.Interfaces;
using orsus_opengl.Bases;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace orsus_opengl
{
    public class OrsusGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;

        private SpriteBatch _worldBatch;
        private SpriteBatch _uiBatch;

        private SpriteFont _spriteFont;

        private readonly IScene _scene;
        private readonly IEntity _player;
        private OrthographicCamera _camera;

        private double _frameRate = 0;

        public OrsusGame()
        {
            _graphics = new GraphicsDeviceManager(this);

            _scene = new SceneBase();
            _player = new PlayerEntity();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            IsFixedTimeStep = false;
            base.Initialize();

            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 1920, 1080);
            _camera = new OrthographicCamera(viewportAdapter);
        }

        protected override void LoadContent()
        {
            _worldBatch = new SpriteBatch(GraphicsDevice);
            _uiBatch = new SpriteBatch(GraphicsDevice);
            _spriteFont = Content.Load<SpriteFont>("Roboto");

            _scene.LoadContent(Content, _worldBatch);
            _player.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if(Keyboard.GetState().IsKeyDown(Keys.OemTilde))
            {
                base.Update(gameTime);
                return;
            }

            if(Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if(_player.WalkRight(gameTime))
                {
                    _camera.Move(Vector2.UnitX * 1f * gameTime.ElapsedGameTime.Milliseconds);
                }
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if(_player.WalkLeft(gameTime))
                {
                    _camera.Move(-Vector2.UnitX * 1f * gameTime.ElapsedGameTime.Milliseconds);
                }
            }
            else if(Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                _player.Attack(gameTime);
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

            _worldBatch.Begin(default, default, SamplerState.PointClamp, default, default, default, _camera.GetViewMatrix());

            _scene.DrawBackground(gameTime);
            _player.Draw(_worldBatch, new Vector2(x, y));

            _worldBatch.End();

            _uiBatch.Begin(default, default, SamplerState.PointClamp, default, default, default, default);
            _uiBatch.DrawString(_spriteFont, $"Framerate: {_frameRate}", new Vector2(20), Color.White);
            _uiBatch.DrawString(_spriteFont, $"Camera: {_camera.Position}", new Vector2(40), Color.White);
            _uiBatch.End();

            base.Draw(gameTime);
        }
    }
}
