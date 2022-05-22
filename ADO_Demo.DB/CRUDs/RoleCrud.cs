using System.Collections.Generic;
using ADO_Demo.DB.Models;

namespace ADO_Demo.DB.CRUDs
{
    public class RoleCrud : DataBase
    {
        public RoleCrud() : base() {}

        public List<Role> GetAllRoles()
        {
            var roles = new List<Role>();
            
            _db.Open();
            
            _command.CommandText = "SELECT id, role FROM tab_roles;";
            var result = _command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    roles.Add(new Role
                    {
                        Id = result.GetInt32("id"),
                        RoleName = result.GetString("role")
                    });
                }
            }
            
            _db.Close();

            return roles;
        }
    }
}
