using MySql.Data.MySqlClient;

namespace ADO_Demo.DB
{
    public abstract class DataBase
    {
        private const string Str = "Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;";
        protected readonly MySqlConnection _db;
        protected MySqlCommand _command;

        protected DataBase()
        {
            _db = new MySqlConnection(Str);
            _command = new MySqlCommand { Connection = _db };
        }
    }
}
