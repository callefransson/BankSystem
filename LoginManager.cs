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
            accounts.Add(new Person("Admin", "123", "Admin", 1));
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
                    User regularUser = new User(this, username, password, foundUser.UserRole, foundUser.ID);
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
        public void PrintTeamTag()
        {
            Console.WriteLine(@"
  /\_/\                         /\_/\    
 (>^.^<)                       (>^.^<)
((¨)(¨))_/ Team #1: CodeCats \_((¨)(¨))");

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

        public void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine(@"
▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
██░████▀▄▄▀█░▄▄▄██▄██░▄▄▀████░▄▀▄░█░▄▄█░▄▄▀█░██░██ 
██░████░██░█░█▄▀██░▄█░██░████░█░█░█░▄▄█░██░█░██░██
██░▀▀░██▄▄██▄▄▄▄█▄▄▄█▄██▄████░███░█▄▄▄█▄██▄██▄▄▄██ 
▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
");
            Console.ResetColor();
        }
    }
}