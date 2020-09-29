using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using orsus_opengl.Bases;
using orsus_opengl.Enums;
using orsus_opengl.Interfaces;
using orsus_opengl.Models;

namespace orsus_opengl.Entities
{
    public class PlayerEntity : EntityBase, IEntity
    {
        public PlayerEntity()
        {
            Speed = 1f;
            Scale = new Vector2(5);
        }

        void IEntity.LoadContent(ContentManager content)
        {
            var player_idleTexture = content.Load<Texture2D>("player_idle");
            var player_walkTexture = content.Load<Texture2D>("player_walk");

            var player_idleSheet = new LinearSpriteSheet(player_idleTexture, sections: 11, spriteSize: 180);
            var player_walkSheet = new LinearSpriteSheet(player_walkTexture, sections: 8, spriteSize: 180);

            AddAnimationFrames(AnimationType.Idle, player_idleSheet, frameDuration: 0.1f);
            AddAnimationFrames(AnimationType.Walk, player_walkSheet, frameDuration: 0.1f);
        }
    }
}