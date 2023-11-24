namespace BankSystem
{
    public class Person
    {
        //private fields for id
        private static int _adminID = 0;
        private static int _userID = 1;
        //properties
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public int ID { get; }

        public Person(string username, string password, string userRole, int id)
        {
            Username = username;
            Password = password;
            UserRole = userRole;
            if (userRole == "Admin")
            {
                _adminID++; //Id increases by 1
                ID = _adminID;
            }
            else if (userRole == "User")
            {
                _userID++; // Id increases by 1
                ID = _userID;
            }
        }
        public virtual void RunMenu() { }
        public virtual void ReturnToMenu() { }
    }
}



