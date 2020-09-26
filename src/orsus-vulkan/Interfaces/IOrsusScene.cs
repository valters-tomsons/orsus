using Veldrid;

namespace orsus_engine.Interfaces
{
    public interface IOrsusScene
    {
        void CreateResources(GraphicsDevice device);
        void Draw(GraphicsDevice device);
        void DisposeResources();
    }
}