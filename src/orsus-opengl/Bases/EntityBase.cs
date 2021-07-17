using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Animations;
using MonoGame.Extended.Animations.SpriteSheets;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;
using orsus_opengl.Enums;
using orsus_opengl.Helpers;
using orsus_opengl.Interfaces;

namespace orsus_opengl.Bases
{
    public class EntityBase : IEntity
    {
        public AnimatedSprite CurrentAnimation { get; private set; }

        private readonly Dictionary<AnimationType, AnimatedSprite> _animations = new Dictionary<AnimationType, AnimatedSprite>();

        public Vector2 Location;

        public float Speed { get; set; }
        public Vector2 Scale { get; set; } = new Vector2(1);

        public AnimatedSprite sprite;

        private bool Rotate;
        private bool Attacking;

        public void LoadContent(ContentManager content) => throw new NotSupportedException();

        public void AddAnimationFrames(AnimationType type, ISpriteSheet spriteSheet, float frameDuration = 0.2F, bool loop = true)
        {
            var regions = SpriteSheetHelper.SpriteSheetToTextureRegions(spriteSheet);

            var animFac = new SpriteSheetAnimationFactory(regions);

            animFac.Add(type.ToString(), new SpriteSheetAnimationData(Enumerable.Range(0, regions.Length).ToArray(), frameDuration: frameDuration, isLooping: loop));

            var animation = new AnimatedSprite(animFac);

            _animations.Add(type, animation);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            if (Location == default)
            {
                Location = position;
            }

            // CurrentAnimation.Draw(spriteBatch, Location, 0f, Scale);
            sprite.Draw(spriteBatch, Location, 0f, Scale);
        }

        public bool Idle()
        {
            if(!Attacking)
            {
                sprite.Play("player_idle");
                return true;
            }

            return false;
        }

        public void SetAnimationType(AnimationType type)
        {
            // if(_animations[type] != CurrentAnimation)
            // {
            //     CurrentAnimation = _animations[type];
            //     CurrentAnimation.Play(type.ToString());
            // }
        }

        public void Update(GameTime gameTime)
        {
            if(Rotate)
            {
                sprite.Effect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                sprite.Effect = SpriteEffects.None;
            }

            if (Attacking)
            {
                // SetAnimationType(AnimationType.Attack1);
                // CurrentAnimation.Play(nameof(AnimationType.Attack1));
                // Attacking = false;
            }

            // CurrentAnimation.Update(gameTime);
            sprite.Update(gameTime);
        }

        public bool WalkLeft(GameTime time)
        {
            if(!Attacking)
            {
                sprite.Play("player_walk");
                Rotate = true;
                Location.X -= Speed * time.ElapsedGameTime.Milliseconds;
                return true;
            }
            return false;
        }

        public bool WalkRight(GameTime time)
        {
            if(!Attacking)
            {
                sprite.Play("player_walk");
                Rotate = false;
                Location.X += Speed * time.ElapsedGameTime.Milliseconds;
                return true;
            }
            return false;
        }

        public bool Attack(GameTime time)
        {
            if(!Attacking)
            {
                Attacking = true;
                sprite.Play("player_attack", AttackEnd);
                return true;
            }
            return false;
        }

        private void AttackEnd()
        {
            Attacking = false;
        }
    }
}