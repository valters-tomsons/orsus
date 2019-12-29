using Veldrid;

namespace orsus_engine.Interfaces
{
    interface IOrsusScene
    {
        void CreateResources(GraphicsDevice device);
        void Draw(GraphicsDevice device);
        void DisposeResources();
    }
}