using System.Numerics;
using orsus_engine.Interfaces;
using orsus_engine.Structs;

namespace orsus_engine.Objects
{
    public class CubeMesh : IMeshObject
    {
        private ushort[] _indices { get; set; }
        private Vertex[] _vertices { get; set; }

        public CubeMesh()
        {
            GenerateIndices();
            GenerateVertices();
        }

        public ushort[] GetIndices()
        {
            return _indices;
        }

        public Vertex[] GetVertices()
        {
            return _vertices;
        }

        private void GenerateIndices()
        {
            _indices = new ushort[]
            {
                0,
                1,
                2,
                0,
                2,
                3,
                4,
                5,
                6,
                4,
                6,
                7,
                8,
                9,
                10,
                8,
                10,
                11,
                12,
                13,
                14,
                12,
                14,
                15,
                16,
                17,
                18,
                16,
                18,
                19,
                20,
                21,
                22,
                20,
                22,
                23,
            };
        }

        private void GenerateVertices()
        {
            _vertices = new Vertex[]
            {
                // Top
                new Vertex(new Vector3(-0.5f, -0.5f, -0.5f), new Vector2(0, 0)),
                new Vertex(new Vector3(+0.5f, -0.5f, -0.5f), new Vector2(1, 0)),
                new Vertex(new Vector3(+0.5f, -0.5f, +0.5f), new Vector2(1, 1)),
                new Vertex(new Vector3(-0.5f, -0.5f, +0.5f), new Vector2(0, 1)),

                // Bottom                                                             
                new Vertex(new Vector3(-0.5f, +0.5f, +0.5f), new Vector2(0, 0)),
                new Vertex(new Vector3(+0.5f, +0.5f, +0.5f), new Vector2(1, 0)),
                new Vertex(new Vector3(+0.5f, +0.5f, -0.5f), new Vector2(1, 1)),
                new Vertex(new Vector3(-0.5f, +0.5f, -0.5f), new Vector2(0, 1)),

                // Left                                                               
                new Vertex(new Vector3(-0.5f, -0.5f, -0.5f), new Vector2(0, 0)),
                new Vertex(new Vector3(-0.5f, -0.5f, +0.5f), new Vector2(1, 0)),
                new Vertex(new Vector3(-0.5f, +0.5f, +0.5f), new Vector2(1, 1)),
                new Vertex(new Vector3(-0.5f, +0.5f, -0.5f), new Vector2(0, 1)),

                // Right                                                              
                new Vertex(new Vector3(+0.5f, -0.5f, +0.5f), new Vector2(0, 0)),
                new Vertex(new Vector3(+0.5f, -0.5f, -0.5f), new Vector2(1, 0)),
                new Vertex(new Vector3(+0.5f, +0.5f, -0.5f), new Vector2(1, 1)),
                new Vertex(new Vector3(+0.5f, +0.5f, +0.5f), new Vector2(0, 1)),

                // Back                                                               
                new Vertex(new Vector3(+0.5f, -0.5f, -0.5f), new Vector2(0, 0)),
                new Vertex(new Vector3(-0.5f, -0.5f, -0.5f), new Vector2(1, 0)),
                new Vertex(new Vector3(-0.5f, +0.5f, -0.5f), new Vector2(1, 1)),
                new Vertex(new Vector3(+0.5f, +0.5f, -0.5f), new Vector2(0, 1)),

                // Front                                                              
                new Vertex(new Vector3(-0.5f, -0.5f, +0.5f), new Vector2(0, 0)),
                new Vertex(new Vector3(+0.5f, -0.5f, +0.5f), new Vector2(1, 0)),
                new Vertex(new Vector3(+0.5f, +0.5f, +0.5f), new Vector2(1, 1)),
                new Vertex(new Vector3(-0.5f, +0.5f, +0.5f), new Vector2(0, 1)),
            };
        }
    }
}