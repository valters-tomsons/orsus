using orsus_engine.Structs;

namespace orsus_engine.Interfaces
{
    public interface IMeshObject
    {
        ushort[] GetIndices();
        Vertex[] GetVertices();
    }
}