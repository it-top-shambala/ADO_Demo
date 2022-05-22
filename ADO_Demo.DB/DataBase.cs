using System.Data;
using System.IO;
using ADO_Demo.DB.Config;
using MySql.Data.MySqlClient;

namespace ADO_Demo.DB
{
    public abstract class DataBase
    {
        protected readonly MySqlConnection _db;
        protected MySqlCommand _command;

        protected DataBase()
        {
            using var file = new StreamReader("config_db.json");
            var config = ConfigDb.ImportFromJson(file.ReadToEnd());
            
            _db = new MySqlConnection(config.ToString());
            _command = new MySqlCommand { Connection = _db };
        }
    }
}
