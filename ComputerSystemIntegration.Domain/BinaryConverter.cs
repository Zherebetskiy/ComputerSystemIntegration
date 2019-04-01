using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ComputerSystemIntegration.Domain
{
    public class BinaryConverter
    {
        public static byte[] ObjectToByteArray(object obj)
        {
            var formatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                formatter.Serialize(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }

        public static object ByteArrayToObject(byte[] array)
        {
            using (var memoryStream = new MemoryStream(array))
            {
                var formatter = new BinaryFormatter();
                var obj = formatter.Deserialize(memoryStream);
                return obj;
            }
        }
    }
}
