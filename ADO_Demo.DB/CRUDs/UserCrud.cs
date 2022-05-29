using System.Collections.Generic;
using ADO_Demo.DB.Models;
using Dapper;

namespace ADO_Demo.DB.CRUDs
{
    public class UserCrud : DataBase
    {
        public UserCrud() : base()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public IEnumerable<User> GetAllUsers()
        {
            _db.Open();
            var sql = "SELECT * FROM tab_users";
            var result = _db.Query<User>(sql);
            _db.Close();
            return result;
        }
    }
}
