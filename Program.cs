namespace BankSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoginManager loginManager = new LoginManager();
            loginManager.PrintMenu(); //Prints login ascii art
            loginManager.RequestLogin(); //Login method
        }

    }
}