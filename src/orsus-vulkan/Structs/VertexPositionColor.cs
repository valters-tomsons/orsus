using System.Numerics;
using Veldrid;

namespace orsus_engine.Structs
{
    public struct VertexPositionColor
    {
        public Vector2 Position;
        public RgbaFloat Color;

        public VertexPositionColor(Vector2 position, RgbaFloat color)
        {
            Position = position;
            Color = color;
        }
        
        // Float size = 32 bytes = 4 bits
        // Vec2 (4 + 4) + RgbaF (4 * 4)
        public const uint SizeInBytes = 24;
    }
}