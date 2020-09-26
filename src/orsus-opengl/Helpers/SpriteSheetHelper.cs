using Microsoft.Xna.Framework;

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
    }
}