using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdaris_20_TDD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ba = BankAccountFactory.CreateBankAccount("Gabriel", "Stanescu", 5000);
            ba.PrintDetails();
            ba.Deposit(500);
            ba.PrintDetails();
            ba.Withdraw(1000);
            ba.PrintDetails();
            var ba2 = BankAccountFactory.CreateBankAccount("Diana", "Stanescu", 3000);
            ba2.PrintDetails();
            ba2.Deposit(200);
            ba2.PrintDetails();
            ba2.Withdraw(1200);
            ba.PrintDetails();
            ba.Transfer(ba2, 2000);
            ba.PrintDetails();
            ba2.PrintDetails();
        }
    }
}
