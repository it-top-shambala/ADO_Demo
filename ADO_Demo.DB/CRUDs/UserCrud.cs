using System.Collections.Generic;
using Dapper;

namespace ADO_Demo.DB.CRUDs
{
    public class UserCrud : DataBase
    {
        class User
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        class UserEmails
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public string Email { get; set; }
        }
        
        public UserCrud() : base()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        private IEnumerable<User> getAllUsers()
        {
            _db.Open();
            var sql = "SELECT * FROM host1323541_itstep1.tab_users";
            var result = _db.Query<User>(sql);
            _db.Close();
            return result;
        }

        private IEnumerable<UserEmails> getAllEmails()
        {
            _db.Open();
            var sql = "SELECT * FROM host1323541_itstep1.tab_user_emails";
            var result = _db.Query<UserEmails>(sql);
            _db.Close();
            return result;
        }

        public IEnumerable<Models.User> GetAllUsers()
        {
            var users = getAllUsers();
            var emails = getAllEmails();

            var result = new List<Models.User>();
            foreach (var user in users)
            {
                var resultEmails = new List<string>();
                foreach (var email in emails)
                {
                    if (email.UserId == user.Id)
                    {
                        resultEmails.Add(email.Email);
                    }
                }
                
                result.Add( new Models.User
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Emails = resultEmails
                });
            }

            return result;
        }
    }
}
