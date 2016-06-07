using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Goats
{
    [TestClass]
    public class Goats
    {
        [TestMethod]
        public void TestMethod1()
        {
            decimal amountHay = CalculateKgHay(2, 5, 50, 7, 4);
            Assert.AreEqual(140, amountHay);
        }
        
        decimal CalculateKgHay(int nrDays, int nrGoats, decimal kgHay, int nrdaysanswer, int nrgoatsanswer)
        {
            decimal hayGoatPerDay = kgHay / (nrDays * nrGoats);
             return hayGoatPerDay * nrgoatsanswer * nrdaysanswer;
        }
    }
}
