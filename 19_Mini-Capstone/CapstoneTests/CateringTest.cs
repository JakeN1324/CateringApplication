using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class CateringTest
    {
        [TestMethod]
        public void Check_that_catering_object_is_created()
        {
            // Arrange 
            Catering catering = new Catering();

            // Act

            //Assert
            Assert.IsNotNull(catering);
        }

        [TestMethod]
        public void AddMoneyTest()
        {
            Catering testObject = new Catering();

            testObject.AddMoney(50.00M);
            decimal result = testObject.accountBalance;

            Assert.AreEqual(50.00M, result);
        }

        [TestMethod]
        public void BalanceAfterSelectProductTest()
        {
            Catering testObject = new Catering();


            testObject.accountBalance = 50.00M;
            testObject.SelectProduct("D5", 5);

            decimal result = testObject.accountBalance;

            Assert.AreEqual(37.50M, result);
            
        }

        [TestMethod]

        public void IsItemInCart()
        {
            Catering testObject = new Catering();
            CateringItem referenceItem = new CateringItem();

            testObject.accountBalance = 50.00M;
            testObject.SelectProduct("D5", 5);
            foreach (CateringItem item in testObject.items)
            {
                if (item.Code == "D5")
                {
                    referenceItem = item;

                }
            }

            Assert.IsTrue(testObject.ShoppingCart.Contains(referenceItem));
        }

        [TestMethod]
        public void CheckInventory()
        {
            Catering testObject = new Catering();
            CateringItem referenceItem = new CateringItem();

            testObject.accountBalance = 50.00M;
            testObject.SelectProduct("D5", 5);
            foreach(CateringItem item in testObject.items)
            {
                if (item.Code == "D5")
                {
                    referenceItem = item;
                    
                }
            }

            int result = referenceItem.Quantity;

            Assert.AreEqual(20, result);
        }

        [TestMethod]

        public void CompleteTransactionTest()
        {
            Catering testObject = new Catering();

            testObject.accountBalance = 50.00M;
            testObject.SelectProduct("D5", 6);
            testObject.CompleteTransaction();
            decimal result = testObject.accountBalance;

            Assert.IsTrue(result == 0.00M);
        }

        [TestMethod] 
        public void TestCorrectChange()
        {
            Catering testObject = new Catering();

            testObject.accountBalance = 50.00M;
            testObject.SelectProduct("D5", 7);
            testObject.CompleteTransaction();

            Assert.AreEqual(1, testObject.BillTypes["Twenties"]);
            Assert.AreEqual(1, testObject.BillTypes["Tens"]);
            Assert.AreEqual(2, testObject.BillTypes["Ones"]);
            Assert.AreEqual(2, testObject.BillTypes["Quarters"]);
        }
    }
}
