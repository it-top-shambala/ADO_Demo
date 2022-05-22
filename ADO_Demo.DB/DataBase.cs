using MySql.Data.MySqlClient;

namespace ADO_Demo.DB
{
    public class DataBase
    {
        private MySqlConnection _db;
        private const string Str = "Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;";

        public DataBase()
        {
            _db = new MySqlConnection(Str);
        }
        
        
    }
}
