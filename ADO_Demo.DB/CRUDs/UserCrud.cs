using System;
using System.Collections.Generic;
using ADO_Demo.DB.Models;

namespace ADO_Demo.DB.CRUDs
{
        public class UserCrud : DataBase
        {
            public UserCrud() : base() { }

            public List<User> GetUsers(string sqlQuery)
            {
                var users = new List<User>();

                _db.Open();

                _command.CommandText = sqlQuery;
                var result = _command.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        users.Add(new User
                        {

                            Id=result.GetInt32("id"),
                            FirstName= result.GetString("first_name"),
                            LastName= result.GetString("last_name"),
                            Role= result.GetString("role"),
                            Email= result.GetString("email")

                        });
                    }
                }

                _db.Close();

                return users;
            }
        }


    
}
