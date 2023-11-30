using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaTestJz.Domain.Entities
{
    public class User
    {
        public User()
        {
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
//        public string Message { get; set; } = null!;
    }
}
