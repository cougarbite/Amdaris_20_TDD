using Amdaris_20_TDD;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Amdaris_20_Test2
{
    [TestFixture(Author = "Gabriel Stanescu")]
    public class ApplicationTests
    {
        public class BankAccountCreateTests
        {

            [TestCase(500)]
            [TestCase(0)]
            [TestCase(-24.5)]
            public void Create_Account_Should_Initialize_Only_Positive_Balance(decimal initialBalance)
            {
                //Arrange

                //Act
                var ac = BankAccountFactory.CreateBankAccount("TFN", "TLN", initialBalance);

                //Assert
                if (initialBalance <= 0)
                {
                    Assert.AreEqual(0, ac.AccountBalance);
                }
                else
                    Assert.AreEqual(initialBalance, ac.AccountBalance);
            }

        }
        [TestFixture]
        public class BankAccountDepositTests
        {
            [TestCase(1000, 500)]
            [TestCase(1000, 0)]
            [TestCase(1000, -35)]
            [TestCase(1000, 2000)]
            public void Deposit_Updates_Balance_Only_With_Positive_Amount(decimal initial, decimal amount)
            {
                //Arrange
                decimal initialAmount = initial;
                var ac = BankAccountFactory.CreateBankAccount("TFN", "TLN", initialAmount);
                //Act
                ac.Deposit(amount);
                //Assert
                if (amount > 0)
                {
                    Assert.AreEqual(initialAmount + amount, ac.AccountBalance);
                }
                else
                    Assert.AreEqual(initialAmount, ac.AccountBalance);
            }
        }
        [TestFixture]
        public class BankAccountWthdrawTests
        {
            static object[] TestValues =
            {
                new decimal[] {1000, 500},
                new decimal[] {1000, 0},
                new decimal[] {1000, -35},
                new decimal[] {1000, 2000},
            };

            [Test, TestCaseSource("TestValues")]
            public void Withdraw_Updates_Balance_Only_With_Positive_Amount(decimal initial, decimal amount)
            {
                //Arrange
                decimal initialAmount = initial;
                var ac = BankAccountFactory.CreateBankAccount("TFN", "TLN", initialAmount);
                //Act
                ac.Withdraw(amount);
                //Assert
                if (amount > 0 && amount <= ac.AccountBalance)
                {
                    Assert.AreEqual(initialAmount - amount, ac.AccountBalance);
                }
                else
                    Assert.AreEqual(initialAmount, ac.AccountBalance);
            }
        }
        [TestFixture]
        public class BankAccountTransferTests
        {
            private BankAccount account1;
            private BankAccount account2;

            [SetUp]
            public void SetUp()
            {
                account1 = BankAccountFactory.CreateBankAccount("fn1", "ln1", 1000);
                account2 = BankAccountFactory.CreateBankAccount("fn2", "ln2", 2000);
            }


            [TestCase(1000, 2000, 500)]
            [TestCase(1000, 2000, 0)]
            [TestCase(1000, 2000, -35)]
            [TestCase(1000, 2000, 1500)]
            public void Transfer_Updates_Balance_On_Both_Accounts_Only_With_Positive_Amount(decimal faInitial, decimal saInitial, decimal amount)
            {
                //Arrange
                decimal faInitialAmount = faInitial;
                var ac1 = BankAccountFactory.CreateBankAccount("TFN", "TLN", faInitialAmount);

                decimal saInitialAmount = saInitial;
                var ac2 = BankAccountFactory.CreateBankAccount("TFN", "TLN", saInitialAmount);
                //Act
                ac1.Transfer(ac2, amount);
                //Assert
                if (amount > 0 && amount <= faInitialAmount)
                {
                    Assert.AreEqual(faInitialAmount - amount, ac1.AccountBalance);
                    Assert.AreEqual(saInitialAmount + amount, ac2.AccountBalance);
                }
                else
                {
                    Assert.AreEqual(faInitialAmount, ac1.AccountBalance);
                    Assert.AreEqual(saInitialAmount, ac2.AccountBalance);
                }
            }
        }
    }
}