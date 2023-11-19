using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class BankOwner : Person, IPrintMenu
    {
        public BankOwner(string username, string password) : base(username, password) { }

        private string[] menuOptions = {"[1]Show User Transactions\t\t", "[2]Show Users\t\t",
        "[3]Show Administrators\t\t", "[4]End\t\t" };
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
                            ShowUserTransactions();
                            break;
                        case 1:
                            ShowUsers();
                            break;
                        case 2:
                            ShowAdmins();
                            break;
                        case 3:
                            EndProgram();
                            break;
                    }

                    Console.CursorVisible = true;

                    break;
                }
            }
        }
        public static decimal ShowUserTransactions(List<decimal> UserTransactions)
        {
            Console.Clear();
            Console.WriteLine("\n[Showing all transactions]");
            decimal total = 0;
            foreach (var item in UserTransactions)
            {
                total = total + item;
            }
            return total;
        }
        public void ShowUsers(List<string> Users)
        {
            Console.Clear();
            foreach (var item in Users)
            {
                Console.WriteLine($"{User.Id} , {User.PersonalNumber} , {User.UserName}");
            }
        }
        public void ShowAdmins(List<string> Admins)
        {
            Console.Clear();
            foreach (var item in Admins)
            {
                Console.WriteLine($"{Administrator.Id} , {Administrator.PersonalNumber} , {Administrator.UserName}");
            }
        }
        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine(@"
▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
████░▄▄▀█░▄▄▀█░▄▄▀█░█▀█▀▄▄▀█░███░█░▄▄▀█░▄▄█░▄▄▀████░▄▀▄░█░▄▄█░▄▄▀█░██░████
████░▄▄▀█░▀▀░█░██░█░▄▀█░██░█▄▀░▀▄█░██░█░▄▄█░▀▀▄████░█░█░█░▄▄█░██░█░██░████
████░▀▀░█▄██▄█▄██▄█▄█▄██▄▄███▄█▄██▄██▄█▄▄▄█▄█▄▄████░███░█▄▄▄█▄██▄██▄▄▄████
▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
");
        }
        private void EndProgram()
        {
            Console.Clear();
            Console.WriteLine("\nProgram Ended");
        }
        public void PrintTeamTag()
        {
            Console.WriteLine(@"
  ^~^  ,                   \    /\      
('Y') )                    )  ( ')
/   \/  Team #1: CodeCats (  /  )
(\|||/)                     \(__)|");
        }
    }
}
