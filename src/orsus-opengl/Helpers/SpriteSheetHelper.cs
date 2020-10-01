using Microsoft.Xna.Framework;
using MonoGame.Extended.TextureAtlases;
using orsus_opengl.Interfaces;

namespace orsus_opengl.Helpers
{
    public static class SpriteSheetHelper
    {
        public static Rectangle[] DivideSpritesInSheet(int spriteWidth, int spriteHeight, int spriteCount)
        {
            var sprites = new Rectangle[spriteCount];

            for(var i = 0; i < spriteCount; i++)
            {
                var x = spriteWidth * i;
                sprites[i] = new Rectangle(x, 0, spriteWidth, spriteHeight);
            }

            return sprites;
        }

        public static TextureRegion2D[] SpriteSheetToTextureRegions(ISpriteSheet spriteSheet)
        {
            var regions = new TextureRegion2D[spriteSheet.SpriteSections.Length];

            for(var i = 0; i < regions.Length; i++)
            {
                regions[i] = new TextureRegion2D(spriteSheet.SheetTexture, spriteSheet.SpriteSections[i]);
            }

            return regions;
        }
    }
}