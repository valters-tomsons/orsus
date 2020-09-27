using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using orsus_opengl.Helpers;
using orsus_opengl.Interfaces;

namespace orsus_opengl.Models
{
    public class LinearSpriteSheet : ISpriteSheet
    {
        public Texture2D SheetTexture { get; }
        public Rectangle[] SpriteSections { get; }

        public LinearSpriteSheet(Texture2D texture, int sections, int spriteSize)
        {
            SheetTexture = texture;
            SpriteSections = SpriteSheetHelper.DivideSpritesInSheet(spriteSize, spriteSize, sections);
        }
    }
}