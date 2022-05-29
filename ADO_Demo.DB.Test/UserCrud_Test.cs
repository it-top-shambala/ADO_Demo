using System.Collections.Generic;
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
                    LastName = "Anonimus"
                },
                new()
                {
                    Id = 2,
                    FirstName = "Anna",
                    LastName = "Karenina"
                },
                new()
                {
                    Id = 3,
                    FirstName = "Admin",
                    LastName = "Adminus"
                },
            };

            var userCrud = new UserCrud();
            var actualUsers = userCrud.GetAllUsers();
            
            Assert.Equal(expectedUsers, actualUsers);
        }
    }
}
