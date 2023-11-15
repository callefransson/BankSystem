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

        public Person(string username, string password, string userRole, int id)
        {
            Username = username;
            Password = password;
            UserRole = userRole;
            ID = id;

        }

        public virtual void RunMenu() { }


        void test()
        {
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

                Login(userinputUsername, userinputPassword);

                bool Login(string username, string password)
                {
                    foreach (Person user in personList)
                    {
                        if (user.Username == username && user.Password == password)
                        {
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
                    ////////////////////////////////////////////
                    //INTE KLAR ÄN//////////////////////////////
                    ////////////////////////////////////////////
                }
            }
        }
    }
}
