using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svendeMobil.Models
{
    public class LoginModel
    {
        public LoginModel(string email, string password)
        {
            Useremail = email;
            Password = password;
        }

        public string Useremail { get; set; }
        public string Password { get; set; }
    }
}
