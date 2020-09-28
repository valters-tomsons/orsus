using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Animations;
using MonoGame.Extended.Animations.SpriteSheets;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;
using orsus_opengl.Enums;
using orsus_opengl.Interfaces;

namespace orsus_opengl.Entities
{
    public class Entity : IEntity
    {
        public AnimatedSprite CurrentAnimation { get; private set; }

        private readonly Dictionary<AnimationType, AnimatedSprite> _animations = new Dictionary<AnimationType, AnimatedSprite>();

        public Vector2 Location;

        public float Speed { get; set; }

        public void AddAnimationFrames(AnimationType type, ISpriteSheet spriteSheet, float frameDuration = 0.2F)
        {
            var regions = new TextureRegion2D[spriteSheet.SpriteSections.Length];

            for(var i = 0; i < regions.Length; i++)
            {
                regions[i] = new TextureRegion2D(spriteSheet.SheetTexture, spriteSheet.SpriteSections[i]);
            }

            var animFac = new SpriteSheetAnimationFactory(regions);

            animFac.Add(type.ToString(), new SpriteSheetAnimationData(Enumerable.Range(0, regions.Length).ToArray(), frameDuration: frameDuration, isLooping: true));

            var animation = new AnimatedSprite(animFac, type.ToString());

            _animations.Add(type, animation);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            if (Location == default)
            {
                Location = position;
            }

            CurrentAnimation.Draw(spriteBatch, Location, 0f, new Vector2(15));
        }

        public void Idle()
        {
            CurrentAnimation = _animations[AnimationType.Idle];
        }

        public void SetAnimationType(AnimationType type)
        {
            if(_animations[type] != CurrentAnimation)
            CurrentAnimation = _animations[type];
        }

        private void SetEffect(SpriteEffects effect)
        {
            foreach(var animation in _animations.Values)
            {
                animation.Effect = effect;
            }
        }

        public void Update(GameTime gameTime)
        {
            CurrentAnimation.Update(gameTime);
        }

        public void WalkLeft(GameTime time)
        {
            CurrentAnimation = _animations[AnimationType.Walk];
            SetEffect(SpriteEffects.FlipHorizontally);

            Location.X -= Speed * time.ElapsedGameTime.Milliseconds;
        }

        public void WalkRight(GameTime time)
        {
            CurrentAnimation = _animations[AnimationType.Walk];
            SetEffect(SpriteEffects.None);

            Location.X += Speed * time.ElapsedGameTime.Milliseconds;
        }
    }
}