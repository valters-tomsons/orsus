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

        private bool Rotate;
        private bool Attacking;

        public void LoadContent(ContentManager content) => throw new NotSupportedException();

        public void AddAnimationFrames(AnimationType type, ISpriteSheet spriteSheet, float frameDuration = 0.2F, bool loop = true)
        {
            var regions = new TextureRegion2D[spriteSheet.SpriteSections.Length];

            for(var i = 0; i < regions.Length; i++)
            {
                regions[i] = new TextureRegion2D(spriteSheet.SheetTexture, spriteSheet.SpriteSections[i]);
            }

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

            CurrentAnimation.Draw(spriteBatch, Location, 0f, Scale);
        }

        public void Idle()
        {
            SetAnimationType(AnimationType.Idle);
        }

        public void SetAnimationType(AnimationType type)
        {
            if(_animations[type] != CurrentAnimation)
            {
                Console.WriteLine($"{DateTime.Now.Ticks} - setting animation {type}");
                CurrentAnimation = _animations[type];
                CurrentAnimation.Play(type.ToString());
            }
        }

        public void Update(GameTime gameTime)
        {
            if(Rotate)
            {
                CurrentAnimation.Effect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                CurrentAnimation.Effect = SpriteEffects.None;
            }

            if (Attacking && _animations[AnimationType.Attack1] != CurrentAnimation)
            {
                SetAnimationType(AnimationType.Attack1);
                CurrentAnimation.Play(nameof(AnimationType.Attack1));
                Attacking = false;
            }

            foreach(var anim in _animations.Values)
            {
                anim.Update(gameTime);
            }

            // CurrentAnimation.Update(gameTime);
        }

        public void WalkLeft(GameTime time)
        {
            SetAnimationType(AnimationType.Walk);
            Rotate = true;

            Location.X -= Speed * time.ElapsedGameTime.Milliseconds;
        }

        public void WalkRight(GameTime time)
        {
            SetAnimationType(AnimationType.Walk);
            Rotate = false;

            Location.X += Speed * time.ElapsedGameTime.Milliseconds;
        }

        public void Attack(GameTime time)
        {
            if(!Attacking)
            {
                Attacking = true;
            }
        }
    }
}