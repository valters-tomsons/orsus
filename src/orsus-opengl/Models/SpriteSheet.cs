using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using orsus_opengl.Helpers;

namespace orsus_opengl.Models
{
    public class SpriteSheet
    {
        public Texture2D SheetTexture { get; }
        public Rectangle[] SpriteSections { get; }

        public SpriteSheet(Texture2D texture, int sections, int spriteSize)
        {
            SheetTexture = texture;
            SpriteSections = SpriteSheetHelper.DivideSpritesInSheet(spriteSize, spriteSize, sections);
        }
    }
}