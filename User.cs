using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{

    internal class User : Person, Loans

    {
        private string[] menuOptions = {"[1]Show Bank account\t\t", "[2]Borrow money\t\t",
        "[3]Open new account\t\t", "[4]Transfer to second account\t\t", "[5]Transfer to user\t\t",
        "[6]Show all transactions\t\t", "[7]End\t\t" };
        private int menuSelected = 0;

        public int Id { get; set; } // property
        public decimal Balance { get; set; }
        public int CreditScore { get; set; }
        public string BankAccount { get; set; }

        public User(string userRole, double personalNumber) : base(userRole, personalNumber)
        {

        }


        public override void RunMenu()
        {
            while (true)
            {
                Console.Clear(); // Clear console for a cleaner display

                // Display menu
                Console.BackgroundColor = ConsoleColor.Blue; //make usermenu text blue and white
                Console.ForegroundColor = ConsoleColor.White;
                PrintUserMenu();
                Console.ResetColor(); // reset color to normal

                Console.WriteLine(); // Gap in coode
                Console.ForegroundColor = ConsoleColor.Blue; // make text blue
                Console.WriteLine("Make a choice with the arrow");
                Console.WriteLine("Press Up or Down on the keyboard");
                Console.WriteLine("  then press Enter");
                Console.ResetColor();
                Console.WriteLine("\x1b[?25l"); // Set insertion point color to black

                // Display menu options with arrow pointing to the selected option
                for (int i = 0; i < menuOptions.Length; i++) // make a loop for the arrow 
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray; //make menu + arrow Dark Gray
                    if (i == menuSelected)
                    {
                        Console.WriteLine(menuOptions[i] + "<--"); // display how the arrow will look like
                    }
                    else
                    {
                        Console.WriteLine(menuOptions[i]);
                    }
                    Console.ResetColor(); // reset color
                }

                Console.ForegroundColor = ConsoleColor.Cyan; //make Teamtag text blue
                PrintTeamTag(); // printing the team tag!
                Console.ResetColor(); // reset color to normal

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                // Update menu selection based on arrow key input
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
                    // Perform action based on selected menu option
                    switch (menuSelected)
                    {
                        case 0:
                            ShowBankAccounts();
                            break;
                        case 1:
                            BorrowMoney();
                            break;
                        case 2:
                            OpenNewBankAccount();
                            break;
                        case 3:
                            TransferToSecondAccount();
                            break;
                        case 4:
                            TransferToUser();
                            break;
                        case 5:
                            ShowAllTransactions();
                            break;
                        case 6:
                            EndProgram();
                            break;

                    }

                    // Reset console cursor visibility
                    Console.CursorVisible = true;

                    // Exit the loop
                    break;
                }
            }
        }

        private void ShowBankAccounts()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n[Overwiev of bank accounts]");
            Console.ResetColor();
            // Add your code for the first choice here
            User userOne = new User("User", 8905281111)
            {
                BankAccount = "Account",
                Balance = 100000
            };

            User Balance2 = new User("User", 8905281111)
            {
                Balance = 300000
            };

            User Balance3 = new User("User", 8905281111)
            {
                Balance = 4000
            };

            User Balance4 = new User("User", 8905281111)
            {
                Balance = 3000
            };
            List<User> users = new List<User>();
            users.Add(userOne);

            foreach (var user in users)
            {
                Console.WriteLine(
                $"\nMain {user.BankAccount}                                     Balance: {user.Balance}£" +
                $"\nSavings {user.BankAccount}                                  Balance: {Balance2.Balance}£" +
                $"\nMonthly utiliy costs {user.BankAccount}                     Balance: {Balance3.Balance}£" +
                $"\nMonthly Stock market deposit {user.BankAccount}             Balance {Balance4.Balance}£");
            }
            Console.ReadLine(); // Wait for user input
        }

        private void BorrowMoney()
        {
            Console.Clear();
            Console.WriteLine("\n[Borrow money]");
            // Add your code for the second choice here
            Console.WriteLine("Här vill jag att ");
            Console.ReadLine(); // Wait for user input
        }

        private void OpenNewBankAccount()
        {
            Console.Clear();
            Console.WriteLine("\n[Open new account]");
            // Add your code for the third choice here
            Console.ReadLine(); // Wait for user input
        }

        private void TransferToSecondAccount()
        {
            Console.Clear();
            Console.WriteLine("\n[Transfer to second account]");
            // Add your code for the fourth choice here
            // Add withdraw and deposit 
            Console.ReadLine(); // Wait for user input
        }

        private void TransferToUser()
        {
            Console.Clear();
            Console.WriteLine("\n[Transfer to user");
            // Add your code for the fifth choice here

            Console.ReadLine(); // Wait for user input
        }

        private void ShowAllTransactions()
        {
            Console.Clear();
            Console.WriteLine("\n[Showing all transactions]");
            // Add your code for the sixth choice here ( a list)
            Console.ReadLine(); // Wait for user input
        }

        private void EndProgram()
        {
            Console.Clear();
            Console.WriteLine("\nProgram Ended");
            // end the program here
        }

        public void PrintUserMenu()
        {
            Console.WriteLine(@"
▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
██░██░█░▄▄█░▄▄█░▄▄▀███░▄▀▄░█░▄▄█░▄▄▀█░██░
██░██░█▄▄▀█░▄▄█░▀▀▄███░█▄█░█░▄▄█░██░█░▀▀░
██▄▀▀▄█▄▄▄█▄▄▄█▄█▄▄███▄███▄█▄▄▄█▄██▄█▀▀▀▄
▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
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
