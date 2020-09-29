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
            var player_idle = content.Load<Texture2D>("player_idle");
            var player_walk = content.Load<Texture2D>("player_walk");
            var player_attack = content.Load<Texture2D>("player_attack2");

            var player_idleSheet = new LinearSpriteSheet(player_idle, sections: 11, spriteSize: 180);
            var player_walkSheet = new LinearSpriteSheet(player_walk, sections: 8, spriteSize: 180);
            var player_atkSheet = new LinearSpriteSheet(player_attack, sections: 7, spriteSize: 180);

            AddAnimationFrames(AnimationType.Idle, player_idleSheet, frameDuration: 0.1f);
            AddAnimationFrames(AnimationType.Walk, player_walkSheet, frameDuration: 0.1f);
            AddAnimationFrames(AnimationType.Attack1, player_atkSheet, frameDuration: 0.1f, loop: false);
        }
    }
}