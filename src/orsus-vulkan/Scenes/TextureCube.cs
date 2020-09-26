using orsus_engine.Interfaces;
using orsus_engine.Objects;
using orsus_engine.Structs;
using Veldrid;

namespace orsus_engine.Scenes
{
    public class TextureCube : IOrsusScene
    {
        private IMeshObject _cube;
        private DeviceBuffer _projectionBuffer;
        private DeviceBuffer _viewBuffer;
        private DeviceBuffer _worldBuffer;
        private DeviceBuffer _vertexBuffer;
        private DeviceBuffer _indexBuffer;
        private CommandList _commandList;
        private Pipeline _pipeline;
        private float _ticks;

        public TextureCube()
        {
            _cube = new CubeMesh();
        }

        public void CreateResources(GraphicsDevice device)
        {
            CreateDeviceBuffers(device);
        }

        public void DisposeResources()
        {
            throw new System.NotImplementedException();
        }

        public void Draw(GraphicsDevice device)
        {
            throw new System.NotImplementedException();
        }

        private void CreateDeviceBuffers(GraphicsDevice device)
        {
            var factory = device.ResourceFactory;
            var uniformBufferDesc = new BufferDescription(64, BufferUsage.UniformBuffer);
            var vertices = _cube.GetVertices();
            var indices = _cube.GetIndices();

            _projectionBuffer = factory.CreateBuffer(uniformBufferDesc);
            _viewBuffer = factory.CreateBuffer(uniformBufferDesc);
            _worldBuffer = factory.CreateBuffer(uniformBufferDesc);

            _vertexBuffer = factory.CreateBuffer(new BufferDescription(Vertex.SizeInBytes * (uint)vertices.Length, BufferUsage.VertexBuffer));
            _indexBuffer = factory.CreateBuffer(new BufferDescription(sizeof(ushort) * (uint) indices.Length, BufferUsage.IndexBuffer));

            device.UpdateBuffer(_vertexBuffer, 0, vertices);
            device.UpdateBuffer(_indexBuffer, 0, indices);
        }
    }
}