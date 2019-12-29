using System.Numerics;
using Veldrid;

namespace orsus_game
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
        
        public const uint SizeInBytes = 24;
    }
}