using System.Numerics;

namespace orsus_engine.Structs
{
    public struct Vertex
    {
        public Vector3 Position;
        public Vector2 TexPosition;

        // Float = 4 bits
        // Vec3 (4 * 3) + Vec2 (4 * 2)
        public static uint SizeInBytes = 20;

        public Vertex(Vector3 position, Vector2 texPosition)
        {
            Position = position;
            TexPosition = texPosition;
        }
    }
}