using Microsoft.Xna.Framework;
using orsus_opengl.Bases;

namespace orsus_opengl.Entities
{
    public class PlayerEntity : EntityBase
    {
        public PlayerEntity()
        {
            Speed = 1f;
            Scale = new Vector2(5);
        }
    }
}