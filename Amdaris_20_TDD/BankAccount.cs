using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdaris_20_TDD
{
    public class BankAccount
    {
        private static int id;
        public int ID { get; set; }
        public decimal AccountBalance { get; set; }
        public IOwner AccountOwner { get; set; }
        public ILogger AccountLogger { get; set; }

        public BankAccount(IOwner owner, ILogger bankLogger, decimal initialBalance)
        {
            if (initialBalance > 0)
            {
                ID = ++id;
                AccountOwner = owner;
                AccountBalance = initialBalance;
                AccountLogger = bankLogger;
                AccountLogger.Log($"Bank Account created for {owner.FirstName} {owner.LastName}");
            }
            //else throw new ArgumentOutOfRangeException();
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                AccountLogger.Log("Illegal deposit amount!");
            }

            else
            {
                AccountBalance += amount;
            }

        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                AccountLogger.Log("Illegal withdraw amount!");
            }
            else if (amount > AccountBalance)
            {
                AccountLogger.Log("Insuficient funds!");
            }
            else
            {
                AccountBalance -= amount;
                AccountLogger.Log($"${amount} withdrawed.");
            }
        }

        public void Transfer(BankAccount toAccount, decimal amount)
        {
            if (!this.Equals(toAccount))
            {
                if (amount > this.AccountBalance)
                {
                    AccountLogger.Log("Insuficient funds!");
                }
                else if (amount <= 0)
                {
                    AccountLogger.Log("Illegal transfer amount");
                }
                else
                {
                    this.AccountBalance -= amount;
                    toAccount.AccountBalance += amount;
                    AccountLogger.Log($"${amount} transfered to {toAccount.AccountOwner.LastName} {toAccount.AccountOwner.FirstName}.");
                }

            }
            else throw new ArgumentException("Accounts must be different!");
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Owner: {this.AccountOwner.FirstName} {this.AccountOwner.LastName} Ballance: {this.AccountBalance}");
        }
    }
}
