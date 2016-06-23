using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Watermelon
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Yes()
        {
            Assert.AreEqual("Yes", Condition(10));
        }
        [TestMethod]
        public void No()
        {
            Assert.AreEqual("No", Condition(5));
        }
        public void No2()
        {
            Assert.AreEqual("No", Condition(2));
        }
        string Condition(int noOfKilograms)
        { 
            return Parity(noOfKilograms) ? "Yes" : "No"; 
        } 
 
 
         bool Parity(int number)
         { 
             if (number % 2 == 0 && number != 2) 
                 return true; 
             else 
                 return false; 
         } 
    }
}
