using System.Collections.Generic;
using System.Linq;
using ADO_Demo.DB.CRUDs;
using ADO_Demo.DB.Models;
using Xunit;

namespace ADO_Demo.DB.Test
{
    public class UserCrudTest
    {
        [Fact]
        public void GetAllUsers_Test()
        {
            var expectedUsers = new List<User>
            {
                new()
                {
                    Id = 1,
                    FirstName = "Anonim",
                    LastName = "Anonimus",
                    Emails = new List<string>()
                },
                new()
                {
                    Id = 2,
                    FirstName = "Anna",
                    LastName = "Karenina",
                    Emails = new List<string> { "anna@karenin.ru" }
                },
                new()
                {
                    Id = 3,
                    FirstName = "Admin",
                    LastName = "Adminus",
                    Emails = new List<string> { "admin@admin.ru", "ad@admin.ru" }
                },
            };

            var userCrud = new UserCrud();
            var actualUsers = userCrud.GetAllUsers().ToList();
            
            //Assert.Equal(expectedUsers, actualUsers);
            Assert.Equal(expectedUsers[0].Emails, actualUsers[0].Emails);
        }
    }
}
