using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Animations;
using orsus_opengl.Enums;

namespace orsus_opengl.Interfaces
{
    public interface IEntity
    {
        AnimatedSprite CurrentAnimation { get; }
        float Speed { get; }
        Vector2 Scale { get; set; }
        Vector2 Position { get; set; }

        void Update(GameTime gameTime);
        void LoadContent(ContentManager content);
        void Draw(SpriteBatch spriteBatch, Vector2 position);

        void AddAnimationFrames(AnimationType type, ISpriteSheet spriteSheet, float frameDuration = 0.2F, bool loop = true);
        void SetAnimationType(AnimationType type);

        bool WalkLeft(GameTime time);
        bool WalkRight(GameTime time);
        bool Attack(GameTime time);
        bool Idle();
    }
}