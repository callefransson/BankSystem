using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    
    
    class LoginManager
    {
        private int _loginAttempts = 0;
        private int _maxLoginAttempts = 3; // Total attempts

        private List<Person> accounts = new List<Person>();
        public List<Person> Accounts => accounts;

        public LoginManager()
        {
            accounts.Add(new Person("Admin", "123", "Admin",1));
            accounts.Add(new Person("User", "123", "User", 1));
        }

        public void AddUserToAccounts(Person user)
        {
            accounts.Add(user);
        }

        public void Login(string username, string password)
        {
            Person foundUser = accounts.Find(user => user.Username == username && user.Password == password);

            if (foundUser != null)
            {
                _loginAttempts = 0; // Reset loggin attempts 
                if (foundUser.UserRole == "Admin")
                {
                    Administrator admin = new Administrator(this, username, password, foundUser.UserRole, foundUser.ID);
                    admin.RunMenu();
                }
                else if (foundUser.UserRole == "User")
                {
                    User regularUser = new User(username, password, foundUser.UserRole, foundUser.ID);
                    regularUser.RunMenu();
                }
            }
            else
            {
                _loginAttempts++;
                if (_loginAttempts >= _maxLoginAttempts) // If attempts reaches max attempts
                {
                    lockout();
                }
                else
                {
                    Console.WriteLine("You entered the wrong credentials. You have: {0} attempts left", _maxLoginAttempts - _loginAttempts);
                    RequestLogin();
                }
            }
        }
        public void RequestLogin()
        {
            Console.Write("Enter username: ");
            string usernameInput = Console.ReadLine();
            Console.Write("Enter password: ");
            string passwordInput = Console.ReadLine();
            Login(usernameInput, passwordInput);
        }

        public void lockout()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have too many attempts wait for 5 minutes");
            Console.ResetColor();
            Thread.Sleep(300000);
            _loginAttempts = 3;
        }

        //public void Test(List<Person> personList)
        //{



        //    Console.ForegroundColor = ConsoleColor.DarkRed;
        //    PrintMenu();
        //    if (loginAttempts == 0)
        //    {
        //        lockout();

        //    }
        //    if (loginAttempts <= 2)
        //    {
        //        Console.WriteLine("You entered the wrong credentials. You have: " + loginAttempts + " attempts left");
        //    }
        //    Console.ResetColor();
        //    Console.Write("Enter username: ");
        //    string userinputUsername = Console.ReadLine();
        //    Console.Write("Enter password: ");
        //    string userinputPassword = Console.ReadLine();
        //    loginAttempts--;


        //    Login(personList, userinputUsername, userinputPassword);

        //}

        //public bool Login(List<Person> personList, string username, string password)
        //{
        //    foreach (Person user in personList)

        //    {
        //        if (user.Username == username && user.Password == password)
        //        {

        //            Person Temp = new Person(user.Username, user.Password, user.UserRole, user.ID);  

        //            if (user.UserRole == "Admin")
        //            {
        //                Console.WriteLine("This is an Admin");
        //                //do xyz
        //                Administrator a1 = new Administrator(user.Username, user.Password, "Admin", 1);
        //                a1.RunMenu();
        //            }
        //            if (user.UserRole == "User")
        //            {
        //                Console.WriteLine("This is a User");
        //                //do xyz
        //                User u1 = new User(username, password, "User", 1);
        //                u1.RunMenu();
        //            }
        //            return true;
        //        }
        //        else if(user.Username == username && user.Password != password)
        //        {

        //            Console.WriteLine("You entered the wrong password. You have: "+ loginAttempts+" attempts left");
        //            Thread.Sleep(4000);
        //            Console.Clear();
        //            Test(personList);
        //        }
        //        else if (user.Username != username && user.Password == password)
        //        {
        //            Console.WriteLine("You entered the wrong password. You have: "+ loginAttempts+ " attempts left");
        //            Thread.Sleep(4000);
        //            Console.Clear();
        //            Test(personList);
        //        }



        //    }
        //    Console.Clear();
        //    Test(personList);
        //    return false;

        //}
        public void PrintMenu()
        {
            Console.WriteLine(@"
▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
██░████▀▄▄▀█░▄▄▄██▄██░▄▄▀████░▄▀▄░█░▄▄█░▄▄▀█░██░██
██░████░██░█░█▄▀██░▄█░██░████░█░█░█░▄▄█░██░█░██░██
██░▀▀░██▄▄██▄▄▄▄█▄▄▄█▄██▄████░███░█▄▄▄█▄██▄██▄▄▄██
▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
");
        }
    }
}
