using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class User
    {
        public enum UserRole
        {
            Administrator,
            Chef,
            Waiter
        }
        public string Username { get; }
        public string Password { get; }
        public UserRole Role { get; }
        public bool isFired { get; set; }

        public List<DateTime> shifts { get; set; }

        public User(string username, string password, UserRole role)
        {
            Username = username;
            Password = password;
            Role = role;
            isFired = false;
        }
    }
}
