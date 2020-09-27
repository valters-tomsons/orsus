using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Animations;
using orsus_opengl.Enums;

namespace orsus_opengl.Interfaces
{
    public interface IEntity
    {
        AnimatedSprite CurrentAnimation { get; }

        void AddAnimationFrames(AnimationType type, ISpriteSheet spriteSheet, float frameDuration = 0.2f);
        void SetAnimationType(AnimationType type);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 position);
        void WalkLeft();
        void WalkRight();
        void Idle();
    }
}