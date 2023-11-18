﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{

    internal class User : Person, Loans

    {
        //menu options, (how it will look)
        private string[] menuOptions = {"[1]Show Bank account\t\t", "[2]Borrow money\t\t",
        "[3]Open new account\t\t", "[4]Transfer to second account\t\t", "[5]Transfer to user\t\t",
        "[6]Show all transactions\t\t", "[7]End\t\t" };
        private int menuSelected = 0; // set value to 0

        public int Id { get; set; } // property
        public decimal Balance { get; set; }
        public int CreditScore { get; set; }
        public string BankAccount { get; set; }


        // User constructor and base (inheritance) from Person constructor.
        public User(string username, string password, string userRole, int id) : base(username, password, userRole, id) 
        {

        }


        public void RunMenu() // method to run menu, (putting this method in Person class later)
        {
            while (true) // if condition is true, run a loop
            {
                Console.Clear(); // Clear console for a cleaner display

                // Display menu
                Console.OutputEncoding = System.Text.Encoding.Unicode; //to se "special" symbols in console. specific : €
                Console.BackgroundColor = ConsoleColor.Blue; //make usermenu text blue and white
                Console.ForegroundColor = ConsoleColor.White;
                PrintMenu();
                Console.ResetColor(); // reset color to normal

                Console.WriteLine(); // Gap in coode
                Console.ForegroundColor = ConsoleColor.Blue; // make text blue
                Console.WriteLine("Make a choice with the arrow"); // text under user menu to so user understand to controll the arrow
                Console.WriteLine("Press Up or Down on the keyboard");
                Console.WriteLine("then press Enter");
                Console.ResetColor();
                Console.WriteLine("\x1b[?25l"); // Set insertion point color to black

                // Get the current date and time
                DateTime currentTime = DateTime.Now;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"       {currentTime}");
                Console.ResetColor();
                Console.WriteLine("");

                // Display menu options with arrow pointing to the selected option
                for (int i = 0; i < menuOptions.Length; i++) // make a loop for the arrow 
                {
                    if (i == menuSelected)
                    {
                        Console.WriteLine(menuOptions[i] + "<--"); // display how the arrow will look like
                    }
                    else
                    {
                        Console.WriteLine(menuOptions[i]);
                    }
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
                            ShowBankAccounts(); // refere to method
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[Overview of bank accounts]");
            Console.ResetColor();
            // Add your code for the method here:

            // objects for creating user accounts and balance (instans)
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
            Console.WriteLine("There are a total of :" + " " + accounts.Count + " " + " bank accounts"); // and write it out here                                                                                                      // Get the current date and time
            DateTime currentTime = DateTime.Now;
            // Display the result
            Console.Write("Current Time:  ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write($"{currentTime}");
            Console.ResetColor();
            Console.WriteLine(""); // nicer looking

            foreach (var account in accounts) //foreach loop to display accounts
            {
                Console.WriteLine(""); // nicer looking
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


            //(account.Balance) times exchange rate
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

            bool loanProcess = true;

            while (loanProcess)
            {
                Console.WriteLine("[Loan Menu]");
                Console.WriteLine("Our bank offers four types of loans:\n1.Mortgage loan: To finance a property.\n2.Personal Loan: Variety of reasons: Home improvments, personal expenses, dept consolidation and other reasons.\n3.Business Loan: To finance a business or company.\n4.Vehicle Loans: To finance a vehicle.");
                Console.Write("\nPlease notice can you can only take a loan up to five times the amount in your account. ");
                Console.Write("Enter 'exit' to leave Loan Menu.\n");
                Console.WriteLine("What loan do you want to take?");

                double interestRateMortgage = 3.2;
                double interestRatePersonal = 4.2;
                double interestRateBusiness = 3.7;
                double interestRateVehicle = 3.5;

                string loanInput = Console.ReadLine();
                int loanAmount = 0;
                double amountToPayBack = 0;

                if (loanInput == "Mortgage" || loanInput == "Mortgage loan" || loanInput == "mortgage" || loanInput == "mortgage loan")
                {
                    amountToPayBack = loanAmount + (loanAmount * interestRateMortgage);

                    Console.WriteLine("How much do you want to loan?: ");
                    bool isValidInput = int.TryParse(Console.ReadLine(), out loanAmount);

                    if (isValidInput && loanAmount > 0)
                    {
                        amountToPayBack = loanAmount + (loanAmount * interestRateMortgage);
                        Console.WriteLine("The total amount you have to pay back is: " + amountToPayBack);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a positive number.");
                    }
                }

                else if (loanInput == "Personal" || loanInput == "Personal loan" || loanInput == "personal" || loanInput == "personal loan")
                {
                    Console.WriteLine("How much do you want to loan?: ");
                    bool isValidInput = int.TryParse(Console.ReadLine(), out loanAmount);

                    if (isValidInput && loanAmount > 0)
                    {
                        amountToPayBack = loanAmount + (loanAmount * interestRatePersonal);
                        Console.WriteLine("The total amount you have to pay back is: " + amountToPayBack);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a positive number.");
                    }
                }

                else if (loanInput == "Business" || loanInput == "Business loan" || loanInput == "business" || loanInput == "business loan")
                {
                    Console.WriteLine("How much do you want to loan?");
                    bool isValidInput = int.TryParse(Console.ReadLine(), out loanAmount);

                    if (isValidInput && loanAmount > 0)
                    {
                        amountToPayBack = loanAmount + (loanAmount * interestRateBusiness);
                        Console.WriteLine("The total amount you have to pay back is: " + amountToPayBack);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a positive number.");
                    }
                }

                else if (loanInput == "Vehicle" || loanInput == "Vehicle loan" || loanInput == "vehicle" || loanInput == "vehicle loan")
                {
                    Console.WriteLine("How much do you want to loan?");
                    bool isValidInput = int.TryParse(Console.ReadLine(), out loanAmount);

                    if (isValidInput && loanAmount > 0)
                    {
                        amountToPayBack = loanAmount + (loanAmount * interestRateVehicle);
                        Console.WriteLine("The total amount you have to pay back is: " + amountToPayBack);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a positive number.");
                    }
                }

                else if (loanInput?.ToLower() == "exit")
                {
                    break; // Exit loop
                }

                else
                {
                    Console.WriteLine("Not a valid option");
                }

                Console.WriteLine("Do you want to stay in the loan menu? Please enter YES or NO");
                string loanChoice = Console.ReadLine();

                if (loanChoice?.ToLower() != "yes")
                {
                    loanProcess = false;
                    break; // Exit loop
                }
            }
            Console.ReadLine(); // Wait for user input
        }

        private void OpenNewBankAccount()
        {
            Console.Clear();
            // main menu for Open new bank account
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[Open new account]");
            Console.ResetColor();
            // Add your code for the OpenNewBankAccount here
            Console.WriteLine("type [1] to open a savings account \nType [2] to open other account");
            int userInput = int.Parse(Console.ReadLine()); // userinput to select 1 or 2

            if (userInput == 1) // if user type 1 and enter : 
            {
                // main menu for Saving account
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("       [Savings Account]");
                Console.ResetColor(); // reset color to normal
                Console.Clear();
                Console.WriteLine("           Welcome! \nWe have a yearly 1% savings interest rate");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                User b1 = new User("Peter", "********", "User", 101);
                {
                    b1.Username = "Peter";  // usernamne is Peter
                    b1.BankAccount = "Savings account"; // userinput for account name
                };
                Console.WriteLine($" :: {b1.BankAccount}  has been created ::");
                Console.ResetColor();
                Console.WriteLine("");
                Console.Write(" How much do you want to Deposit in €?  ");

                double userInput1 = double.Parse(Console.ReadLine()); // userinput to deposit Euro
                double yInterest = userInput1 * 0.01; // mathematic for 1% yearly rate of deposit 
                Console.WriteLine("");
                Console.WriteLine("*************Savings account info***************");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(userInput1 + "€ has been deposit to your savings account");
                Console.WriteLine();
                Console.WriteLine("you will receive " + yInterest + "€" + " a yearly interest rate");
                Console.ResetColor();
                Console.WriteLine("________________________________________________");
            }
            else if (userInput == 2) // if user type 2 and enter:
            {
                User b1 = new User("Peter", "********", "User", 101);
                {
                    b1.Username = "Peter";  // usernamne is Peter
                    Console.WriteLine("");
                    Console.Write("Write the name of the new bank account: ");
                    b1.BankAccount = Console.ReadLine(); // userinput for account name
                };

                // create a dictonary string "Peter" and class User.
                Dictionary<string, User> createAccount = new Dictionary<string, User>();
                createAccount.Add(b1.Username, b1); // strnig + class

                Console.WriteLine("");
                Console.WriteLine("***** Bank Account info *****");  // output for created acccount
                User newAccount = createAccount["Peter"];
                Console.WriteLine("{0} ID: {1} \n New bank Account = {2} \n",
                newAccount.Username, newAccount.ID, newAccount.BankAccount);
                Console.WriteLine(createAccount.Count() + " new account has been created \nThe currency = € //bank support"); // output + count method
                Console.WriteLine("------------------------------");
                Console.ReadLine(); // Wait for user input
            }
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

        public void PrintMenu()
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
