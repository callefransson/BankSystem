namespace BankSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            LoginManager loginManager = new LoginManager();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.ResetColor();
            loginManager.RequestLogin();
        }

    }
}