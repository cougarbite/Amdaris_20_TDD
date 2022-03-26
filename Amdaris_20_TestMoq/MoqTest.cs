using Amdaris_20_TDD;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdaris_20_TestMoq
{
    [TestFixture]
    public class MoqTest
    {
        private readonly BankAccount systemUnderTest;
        private readonly Mock<IOwner> owner = new Mock<IOwner>();
        private readonly Mock<ILogger> logger = new Mock<ILogger>();
        private decimal initialAmount = 1000;

        public MoqTest()
        {
            systemUnderTest = new BankAccount(owner.Object, logger.Object, initialAmount);
        }

        [SetUp]
        public void SetUp()
        {
            owner.Name = "Account Owner Mock";
            owner.Object.FirstName = "FN Mock";
            owner.Object.LastName = "LN Mock";
        }
        [TestCase(500)]
        [TestCase(0)]
        [TestCase(-500)]
        public void Deposit_Should_Update_Balance(decimal amount)
        {
            //Arrange
            decimal initialBalance = systemUnderTest.AccountBalance;
            //Act
            systemUnderTest.Deposit(amount);
            //Assert
            if (amount > 0)
                Assert.AreEqual(initialBalance + amount, systemUnderTest.AccountBalance);
            else
                Assert.AreEqual(initialBalance, systemUnderTest.AccountBalance);
        }

        [TestCase(500)]
        [TestCase(0)]
        [TestCase(-500)]
        public void Withdraw_Should_Update_Ballance(decimal amount)
        {
            //Arrange
            decimal initialBalance = systemUnderTest.AccountBalance;
            //Act
            systemUnderTest.Withdraw(amount);
            //Assert
            if (amount > 0)
                Assert.AreEqual(initialBalance - amount, systemUnderTest.AccountBalance);
            else
                Assert.AreEqual(initialBalance, systemUnderTest.AccountBalance);
        }
    }
}
