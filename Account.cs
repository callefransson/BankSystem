using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public int PersonalNumber { get; set; }
        public int ID { get; set; }

        public Account(string username, string password, string userRole, int id)
        {
            Username = username;
            Password = password;
            UserRole = userRole;
            ID = id;
            //
        }

    }
}
