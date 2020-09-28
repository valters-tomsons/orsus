using Microsoft.Xna.Framework;

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