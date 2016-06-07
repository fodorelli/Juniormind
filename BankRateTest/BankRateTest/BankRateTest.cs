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
            decimal rate = CalculateBankRate(200, 2, 12, 1);
            Assert.AreEqual(102, rate);

        }
        public void RateForSecondMonth()
        {
            decimal rate = CalculateBankRate(200, 2, 12, 2);
            Assert.AreEqual(101, rate);
        }
        decimal CalculateBankRate(decimal total, int periodInMonths, decimal interestPerYear, int currentMonth)

        {
            decimal principal = total / periodInMonths;
            decimal exactInterestPerMonth = interestPerYear / 12 / 100;
            return principal + total * exactInterestPerMonth;
        }

    }
}