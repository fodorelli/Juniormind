using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rent
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod] 
       public void RentTest1()
       { 
            Assert.AreEqual(11, CalculateRent(10, 5)); 
        } 
 
 
         [TestMethod] 
         public void RentTest2()
         { 
             Assert.AreEqual(20, CalculateRent(10, 20)); 
         } 

        [TestMethod] 
        public void RentTest3()
         { 
             Assert.AreEqual(45, CalculateRent(10, 35)); 
         }


    decimal CalculateRent(int rent, int numberOfDaysLate)
        { 
            decimal totalRent = rent; 
            if ((numberOfDaysLate > 0) && (numberOfDaysLate <= 10)) 
                 totalRent = rent + numberOfDaysLate* rent * 2 /100; 
            else  
                  if ((numberOfDaysLate > 10) && (numberOfDaysLate <=30 )) 
                     totalRent = rent + numberOfDaysLate* rent * 5 / 100; 
             else 
                 if ((numberOfDaysLate > 30) && (numberOfDaysLate <= 40)) 
                 totalRent = rent + numberOfDaysLate* rent * 10 / 100; 
 
 
             return totalRent;  
         }
}
}
