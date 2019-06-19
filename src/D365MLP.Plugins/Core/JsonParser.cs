using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace D3565MLP.plugins.Core
{
    public class JsonParser
    {
        public static T Deserialise<T>(string json)
        {
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                T result = (T)deserializer.ReadObject(stream);
                return result;
            }
        }

        public static string Serialize<T>(T poco)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                js.WriteObject(ms, poco);
                ms.Position = 0;
                using (StreamReader sr = new StreamReader(ms))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
