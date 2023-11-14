using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class Person
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public int PersonalNumber { get; set; }
        public int ID { get; set; }

        public Person(string username, string password)
        {
            Username = username;
            Password = password;
            //UserRole = userRole;
        }

        public virtual void RunMenu() { }
    }
}
