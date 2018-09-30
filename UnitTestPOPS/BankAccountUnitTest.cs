using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POPS;

namespace UnitTestPOPS
{
    [TestClass]
    public class BankAccountUnitTest
    {
        [TestMethod]
        public void TestCreateSavingsAccount()
        {
            SavingsAccount s1 = new SavingsAccount();
            s1.openAccount(1001, "Radha");

            Assert.AreEqual(1001, s1.Balance);
            Assert.AreEqual("Radha", s1.Username);
            Assert.AreEqual("Savings", s1.typeOfAccount);
        }
        [TestMethod]
        public void TestCreateCurrentAccount()
        {
            CurrentAccount s1 = new CurrentAccount();
            s1.openAccount(30000, "Swamy");

            Assert.AreEqual(30000, s1.Balance);
            Assert.AreEqual("Swamy", s1.Username);
            Assert.AreEqual("Current", s1.typeOfAccount);
        }
        [TestMethod]
        public void TestWithdrawAccount()
        {
            CurrentAccount s1 = new CurrentAccount();
            s1.openAccount(30000, "Swamy");
            Assert.AreEqual(30000, s1.Balance);
            s1.withdraw(10000);
            Assert.AreEqual(20000, s1.Balance);
        }

        [TestMethod]
        public void TestDepositAccount()
        {
            SavingsAccount s1 = new SavingsAccount();
            s1.openAccount(30000, "Swamy");
            Assert.AreEqual(30000, s1.Balance);
            s1.deposit(10000);
            Assert.AreEqual(40000, s1.Balance);
        }
        [TestMethod]
        public void TestTransferAccount()
        {
            SavingsAccount s1 = new SavingsAccount();
            SavingsAccount s2 = new SavingsAccount();
            s1.openAccount(50000, "Swamy");
            s2.openAccount(30000, "Nandan");
            Assert.AreEqual(50000, s1.Balance);
            Assert.AreEqual(30000, s2.Balance);
            s1.TransferAmount(s2._AccountNumber,10000);
            Assert.AreEqual(40000, s1.Balance);
            Assert.AreEqual(40000, s2.Balance);
        }
    }
}
