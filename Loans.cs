using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal interface Loans
    {
        public void LimitLoans()
        {
            decimal i = accountAmount * 5;
            Console.WriteLine("You can borrow " + i + " SEK");
        }
    }
}
