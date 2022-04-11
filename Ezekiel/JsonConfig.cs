using Json.Net;
using System.Collections.Generic;
using System.IO;

namespace Ezekiel
{
    public class JsonConfig
    {

        private static string configFileName = "D:\\Ezekiel\\Ezekiel\\bin\\Debug\\netcoreapp3.1\\config.json";

        public static void WriteConfigFile(Dictionary<string, string> obj)
        {
            string config = JsonNet.Serialize(obj);

            File.WriteAllText(configFileName, config);
        }

        public static Dictionary<string, string> ReadConfigFile()
        {
            string config = File.ReadAllText(configFileName);

            return JsonNet.Deserialize<Dictionary<string, string>>(config);
        }
    }
}
