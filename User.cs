using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{

    internal class User : Person, ILoans, IDelay

    {
        //menu options, (how it will look)
        private string[] menuOptions = {"[1]Show Bank account\t\t", "[2]Borrow money\t\t",
        "[3]Open new account\t\t", "[4]Transfer to second account\t\t", "[5]Transfer to user\t\t",
        "[6]Show all transactions\t\t", "[7]End\t\t" };
        private int menuSelected = 0; // set value to 0

        public decimal Balance { get; set; }
        public int CreditScore { get; set; } // are we still going to use?
        public string BankAccount { get; set; }
         

        List<Transaction> transactionsList = new List<Transaction>(); //creates a list of transactions for ShowAllTransactions method

        public List<Accounts> userAccounts = new List<Accounts>(); //creates a list of userAccounts for TransferToUser method

        List<User> showAccounts = new List<User>(); // list in ShowbankAccountsmethod();
        Dictionary<string, User> createAccount = new Dictionary<string, User>(); // Dictonary in OpenNewBankAccounts list

        public List<User> users = new List<User>();  // creates a list of users



        // User constructor and base (inheritance) from Person constructor.
        public User(string username, string password, string userRole, int id) : base(username, password, userRole, id) { }


        public override void RunMenu() // method to run menu
        {
            while (true) // if condition is true, run a loop
            {
                Console.Clear(); // Clear console for a cleaner display

                // Show User menu
                Console.OutputEncoding = System.Text.Encoding.Unicode; //to se "special" symbols in console. specific : €
                Console.BackgroundColor = ConsoleColor.Black; //make usermenu  backgeund text Black 
                Console.ForegroundColor = ConsoleColor.Red; // and Red
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
            // "main" Menu or logo in  show Bank aaccounts
            Console.OutputEncoding = System.Text.Encoding.Unicode; // to see special signs (euro sign)
            Console.Clear();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Overview ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("of ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("bank ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("accounts");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("]");
            Console.ResetColor();
            Console.WriteLine("");
            // Add your code for the method here:

            // objects for creating user accounts and balance (instans)
            User b1 = new User("JaneDoe", "***", "User", 101)
            {
                BankAccount = "Main Account   ",
                Balance = 100000
            };

            User b2 = new User("JaneDoe", "***", "User", 101)
            {
                BankAccount = "Savings Account",
                Balance = 300000
            };

            User b3 = new User("JaneDoe", "***", "User", 101)
            {
                BankAccount = "Utility Account ",
                Balance = 4000
            };

            User b4 = new User("JaneDoe", "***", "User", 101)
            {
                BankAccount = "Index Account  ",
                Balance = 3000
            };

            //make a list of all user accounts
            //List<User> showAccounts = new List<User>(); put it outside under properties.

            showAccounts.Add(b1); // adding account 1
            showAccounts.Add(b2); // adding account 2
            showAccounts.Add(b3); // adding account 3
            showAccounts.Add(b4); // adding account 4

            Console.WriteLine(""); // nicer looking
                                   // method to count how many accounts the user has
            Console.WriteLine("There are a total of :" + " " + showAccounts.Count + " " + " bank accounts"); // and write it out here                                                                                                      // Get the current date and time
            DateTime currentTime = DateTime.Now;
            // Display the result
            Console.Write("Current Time:  ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write($"{currentTime}");
            Console.ResetColor();
            Console.WriteLine(""); // nicer looking

            foreach (var account in showAccounts) //foreach loop to display accounts
            {
                Console.WriteLine(""); // nicer looking
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($" {account.BankAccount}     Balance: {account.Balance}€"); // write out acc + balance
                Console.ResetColor();


                // Show balance in different currencies //calls the BalanceINCurrency method
                BalanceInCurrency(account, "GBP");
                BalanceInCurrency(account, "USD");
                BalanceInCurrency(account, "BTC");
                BalanceInCurrency(account, "SEK");

                Console.WriteLine(); // separate each account's output
            }

            ReturnToMenu();
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
                    return 0.87m; // 1 EUR = 0.86 GBP // watched Exchange rate from the exchange Class
                case "USD":
                    return 1.09m; // 1 EUR = 1.18 USD // watched Exchange rate from the exchange Class
                case "BTC":
                    return 0.00003m; // 1 EUR = 0.00003 BTC
                case "SEK":
                    return 11.47m; // 1 EUR = 11.47 SEK // watched Exchange rate from the exchange Class
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
                    return "₿";
                case "SEK":
                    return "Kr";
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
                Console.WriteLine("Our bank offers four types of loans:\n1.Mortgage loan: To finance a property.\n2.Personal Loan: Variety of reasons: Home improvments, personal expenses, dept consolidation etc.\n3.Business Loan: To finance a business or company.\n4.Vehicle Loans: To finance a vehicle.");
                Console.Write("\nPlease notice can you can only take a loan up to five times the amount in your account. ");
                Console.Write("Enter '5' to leave the loan sections.\n");
                Console.WriteLine("Which loan are you interested in?");

                int Balance = 32000;
                decimal maxLoanAmount = Balance * 5;

                double debt = 0;
                int loanInput = Convert.ToInt32(Console.ReadLine());
                int loanAmount = 0;


                if (loanInput == 1) // Mortgage loan
                {

                    Console.WriteLine("How much money do you want to borrow?: ");
                    bool isValidInput = int.TryParse(Console.ReadLine(), out loanAmount);

                    if (isValidInput && loanAmount > 0)
                    {
                        if (loanAmount > maxLoanAmount)
                        {
                            Console.WriteLine("Warning: The amount you're trying to borrow exceeds the loan limit.");
                        }

                        else
                        {
                            double interestRateMortgage = 3.2;

                            // Annual plan - total amount to pay per month
                            double mortgageMonthyAmount = loanAmount + (loanAmount * interestRateMortgage) / 12;
                            // Total debt
                            debt = loanAmount + (loanAmount * interestRateMortgage);
                            Console.WriteLine("Your total debt is: " + debt + "." + " The amount you have to pay each month is: " + mortgageMonthyAmount.ToString("N3"));
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a positive number.");
                    }
                }

                else if (loanInput == 2) // Personal loan
                {
                    Console.WriteLine("How much money do you want to borrow?: ");
                    bool isValidInput = int.TryParse(Console.ReadLine(), out loanAmount);

                    if (isValidInput && loanAmount > 0)
                    {
                        if (loanAmount > maxLoanAmount)
                        {
                            Console.WriteLine("Warning: The amount you're trying to borrow exceeds the loan limit.");
                        }

                        else
                        {
                            double interestRatePersonal = 4.2;

                            // Annual plan - total amount to pay per month
                            double personalMonthlyAmount = loanAmount + (loanAmount * interestRatePersonal) / 12;
                            // Total debt
                            debt = loanAmount + (loanAmount * interestRatePersonal);
                            Console.WriteLine("Your total debt is: " + debt + "." + " The amount you have to pay each month is: " + personalMonthlyAmount.ToString("N3"));
                        }


                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a positive number.");
                    }
                }

                else if (loanInput == 3) // Business loan
                {
                    Console.WriteLine("How much money do you want to borrow?: ");
                    bool isValidInput = int.TryParse(Console.ReadLine(), out loanAmount);

                    if (isValidInput && loanAmount > 0)
                    {
                        if (loanAmount > maxLoanAmount)
                        {
                            Console.WriteLine("Warning: The amount you're trying to borrow exceeds the loan limit.");
                        }

                        else
                        {
                            double interestRateBusiness = 3.7;

                            // Annual plan - total amount to pay per month
                            double businessMonthlyAmount = loanAmount + (loanAmount * interestRateBusiness) / 12;
                            // Total debt
                            debt = loanAmount + (loanAmount * interestRateBusiness);
                            Console.WriteLine("Your total debt is: " + debt + "." + " The amount you have to pay each month is: " + businessMonthlyAmount.ToString("N3"));
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a positive number.");
                    }
                }

                else if (loanInput == 4) // Vehicle loan
                {
                    Console.WriteLine("How much money do you want to borrow?: ");
                    bool isValidInput = int.TryParse(Console.ReadLine(), out loanAmount);

                    if (isValidInput && loanAmount > 0)
                    {
                        if (loanAmount > maxLoanAmount)
                        {
                            Console.WriteLine("Warning: The amount you're trying to borrow exceeds the loan limit.");
                        }

                        else
                        {
                            double interestRateVehicle = 3.5;

                            // Annual plan - total amount to pay per month
                            double vehicleMonthlyAmount = loanAmount + (loanAmount * interestRateVehicle) / 12;
                            // Total debt
                            debt = loanAmount + (loanAmount * interestRateVehicle);
                            Console.WriteLine("Your total debt is: " + debt + "." + " The amount you have to pay each month is: " + vehicleMonthlyAmount.ToString("N3"));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a positive number.");
                    }
                }

                else if (loanInput == 5)
                {
                    break; // Exit loop
                }

                else
                {
                    Console.WriteLine("Not a valid option");
                }

                Console.WriteLine("Do you wish to remain in the loan segement? Please enter YES or NO");
                string loanChoice = Console.ReadLine();
                ReturnToMenu();

                if (loanChoice?.ToLower() != "yes")
                {
                    loanProcess = false;
                    break; // Exit loop
                }
                
            }


        }

        private void OpenNewBankAccount()
        {
            Console.Clear();
            // main menu for Open new bank account
            Console.OutputEncoding = System.Text.Encoding.Unicode; // to see special signs (euro sign)
            Console.Clear();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Open ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("new ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("account");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("]");
            Console.ResetColor();
            Console.WriteLine("");
            

            Console.WriteLine("");
            Console.Write("type");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[1]");
            Console.ResetColor();
            Console.Write("to open a ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("savings account");
            Console.ResetColor();
            Console.Write("\ntype");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[2]");
            Console.ResetColor();
            Console.Write("to open ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("other account");
            Console.WriteLine("");
            Console.ResetColor();
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
                User b1 = new User("JaneDoe", "********", "User", 101);
                {
                    b1.Username = "JaneDoe";  // username
                    b1.BankAccount = "Savings account"; // userinput for account name
                };
                Console.WriteLine($" :: {b1.BankAccount}  has been created ::");
                Console.ResetColor();
                Console.WriteLine("");

                bool validInput = false; // valid input = false
                while (!validInput) // not false to run the loop
                {
                    Console.Write(" How much do you want to Deposit in €?  ");

                    if (double.TryParse(Console.ReadLine(), out double userInput1))
                    {
                        double yInterest = userInput1 * 0.01; // mathematic for 1% yearly rate of deposit 
                        Console.WriteLine("");
                        Console.WriteLine("*************Savings account info***************");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        DelayTransfer(); // method to delay transfer 
                        Console.WriteLine(userInput1 + "€ has been deposit to your savings account");
                        Console.WriteLine();
                        Console.WriteLine("you will receive " + yInterest + "€" + " a yearly interest rate");
                        Console.ResetColor();
                        Console.WriteLine("________________________________________________");

                        validInput = true; // set to true to exit the loop
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter sufficient amount.");
                    }
                }
            }
            else if (userInput == 2) // if user type 2 and enter:
            {
                User b1 = new User("JaneDoe", "********", "User", 101);
                {
                    b1.Username = "JaneDoe";  // username
                    Console.WriteLine("");
                    Console.Write("Write the name of the new bank account: ");
                    b1.BankAccount = Console.ReadLine(); // userinput for account name
                };

                // create a dictonary string "JaneDoe" and class User.
                //Dictionary<string, User> createAccount = new Dictionary<string, User>();
                createAccount.Add(b1.Username, b1); // strnig + class

                Console.WriteLine("");
                Console.WriteLine("***** Bank Account info *****");  // output for created acccount
                User newAccount = createAccount["JaneDoe"];
                Console.WriteLine("{0} ID: {1} \n New bank Account = {2} \n",
                newAccount.Username, newAccount.ID, newAccount.BankAccount);
                Console.WriteLine(createAccount.Count() + " new account has been created \nThe currency = € //bank support"); // output + count method
                Console.WriteLine("------------------------------");
                ReturnToMenu();
            }
        }

        private void TransferToSecondAccount()
        {
            Console.Clear();
            Console.WriteLine("\n[Transfer to second account]");
            // Add your code for the fourth choice here
            ReturnToMenu();
        }

        private void TransferToUser()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n [Transfer to user]");
            Console.WriteLine("\n Choose which account to transfer money from:");

            User userA = new User("JaneDoe", "Anna123", "user", ID); //creates users
            userA.NewAccount(5);
            userA.NewAccount(7);
            userA.NewAccount(8);

            User userB = new User("Anders", "Anders123", "user", ID);
            userB.NewAccount(2);
            userB.NewAccount(3);
            userB.NewAccount(6);

            users.Add(userA); //adds users to list
            users.Add(userB);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("List of JaneDoe's accounts:");
            foreach (var account in userA.userAccounts)
            {
                Console.Write(account.AccountNumber); 
                Console.WriteLine();
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            string userInput = Console.ReadLine();    
            int userNumber = Int32.Parse(userInput);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Accounts userAAcc = userA.userAccounts.Find(x => x.AccountNumber == userInput); //finds user account to transfer from

            Console.WriteLine("\n Choose which account to transfer money to:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("List of Ander's accounts:");
            foreach (var account in userB.userAccounts)
            {
                Console.Write(account.AccountNumber);
                Console.WriteLine();
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            string userInput1 = Console.ReadLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Accounts userBAcc = userB.userAccounts.Find(x => x.AccountNumber == userInput1); //finds user account to transfer to

            Console.WriteLine("\n Displaying total amount in chosen accounts before transfer:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Total amount in JaneDoe's account:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(userAAcc.TotalAmount + " SEK");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Total amount in Ander's account:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(userBAcc.TotalAmount + " SEK"); //shows total amount before transfer
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\n Choose amount of money to transfer:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            string userInput2 = Console.ReadLine();
            int amountToTransfer = Int32.Parse(userInput2);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;

            TransferMoney(userAAcc, userBAcc, amountToTransfer); //transferring money from user A to user B
            DelayTransfer(); //delaying transfer

            Console.WriteLine("\n Displaying total amount in chosen accounts after transfer:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Total amount in JaneDoe's account:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(userAAcc.TotalAmount + " SEK");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Total amount in Ander's account:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(userBAcc.TotalAmount + " SEK"); //shows total amount after transfer
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            

            // Create object of Transaction class
            Transaction transaction = new Transaction();
            transaction.FromUser = userA.Username;
            transaction.ToUser = userB.Username;
            transaction.TotalAmount = 500;

            transactionsList.Add(transaction);

            ReturnToMenu();
        }

        private void ShowAllTransactions()
        {
            Console.Clear();
            Console.WriteLine("\n[Showing all transactions]");
            
            foreach (Transaction transaction in transactionsList) 
            {
                Console.WriteLine($"\n[Transactions]:\nFrom account: {transaction.FromUser}\nTo account: {transaction.ToUser}\nAmount: {transaction.TotalAmount}");
            }

            ReturnToMenu();
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
  /\_/\                         /\_/\    
 (>^.^<)                       (>^.^<)
((¨)(¨))_/ Team #1: CodeCats \_((¨)(¨))");

        }

        public void NewAccount(int uniqueId) //method for creating accounts for TransferToUser method
        {
            Accounts newAccount = new Accounts();
            newAccount.TotalAmount = 1000;
            newAccount.AccountNumber = "123123456" + uniqueId;

            userAccounts.Add(newAccount);
        }
        public static void TransferMoney(Accounts accountA, Accounts accountB, int amountToTransfer) //method for transferring money for TransferToUser method
        {
            accountA.TotalAmount -= amountToTransfer;
            accountB.TotalAmount += amountToTransfer;

        }

        public void DelayTransfer() // method to delay transfer
        {
            Console.WriteLine("\n Transfer initiated. Please wait...");
            TimeSpan interval = TimeSpan.FromSeconds(4); // change it to: FromMinutes(15), for  15 minutes, now its 4 second to show that is working
            Thread.Sleep(interval);
            //Transaction completed.
            Console.WriteLine("Transfer successful");
        }
        public override void ReturnToMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press any key to return to the menu");
            Console.ResetColor();
            Console.ReadKey(true);
            RunMenu();
        }
    }
}
