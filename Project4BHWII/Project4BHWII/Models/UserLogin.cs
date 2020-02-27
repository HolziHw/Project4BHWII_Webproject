using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project4BHWII.Models
{
    public class UserLogin
    {
        public String Username { get; set; }
        public String Password { get; set; }

        public UserLogin() : this ( " "," ") { }

        public UserLogin(String Username, String Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
    }
}