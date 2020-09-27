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
using orsus_opengl.Models;

namespace orsus_opengl.Entities
{
    public class MerchantEntity : IEntity
    {
        public AnimatedSprite CurrentAnimation { get; private set; }

        private readonly Dictionary<AnimationType, AnimatedSprite> _animations = new Dictionary<AnimationType, AnimatedSprite>();

        private Vector2 _location;

        public MerchantEntity()
        {

        }

        public void AddAnimationFrames(AnimationType type, SpriteSheet spriteSheet, float frameDuration = 0.2f)
        {
            var regions = new TextureRegion2D[spriteSheet.SpriteSections.Length];

            for(var i = 0; i < regions.Length; i++)
            {
                regions[i] = new TextureRegion2D(spriteSheet.SheetTexture, spriteSheet.SpriteSections[i]);
            }

            var animFac = new SpriteSheetAnimationFactory(regions);

            animFac.Add(type.ToString(), new SpriteSheetAnimationData(Enumerable.Range(0, regions.Length).ToArray(), frameDuration: frameDuration, isLooping: true));

            var animation = new AnimatedSprite(animFac, type.ToString())
            {
                Origin = new Vector2(32, 32)
            };

            _animations.Add(type, animation);
        }

        public void Idle()
        {
            CurrentAnimation = _animations[AnimationType.Idle];
        }

        public void WalkLeft()
        {
            CurrentAnimation = _animations[AnimationType.Walk];
            SetEffect(SpriteEffects.FlipHorizontally);

            _location.X -= 5;
        }

        public void WalkRight()
        {
            CurrentAnimation = _animations[AnimationType.Walk];
            SetEffect(SpriteEffects.None);

            _location.X += 5;
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

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            if (_location == default)
            {
                _location = position;
            }

            CurrentAnimation.Draw(spriteBatch, _location, 0f, new Vector2(15));
        }
    }
}