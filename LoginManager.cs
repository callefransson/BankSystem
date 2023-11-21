using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class LoginManager
    {
        public void Test()
        {
            List<Person> personList = new List<Person>();

            personList.Add(new Person("JohnDoe", "password123", "Admin", 1));
            personList.Add(new Person("JaneDoe", "pass456", "User", 2));

            Console.WriteLine("Enter username: ");
            string userinputUsername = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string userinputPassword = Console.ReadLine();

            Login(personList, userinputUsername, userinputPassword);

        }
        public bool Login(List<Person> personList, string username, string password)
        {
            foreach (Person user in personList)
            {
                if (user.Username == username && user.Password == password)
                {

                    Person Temp = new Person(user.Username, user.Password, user.UserRole, user.ID);  

                    if (user.UserRole == "Admin")
                    {
                        Console.WriteLine("This is an Admin");
                        //do xyz
                        Administrator a1 = new Administrator(user.Username, user.Password, "Admin", 1);
                        a1.RunMenu();
                    }
                    if (user.UserRole == "User")
                    {
                        Console.WriteLine("This is a User");
                        //do xyz
                        User u1 = new User(username, password, "User", 1);
                        u1.RunMenu();
                    }
                    return true;
                }
            }

            return false;
            
        }
    }
}
