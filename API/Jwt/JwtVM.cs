using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Jwt
{
    public class JwtVM
    {
        public JwtVM()
        {
        }

        public string Email { get; set; }
        public string Role { get; set; }

        public JwtVM(string email, string role)
        {
            Email = email;
            Role = role;
        }
    }
}
