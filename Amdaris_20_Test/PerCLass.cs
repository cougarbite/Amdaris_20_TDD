using NUnit.Framework;
using Amdaris_20_TDD;
using System;

namespace Amdaris_20_Test
{
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount firstAccount;
        private BankAccount secondAccount;
        private decimal faInitial;
        private decimal saInitial;


        [SetUp]
        public void Setup()
        {
            faInitial = 500;
            saInitial = 1000;
            firstAccount = BankAccountFactory.CreateBankAccount("Test first name", "Test last name", faInitial);
            secondAccount = BankAccountFactory.CreateBankAccount("Test second name", "Test second name", saInitial);
        }


        [TestCase(500.45)]
        [TestCase(0)]
        [TestCase(-20.59)]
        public void Deposit_Should_Update_Balance(decimal deposit)
        {
            //Arrange

            //Act
            firstAccount.Deposit(deposit);
            //Assert
            if (deposit <= 0)
            {
                Assert.AreEqual(faInitial, firstAccount.AccountBalance);
            }
            else
            {
                Assert.AreEqual(faInitial + deposit, firstAccount.AccountBalance);
            }
        }

        [TestCase(30000)]
        [TestCase(300)]
        [TestCase(0)]
        [TestCase(-25.3)]
        public void Withdraw_Should_Update_Balance(decimal withdraw)
        {
            //Arrange

            //Act
            //if(withdraw > 0)
                firstAccount.Withdraw(withdraw);
            //Assert
            if (withdraw <= 0 || withdraw > faInitial)
            {
                Assert.AreEqual(faInitial, firstAccount.AccountBalance);
            }
            else
                Assert.AreEqual(faInitial - withdraw, firstAccount.AccountBalance);
        }

        [TestCase(1)]
        [TestCase(0)]
        [TestCase(20)]
        public void Transfer_Should_Update_Balance_On_Both_Accounts(decimal amountTransfered)
        {
            //Arrange

            //Act
            firstAccount.Transfer(secondAccount, amountTransfered);

            //Assert
            if (amountTransfered > firstAccount.AccountBalance || amountTransfered == 0)
            {
                Assert.AreEqual(faInitial, firstAccount.AccountBalance);
                Assert.AreEqual(saInitial, secondAccount.AccountBalance);
            }
            else
            {
                Assert.AreEqual(faInitial - amountTransfered, firstAccount.AccountBalance);
                Assert.AreEqual(saInitial + amountTransfered, secondAccount.AccountBalance);
            }
        }
    }
}