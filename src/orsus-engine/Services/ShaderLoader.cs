using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace orsus_engine.Services
{
    public class ShaderLoader
    {
        public static readonly string ShaderEntrypoint = "main";

        public async Task<byte[]> GetShaderByteCodeFromFileAsync(string filePath)
        {
            var shaderCode = await File.ReadAllTextAsync(filePath);
            var byteCode = GetShaderByteCodeFromString(shaderCode);
            return byteCode;
        }

        public byte[] GetShaderByteCodeFromString(string shaderCode)
        {
            var byteCode = Encoding.UTF8.GetBytes(shaderCode);
            return byteCode;
        }
    }
}