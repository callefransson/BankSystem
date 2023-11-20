using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class starta
    {
        public void Test()
        {
            Console.WriteLine("Hello, World!");
            List<Person> personList = new List<Person>();

            personList.Add(new Person("JohnDoe", "password123", "Admin", 1));
            personList.Add(new Person("JaneDoe", "pass456", "User", 2));
            personList.Add(new Person("BobSmith", "bobpass", "Manager", 3));

            Console.WriteLine("Enter username: ");
            string userinputUsername = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string userinputPassword = Console.ReadLine();      

        }
        public bool Login(List<Person> personList, string username, string password)
        {
            foreach (Person user in personList)
            {
                if (user.Username == username && user.Password == password)
                {

                    Person Temp = new Person(user.Username, user.Password, user.UserRole,user.ID);
                    //Lagrar temporär inloggnings info
                    
                    Console.WriteLine("Success!");
                    if (user.UserRole == "Manager")
                    {
                        Console.WriteLine("This is a Manager");

                        //do xyz
                    }
                    if (user.UserRole == "Admin")
                    {
                        Console.WriteLine("This is a Admin");
                        //do xyz
                    }
                    if (user.UserRole == "User")
                    {
                        Console.WriteLine("This is a User");
                        //do xyz
                    }
                    return true;
                }
            }

            return false;
            
        }
    }
}
