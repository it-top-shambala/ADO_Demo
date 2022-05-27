using System;
using System.Collections.Generic;
using ADO_Demo.DB.Models;

namespace ADO_Demo.DB.CRUDs
{
    public class AccountCrud:DataBase
    {

            public AccountCrud() : base() { }

            public List<Account> GetAllAccounts()
            {
                var accounts = new List<Account>();

                _db.Open();

                _command.CommandText = "SELECT id, login, password, role_id FROM tab_accounts;";
                var result = _command.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                    accounts.Add(new Account
                        {
                            Id = result.GetInt32("id"),
                            Login = result.GetString("login"),
                            Password = result.GetString("password"),
                            Role_Id = result.GetInt32("role_id")
                        });
                    }
                }

                _db.Close();

                return accounts;
            }
        
    }
}
