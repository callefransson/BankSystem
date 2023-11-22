using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    
    
    class LoginManager
    {
        
        
        public void firstStart() 
        {
            List<Person> personList = new List<Person>();
            personList.Add(new Person("JohnDoe", "password123", "Admin", 1));
            personList.Add(new Person("JaneDoe", "pass456", "User", 2));
            Test(personList);

        }

        public int loginAttempts = 3;
        public void PrintMenu()
        {
            Console.WriteLine(@"
▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
██ ████▀▄▄▀█ ▄▄▄██▄██ ▄▄▀████ ▄▀▄ █ ▄▄█ ▄▄▀█ ██ 
██ ████ ██ █ █▄▀██ ▄█ ██ ████ █ █ █ ▄▄█ ██ █ ██ 
██ ▀▀ ██▄▄██▄▄▄▄█▄▄▄█▄██▄████ ███ █▄▄▄█▄██▄██▄▄▄
▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
        }

        public void lockout()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have too many attempts wait for 5 minutes");
            Console.ResetColor();
            Thread.Sleep(300000);
            loginAttempts = 3;
        }

        public void Test(List<Person> personList)
        {
            
            

            Console.ForegroundColor = ConsoleColor.DarkRed;
            PrintMenu();
            if (loginAttempts == 0)
            {
                lockout();
                
            }
            if (loginAttempts <= 2)
            {
                Console.WriteLine("You entered the wrong credentials you have: " + loginAttempts + " Attepts left");
            }
            Console.ResetColor();
            Console.Write("Enter username: ");
            string userinputUsername = Console.ReadLine();
            Console.Write("Enter password: ");
            string userinputPassword = Console.ReadLine();
            loginAttempts--;


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
                else if(user.Username == username && user.Password != password)
                {
                    
                    Console.WriteLine("You entered the wrong password you have: "+ loginAttempts+" Attepts left");
                    Thread.Sleep(4000);
                    Console.Clear();
                    Test(personList);
                }
                else if (user.Username != username && user.Password == password)
                {
                    Console.WriteLine("You entered the wrong password you have: "+ loginAttempts+ " Attepts left");
                    Thread.Sleep(4000);
                    Console.Clear();
                    Test(personList);
                }
                
                

            }
            Console.Clear();
            Test(personList);
            return false;
            
        }
    }
}
