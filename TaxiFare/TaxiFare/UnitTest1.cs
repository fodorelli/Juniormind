using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TaxiFare
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod] 
         public void DayTimeFareForShortDistances()
        { 
            Assert.AreEqual(5,CalculateTaxiFare(1, 8)); 
        } 
         [TestMethod] 
         public void DayTimeFareForMiddleDistances()
        { 
             Assert.AreEqual(168, CalculateTaxiFare(21, 8)); 
        } 
        [TestMethod] 
         public void DayTimeFareForLongDistances()
         { 
             Assert.AreEqual(600, CalculateTaxiFare(100, 8)); 
         } 
         [TestMethod] 
         public void NightTimeFareForShortDistances()
         { 
             Assert.AreEqual(7, CalculateTaxiFare(1, 21)); 
         } 
         [TestMethod] 
         public void NightTimeFarForMiddleDistances()
         { 
             Assert.AreEqual(210, CalculateTaxiFare(21, 21)); 
         } 
        [TestMethod]
    public void NightTimeFareForLongDistances()
         { 
            Assert.AreEqual(800, CalculateTaxiFare(100, 21)); 
        } 
        decimal CalculateTaxiFare(int distanceInKm, int hour)
         { 
             decimal[] prices = GetPries(hour); 
            decimal pricePerKm = GetPricePerKilometer(distanceInKm, prices); 
             return distanceInKm* pricePerKm; 
         } 
 
 
        private decimal[] GetPries(int hour)
         { 
            decimal[] daytimeprice = { 5, 8, 6 }; 
            decimal[] nighttimeprice = { 7, 10, 8 }; 
            decimal[] prices = IsDayTimeHour(hour) ? daytimeprice : nighttimeprice; 
             return prices; 
         } 
 
 
         private bool IsDayTimeHour(int hour)
         { 
           return 8<= hour && hour< 21; 
        } 
 
 
         private decimal GetPricePerKilometer(int distanceInKm, decimal[] prices)
         { 

 
            if (IsLongDistance(distanceInKm)) 
                 return prices[2]; 
             if (IsMediumDistance(distanceInKm)) 
                 return prices[1]; 
             return prices[0]; 
         } 
 
 
         private bool IsLongDistance(int distanceInKm)
         { 
             return distanceInKm > 60; 
         } 
 
 
         private bool IsMediumDistance(int distanceInKm)
         { 
             return distanceInKm > 20; 
         }
    }
}
