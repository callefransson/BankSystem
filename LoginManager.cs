using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class LoginManager
    {
        private List<Person> _users;
        public LoginManager()
        {
            _users = new List<Person>
            {
                new Person("admin", "123"),
                new Person("bankowner", "123"),
                new Person("user", "123")
            };
        }

        public bool Login(string username, string password)
        {
            foreach (Person user in _users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
