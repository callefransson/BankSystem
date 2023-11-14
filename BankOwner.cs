using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class BankOwner 
    {
        public static decimal ShowUserTransactions(List<decimal>UserTransactions)
        {
            decimal total = 0;
            foreach (var item in UserTransactions)
            {
                total = total + item;
            }
            return total;
        }
        public void ShowUsers(List<string>Users)
        {
            foreach (var item in Users)
            {
                Console.WriteLine($"{User.Id} , {User.PersonalNumber} , {User.UserName} ");
            }
        }
        public void ShowAdmins(List<string>Admins)
        {
            foreach (var item in Admins)
            {
                Console.WriteLine($"{Administrator.Id} , {Administrator.PersonalNumber} , {Administrator.UserName}");
            }
        }
    }
}
