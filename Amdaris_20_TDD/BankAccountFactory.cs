using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdaris_20_TDD
{
    public static class BankAccountFactory
    {
        private static ILogger logger;
        public static BankAccount CreateBankAccount(string fn, string ln, decimal amount)
        {
            IOwner owner = new Owner(fn, ln);
            if (logger == null)
                logger = new EmailLogger();
            return new BankAccount(owner, logger, amount);
        }
    }
}
