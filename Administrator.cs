using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankSystem
{
    internal class Administrator : Person
    {
        public int EmployeeId { get; set; }
        public int Id { get; set; }

        private int IdCounter = 0;

        public Administrator(string username, string password) : base(username, password)
        {
        }

        public void AddUser(List<Person> accounts)
        {
            Console.Clear();

            bool isCorrect = true;
            string adminInput;
            string userName;
            string password;
            Console.WriteLine("Add a user to the bank");
            do
            {
                Console.WriteLine("Create a username for the user");
                userName = Console.ReadLine();
                Console.WriteLine("Create a password for the user");
                password = Console.ReadLine();

                Console.WriteLine("Are you sure you would like to create this user?\n1 = Yes, create user\n2 = No, cancel");

                adminInput = Console.ReadLine();

                switch (adminInput)
                {
                    case "1":
                        Console.WriteLine("You have now created a user!");
                        break;
                    case "2":
                        Console.WriteLine("Please re-enter username and password.");
                        continue;
                    default:                        
                        Console.WriteLine("Invalid input. Please select 1 or 2.");
                        break;
                }

            } while (adminInput != "1" || adminInput != "2");

            if (isCorrect && !string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
            {
                Person account = new Person(userName,password)
                {
                    Username = userName,
                    Password = password,
                    ID = IdCounter++,
                };
                accounts.Add(account);
                Console.WriteLine("You have now created a new user");
            }
            else
            {
                Console.WriteLine("User creation canceled.");
            }

            Console.WriteLine("Press any key to return to the menu");
            Console.ReadKey();
        }
        public void RemoveUser(List<Person> accounts)
        {
            int adminPick;

            Console.WriteLine("Enter the id of witch user you would like to remove from the bank");
            ShowAllUsers(accounts);
            //foreach(Person allAccounts in accounts)
            //{
            //    if(allAccounts == null)
            //    {
            //        Console.WriteLine("There are no accounts yet");
            //        continue;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Id: {0} Username: {1} ", allAccounts.ID,allAccounts.Username);
            //    }
            //}
                while (true)
                {
                    string? pick = Console.ReadLine();

                    if (int.TryParse(pick, out adminPick))
                    {
                        break;
                    }
                    else if(adminPick >= 0 && adminPick < accounts.Count)
                    {
                        Console.WriteLine("Please pick the right number in the list");
                    }
                    else
                    {
                        Console.WriteLine("Please type in a number");
                    }
                }
        }
        public void ShowAllUsers(List<Person> accounts)
        {
            Console.WriteLine("Show all users");
            foreach (Person allAccounts in accounts)
            {
                if (allAccounts == null)
                {
                    Console.WriteLine("There are no accounts yet");
                    continue;
                }
                else
                {
                    Console.WriteLine("Id: {0} Username: {1} ", allAccounts.ID, allAccounts.Username);
                }
            }
        }
        public void UpdateExchangeRate()
        {

        }
        public override void PrintMenu()
        {
            Console.WriteLine(@"
 █████╗ ██████╗ ███╗   ███╗██╗███╗   ██╗    ███╗   ███╗███████╗███╗   ██╗██╗   ██╗
██╔══██╗██╔══██╗████╗ ████║██║████╗  ██║    ████╗ ████║██╔════╝████╗  ██║██║   ██║
███████║██║  ██║██╔████╔██║██║██╔██╗ ██║    ██╔████╔██║█████╗  ██╔██╗ ██║██║   ██║
██╔══██║██║  ██║██║╚██╔╝██║██║██║╚██╗██║    ██║╚██╔╝██║██╔══╝  ██║╚██╗██║██║   ██║
██║  ██║██████╔╝██║ ╚═╝ ██║██║██║ ╚████║    ██║ ╚═╝ ██║███████╗██║ ╚████║╚██████╔╝
╚═╝  ╚═╝╚═════╝ ╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝    ╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝ ");
        }
    }
}
