using System.Numerics;
using Veldrid;
using Veldrid.SPIRV;
using orsus_engine.Structs;
using orsus_engine.Interfaces;
using orsus_engine.Services.Shaders;

namespace orsus_engine.Scenes
{
    public class ColorQuad : IOrsusScene
    {
        private static CommandList _commandList;
        private static DeviceBuffer _vertexBuffer;
        private static DeviceBuffer _indexBuffer;
        private static Shader[] _shaders;
        private static Pipeline _pipeline;
        private static readonly ShaderLoader _shaderLoader = new ShaderLoader();

        public ColorQuad() { }

        public void CreateResources(GraphicsDevice device)
        {
            var factory = device.ResourceFactory;
            var quadVertices = GenerateDemo();
            ushort[] quadIndices = { 0, 1, 2, 3 };

            _vertexBuffer = factory.CreateBuffer(new BufferDescription(4 * VertexPositionColor.SizeInBytes, BufferUsage.VertexBuffer));
            device.UpdateBuffer(_vertexBuffer, 0, quadVertices);

            _indexBuffer = factory.CreateBuffer(new BufferDescription(4 * sizeof(ushort), BufferUsage.IndexBuffer));
            device.UpdateBuffer(_indexBuffer, 0, quadIndices);

            CreateShaders(factory);
            CreatePipeline(device);
            CreateCommandList(factory);
        }

        public void Draw(GraphicsDevice device)
        {
            CreateCommands(device);
            device.SubmitCommands(_commandList);
            device.SwapBuffers();
        }

        public void DisposeResources()
        {
            _pipeline.Dispose();
            _vertexBuffer.Dispose();
            _indexBuffer.Dispose();
            _commandList.Dispose();

            foreach (var shader in _shaders)
            {
                shader.Dispose();
            }
        }

        private void CreateCommands(GraphicsDevice device)
        {
            _commandList.Begin();
            _commandList.SetFramebuffer(device.SwapchainFramebuffer);

            _commandList.ClearColorTarget(0, RgbaFloat.Black);

            _commandList.SetVertexBuffer(0, _vertexBuffer);
            _commandList.SetIndexBuffer(_indexBuffer, IndexFormat.UInt16);
            _commandList.SetPipeline(_pipeline);
            _commandList.DrawIndexed(indexCount: 4, instanceCount: 1, indexStart: 0, vertexOffset: 0, instanceStart: 0);
            _commandList.End();
        }

        private VertexPositionColor[] GenerateDemo()
        {
            VertexPositionColor[] quadVertices = {
                new VertexPositionColor(new Vector2(-1.0f, -1.0f), RgbaFloat.Red),
                new VertexPositionColor(new Vector2(1.0f, -1.0f), RgbaFloat.Green),
                new VertexPositionColor(new Vector2(-1.0f, 1.0f), RgbaFloat.Blue),
                new VertexPositionColor(new Vector2(1.0f, 1.0f), RgbaFloat.Yellow)
            };

            return quadVertices;
        }

        private void CreateShaders(ResourceFactory factory)
        {
            var vertexShaderPath = "Shaders/ColorQuad/VertexCode.glsl";
            var fragmentShaderPath = "Shaders/ColorQuad/FragmentCode.glsl";

            var vertexCode = _shaderLoader.GetShaderByteCodeFromFileAsync(vertexShaderPath).Result;
            var fragmentCode = _shaderLoader.GetShaderByteCodeFromFileAsync(fragmentShaderPath).Result;

            var vertexShaderDesc = new ShaderDescription(ShaderStages.Vertex, vertexCode, ShaderLoader.ShaderEntrypoint);
            var fragmentShaderDesc = new ShaderDescription(ShaderStages.Fragment, fragmentCode, ShaderLoader.ShaderEntrypoint);

            _shaders = factory.CreateFromSpirv(vertexShaderDesc, fragmentShaderDesc);
        }

        private void CreatePipeline(GraphicsDevice device)
        {
            var vertexLayout = new VertexLayoutDescription(new VertexElementDescription("Position", VertexElementSemantic.TextureCoordinate, VertexElementFormat.Float2), new VertexElementDescription("Color", VertexElementSemantic.TextureCoordinate, VertexElementFormat.Float4));

            var pipelineDesc = new GraphicsPipelineDescription
            {
                BlendState = BlendStateDescription.SingleOverrideBlend,
                DepthStencilState = new DepthStencilStateDescription(depthTestEnabled: true, depthWriteEnabled: true, comparisonKind: ComparisonKind.LessEqual),
                RasterizerState = new RasterizerStateDescription(cullMode: FaceCullMode.Back, fillMode: PolygonFillMode.Solid, frontFace: FrontFace.Clockwise, depthClipEnabled: true, scissorTestEnabled: false),
                PrimitiveTopology = PrimitiveTopology.TriangleStrip,
                ResourceLayouts = System.Array.Empty<ResourceLayout>(),
                ShaderSet = new ShaderSetDescription(vertexLayouts: new VertexLayoutDescription[] { vertexLayout }, shaders: _shaders),
                Outputs = device.SwapchainFramebuffer.OutputDescription
            };

            _pipeline = device.ResourceFactory.CreateGraphicsPipeline(pipelineDesc);
        }

        private void CreateCommandList(ResourceFactory factory)
        {
            _commandList = factory.CreateCommandList();
        }
    }
}