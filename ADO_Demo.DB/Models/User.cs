using System.Collections.Generic;

namespace ADO_Demo.DB.Models
{
    public record User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public IEnumerable<string> Emails { get; set; }
    }
}
