using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Animations;
using MonoGame.Extended.Animations.SpriteSheets;
using MonoGame.Extended.TextureAtlases;
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

            // AddAnimationFrames(AnimationType.Idle, player_idleSheet, frameDuration: 0.1f);
            // AddAnimationFrames(AnimationType.Walk, player_walkSheet, frameDuration: 0.1f);
            // AddAnimationFrames(AnimationType.Attack1, player_atkSheet, frameDuration: 0.1f, loop: false);

            var regions = new TextureRegion2D[3][];

            regions[0] = Helpers.SpriteSheetHelper.SpriteSheetToTextureRegions(player_idleSheet);
            regions[1] = Helpers.SpriteSheetHelper.SpriteSheetToTextureRegions(player_walkSheet);
            regions[2] = Helpers.SpriteSheetHelper.SpriteSheetToTextureRegions(player_atkSheet);

            var reg = regions.SelectMany(x => x);

            var fac = new SpriteSheetAnimationFactory(reg);

            var idle = Enumerable.Range(0, 11).ToArray();
            var walk = Enumerable.Range(11, 8).ToArray();
            var attack = Enumerable.Range(19, 7).ToArray();

            // var walk2 = new int[] { 11, 12, 13, 14, 15, 16, 17, 18 };

            fac.Add("player_idle", new SpriteSheetAnimationData(idle, 0.1f, true, false, false));
            fac.Add("player_walk", new SpriteSheetAnimationData(walk, 0.1f, true, false, false));
            fac.Add("player_attack", new SpriteSheetAnimationData(attack, 0.1f, false));

            sprite = new AnimatedSprite(fac);
        }
    }
}