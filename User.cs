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

        public User(string username, string password, string userRole, int id) : base(username, password, userRole, id)
        {

        }


        public void RunMenu()
        {
            while (true)
            {
                Console.Clear(); // Clear console for a cleaner display

                // Display menu
                Console.OutputEncoding = System.Text.Encoding.Unicode; //to se "special" symbols in console. specific : €
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
                    Console.ForegroundColor = ConsoleColor.Magenta; //made menu + arrow color Magenta
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

        public void ShowBankAccounts() // method #1, an overview of all the bank accounts
        {
            // "main" Menu in Bank aaccounts
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n[Overview of bank accounts]");
            Console.ResetColor();
            // Add your code for the method here:

            // code for creating user accounts and balance
            User b1 = new User("Peter", "***", "User", 101)
            {
                BankAccount = "Main Account   ",
                Balance = 100000
            };

            User b2 = new User("Peter", "***", "User", 101)
            {
                BankAccount = "Savings Account",
                Balance = 300000
            };

            User b3 = new User("Peter", "***", "User", 101)
            {
                BankAccount = "Utility Account ",
                Balance = 4000
            };

            User b4 = new User("Peter", "***", "User", 101)
            {
                BankAccount = "Index Account  ",
                Balance = 3000
            };

            //make a list of all user accounts
            List<User> accounts = new List<User>();
            accounts.Add(b1); // adding account 1
            accounts.Add(b2); // adding account 2
            accounts.Add(b3); // adding account 3
            accounts.Add(b4); // adding account 4

            Console.WriteLine(""); // nicer looking
                                   // method to count how many accounts the user has
            Console.WriteLine("There are a total of :" + " " + accounts.Count + " " + " bank accounts"); // and write it out here
            Console.WriteLine(""); // nicer looking

            foreach (var account in accounts) //foreach loop to display accounts
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($" {account.BankAccount}     Balance: {account.Balance}€"); // write out acc + balance
                Console.ResetColor();


                // Show balance in different currencies //calls the BalanceINCurrency method
                BalanceInCurrency(account, "GBP");
                BalanceInCurrency(account, "USD");
                BalanceInCurrency(account, "BTC");

                Console.WriteLine(); // separate each account's output
            }

            Console.ReadLine(); // Wait for user input
        }

        //calculates the balance in the specified currency using the oreignExchange method (Exchange rate) 
        //then prints the converted balance along with the currency symbol.
        public static void BalanceInCurrency(User account, string currency) // Balance in currency method with imperameters account and currency
        {
            // Get the exchange rate for the specified currency and stored in a decimal exchangeRate
            decimal foreignExchange = Forex(currency);


            //(account.Balance) is divided by the previously obtained exchange rate (exchangeRate)
            // exampel 3000€ * 0.87 GBP = 3448 GBP
            decimal convertedBalance = account.Balance * foreignExchange;

            // wrties out the Currency, the new balance of the converted balance, and the correct symbol
            Console.WriteLine($" {currency} Balance: {convertedBalance} {CurrencySymbol(currency)}");
        }


        //method to calculate the exChange rate, from currency to currency / country currency to country currency
        public static decimal Forex(string currency) // returns decimal
        {
            // Define your exchange rates here
            switch (currency.ToUpper()) // ToUpper = converted to uppercase
            {
                case "GBP":
                    return 0.86m; // Example: 1 EUR = 0.86 GBP
                case "USD":
                    return 1.18m; // Example: 1 EUR = 1.18 USD
                case "BTC":
                    return 0.00003m; // Example: 1 EUR = 0.00003 BTC
                default:
                    return 1.0m; // Default to no conversion for unknown currencies
            }
        }

        // method to place currency symbols after account
        public static string CurrencySymbol(string currency) //returns string
        {
            // Define symbols for different currencies
            switch (currency.ToUpper())
            {
                case "GBP":
                    return "£";
                case "USD":
                    return "$";
                case "BTC":
                    return "BTC";
                default:
                    return "";
            }
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
█░██░█░▄▄█░▄▄█░▄▄▀███░▄▀▄░█░▄▄█░▄▄▀█░██░█
█░██░█▄▄▀█░▄▄█░▀▀▄███░█░█░█░▄▄█░██░█░██░█
█▄▀▀▄█▄▄▄█▄▄▄█▄█▄▄███░███░█▄▄▄█▄██▄██▄▄▄█
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
