using System;
using System.Collections.Generic;
using ADO_Demo.DB.CRUDs;
using ADO_Demo.DB.Models;
using Xunit;

namespace ADO_Demo.DB.Test
{
    public class RoleCrudTest
    {
        [Fact]
        public void GetAllRoles_Test()
        {
            var expectedRoles = new List<Role>
            {
                new()
                {
                    Id = 1,
                    RoleName = "guest"
                },
                new()
                {
                    Id = 2,
                    RoleName = "user"
                },
                new()
                {
                    Id = 3,
                    RoleName = "admin"
                },
            };

            var roleCrud = new RoleCrud();
            var actualRoles = roleCrud.GetAllRoles();
            
            Assert.Equal(expectedRoles, actualRoles);
        }
    }
}
