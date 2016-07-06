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
            
           Assert.AreEqual(140, CalculateKgofHay(2, 5, 50, 7, 4));
        }
        
        decimal CalculateKgofHay(int NoofDays, int NoofGoats, decimal KgofHay, int NoofDaysAnswer, int NoofGoatsAnswer)
        {
            decimal HayGoatPerDay = KgofHay / (NoofDays * NoofGoats);
             return HayGoatPerDay * NoofGoatsAnswer * NoofDaysAnswer;
        }
    }
}
