using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using orsus_opengl.Interfaces;

namespace orsus_opengl.Models
{
    public class SingleSpriteSheet : ISpriteSheet
    {
        public Texture2D SheetTexture { get; }
        public Rectangle[] SpriteSections { get; }

        public SingleSpriteSheet(Texture2D texture)
        {
            SheetTexture = texture;

            SpriteSections = new Rectangle[] {
                new Rectangle(0, 0, texture.Width, texture.Height)
            };
        }
    }
}