using System.Text.Json;

namespace ADO_Demo.DB.Config
{
    public class ConfigDb
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Uid { get; set; }
        public string Pwd { get; set; }

        public static ConfigDb ImportFromJson(string json)
        {
            return JsonSerializer.Deserialize<ConfigDb>(json);
        }

        public override string ToString()
        {
            return $"Server={Server};Database={Database};Uid={Uid};Pwd={Pwd};";
        }
    }
}
