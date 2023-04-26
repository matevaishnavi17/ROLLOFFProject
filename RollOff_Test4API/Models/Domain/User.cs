using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff_Test4API.Models.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
