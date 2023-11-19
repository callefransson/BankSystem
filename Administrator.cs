using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankSystem
{
    internal class Administrator : Person, IPrintMenu
    {
        private int IdCounter = 0;

        public Administrator(string username, string password, string userRole, int id) : base(username, password, userRole, id)
        {
        }
        List<Person> accounts = new List<Person>();
        public void AddUser()
        {
            Console.Clear();

            string adminInput;
            string username;
            string password;
            int id = IdCounter++;
            Console.WriteLine("Add a user to the bank");
            do
            {
                Console.WriteLine("Create a username for the user");
                username = Console.ReadLine();
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

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                Person account = new Person(username, password, "User", IdCounter)
                {
                    Username = username,
                    Password = password,
                    UserRole = "User",
                    ID = IdCounter++,
                };
                accounts.Add(account);
                Console.WriteLine("User with username: {0} has been created!", account.Username);
            }
            else
            {
                Console.WriteLine("User creation canceled.");
            }

            Console.WriteLine("Press any key to return to the menu");
            Console.ReadKey();
        }
        public void RemoveUser()
        {
            int adminPick;

            Console.Clear();
            Console.WriteLine("Enter the id of which user you would like to remove from the bank");
            ShowAllUsers();

            while (true)
            {
                string? pick = Console.ReadLine();

                if (int.TryParse(pick, out adminPick))
                {
                    break;
                }
                else if (adminPick >= 0 && adminPick < accounts.Count)
                {
                    Console.WriteLine("Please pick the right number in the list");
                }
                else
                {
                    Console.WriteLine("Please type in a number");
                }
            }
            Console.WriteLine("Type the username that you would like to remove from the bank");
            bool userRemoved = false;

            while (!userRemoved)
            {
                string removeUser = Console.ReadLine();
                Person userToRemove = accounts.Find(user => user.Username == removeUser);

                if (userToRemove != null)
                {
                    accounts.Remove(userToRemove);
                    Console.WriteLine("User removed successfully!");
                    Console.WriteLine("Updated user list");
                    ShowAllUsers();
                    userRemoved = true;
                }
                else
                {
                    Console.WriteLine("User not found with that username. Please try again.");
                }
            }
            Console.WriteLine("Press any key to return to the menu");
            Console.ReadKey();
        }
        public void ShowAllUsers()
        {
            Console.Clear();
            Console.WriteLine("Show all users");

            if (accounts.Count == 0)
            {
                Console.WriteLine("No user in the list");
                return;
            }
            foreach (Person user in accounts)
            {
                Console.WriteLine("Id: {0} Username: {1} ", user.ID, user.Username);
            }
            Console.WriteLine("Press any key to return to the menu");
            Console.ReadKey();
        }
        public void UpdateExchangeRate()
        {

        }
        public void PrintMenu()
        {
            Console.WriteLine(@"
▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
█░▄▄▀██░▄▄▀██░▄▀▄░█▄░▄██░▀██░████░▄▀▄░██░▄▄▄██░▀██░██░██░█
█░▀▀░██░██░██░█░█░██░███░█░█░████░█░█░██░▄▄▄██░█░█░██░██░█
█░██░██░▀▀░██░███░█▀░▀██░██▄░████░███░██░▀▀▀██░██▄░██▄▀▀▄█
▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
 ");
        }
        private string[] menuOptions = {"[1]Open new account\t\t", "[2]Remove account\t\t",
        "[3]Show all accounts\t\t", "[4]End\t\t" };
        private int menuSelected = 0;
        public override void RunMenu()
        {

            while (true)
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                PrintMenu();
                Console.ResetColor();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Make a choice with the arrow");
                Console.WriteLine("Press Up or Down on the keyboard");
                Console.WriteLine("  then press Enter");
                Console.ResetColor();
                Console.WriteLine("\x1b[?25l");

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (i == menuSelected)
                    {
                        Console.WriteLine(menuOptions[i] + "<--");
                    }
                    else
                    {
                        Console.WriteLine(menuOptions[i]);
                    }
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                PrintTeamTag();
                Console.ResetColor();
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && menuSelected + 1 != menuOptions.Length)
                {
                    menuSelected++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && menuSelected != 0)
                {
                    menuSelected--;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (menuSelected)
                    {
                        case 0:
                            AddUser();
                            break;
                        case 1:
                            RemoveUser();
                            break;
                        case 2:
                            ShowAllUsers();
                            break;
                        default:
                            Console.WriteLine("Pick any of the options");
                            break;
                    }

                    Console.CursorVisible = true;

                    break;
                }
            }
        }
        public void PrintTeamTag()
        {
            Console.WriteLine(@"
 ^~^  ,                    \   /\      
('Y') )                    )  ( ')
/   \/  Team #1: CodeCats (  /  )
(\|||/)                     \(__)|");
        }
    }
}
