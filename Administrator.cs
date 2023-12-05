namespace BankSystem
{
    internal class Administrator : Person, IPrintMenu // Administrator class inherits from Person and IPrintMenu
    {
        public LoginManager loginManager;
        public Administrator(LoginManager loginManager, string username, string password, string userRole, int id) //Constructor for Administrator class base from Person class
            : base(username, password, userRole, id)
        {
            this.loginManager = loginManager;
        }

        Exchange exchangeRate = new Exchange();

        public bool IsValidInput(string input) // Checks if admin creates a username or password with spaces
        {
            return !input.Contains(" ");
        }
        public bool IsValidCharacters(string input)// Checks if admin creates a username or password with special characters
        {
            //Creating an array with chars
            char[] invalidCharacters = { '!', '"', '#', '%', '&', '/', '(', ')', '=', '?', '@', '$', '{', '[', ']', '}', '-', '_', '*', '|' };

            foreach (char c in input)
            {
                //Check if it is an invalid character
                if (invalidCharacters.Contains(c))
                {
                    return false; //Return false if an invalid character is found
                }
            }

            return true; // If no invalid character is found
        }
        public void AddUser() // Method for adding users to the bank
        {
            Console.Clear(); // Clears any code from before

            string adminInput;
            string username;
            string password;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[ Add a user to the bank ]");
            Console.ResetColor();

            do
            {
                Console.WriteLine("Create a username");
                username = Console.ReadLine();
                Console.WriteLine("Create a password");
                password = Console.ReadLine();
                Console.WriteLine("Are you sure you would like to create this user?\n1 = Yes, create user\n2 = No, cancel");

                adminInput = Console.ReadLine();

                switch (adminInput)
                {
                    case "1":
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please re-enter username and password.");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please select 1 or 2.");
                        Console.ResetColor();
                        break;
                }

            } while (adminInput != "1");

            if (IsValidInput(username) && IsValidInput(password))
            {
                if (IsValidCharacters(username) && IsValidCharacters(password)) //If username and password do not contain any spaces or special characters user is created
                {
                    Person account = new Person(username, password, "User", ID);
                    loginManager.AddUserToAccounts(account);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("User with username: {0} has been created!", account.Username);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("User creation cancelled. Can't have any special characters in username or password");
                    Console.WriteLine("Invalid characters are (!, #, ¤, %, &, /, (, ), =, ?, @, £, $, €, {, [, ], }, -, _, *, |");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User creation canceled. Cant have any spaces in username or password");
                Console.ResetColor();
            }
            Console.WriteLine("");
            ReturnToMenu();
        }
        public void RemoveUser() // Method for removing users from the list
        {
            Console.Clear();
            if (loginManager.Accounts.Count == 0) // If there are no users in the list
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No user in the list");
                Console.ResetColor();
                Console.WriteLine("");
                ReturnToMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[ Remove a user from the bank ]");
                Console.ResetColor();
                foreach (Person user in loginManager.Accounts) // Loops through all the users in the list
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Id: {0} Username: {1} ", user.ID, user.Username);
                    Console.ResetColor();
                }
            }

            Console.WriteLine("Type the username that you would like to remove from the bank");
            bool userRemoved = false;

            while (!userRemoved)
            {
                string removeUser = Console.ReadLine();
                Person userToRemove = loginManager.Accounts.Find(user => user.Username == removeUser);

                if (userToRemove != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("User removed successfully!");
                    Console.ResetColor();
                    loginManager.Accounts.Remove(userToRemove); // Removes the user from the list
                    userRemoved = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("User not found with that username. Please try again.");
                    Console.ResetColor();
                }
            }
            ReturnToMenu();
        }
        public void ShowAllUsers() //Method for showing all the users in the list
        {
            Console.Clear();

            if (loginManager.Accounts.Count == 0) // If there are no users in the list
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No user in the list");
                Console.ResetColor();
                ReturnToMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[ Show all users ]");
                Console.ResetColor();
                foreach (Person user in loginManager.Accounts)//Foreach loop showing all users in the list
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Id: {0} Username: {1} ", user.ID, user.Username);
                    Console.ResetColor();
                }
            }
            ReturnToMenu();
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
        private string[] menuOptions = {"[1]Open new account\t\t", "[2]Remove account\t\t", "[3]Show all accounts\t\t","[4]Update exchange rate\t\t","[5]Show exchange rate\t\t","[6]Sign out\t\t", "[7]End\t\t" };
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
                        case 3:
                            exchangeRate.UpdateExchangeRate(this);
                            break;
                        case 4:
                            exchangeRate.ShowExchangeRate(this);
                            break;
                        case 5: // Det alternativ som loggar ut
                            Console.Clear();
                            Console.WriteLine("Signing out...");
                            Thread.Sleep(1000);
                            Console.Clear();
                            loginManager.PrintMenu();
                            loginManager.RequestLogin();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("");
                            Console.WriteLine("Thank you for using CodeCats awesome bank!");
                            Environment.Exit(0);
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
        public override void ReturnToMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press any key to return to the menu");
            Console.ResetColor();
            Console.ReadKey(true);
            RunMenu();
        }
        public void PrintTeamTag()
        {
            Console.WriteLine(@"
  /\_/\                         /\_/\    
 (>^.^<)                       (>^.^<)
((¨)(¨))_/ Team #1: CodeCats \_((¨)(¨))");
        }
    }
}
