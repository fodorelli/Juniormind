using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankRateTest
{
    [TestClass]
    public class BankRateTest
    {
        [TestMethod]
        public void RateForFirstMonth()
        {

            Assert.AreEqual(102, CalculateBankRate(200, 2, 12, 1));

        }
     

        decimal CalculateBankRate(decimal total, int periodInMonths, decimal interestPerYear, int currentMonth)

        {
            decimal principal = total / periodInMonths;
            decimal exactInterestPerMonth = interestPerYear / 12 / 100;
            return principal + total * exactInterestPerMonth;
        }

    }
}