using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace orsus_opengl.Interfaces
{
    public interface ISpriteSheet
    {
        Texture2D SheetTexture { get; }
        Rectangle[] SpriteSections { get; }
    }
}