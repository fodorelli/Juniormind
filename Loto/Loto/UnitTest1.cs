using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loto
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Loto6x49cat1()
        {
            Assert.AreEqual(0.0000000715, CalulateChancesToGetNnumbers(6, 6, 49));
        }
        [TestMethod]
        public void Loto6x49cat2()
        {
            Assert.AreEqual(0.0000184499, CalulateChancesToGetNnumbers(5, 6, 49));
        }
        [TestMethod]
        public void Loto6x49cat3()
        {
            Assert.AreEqual(0.0009686197, CalulateChancesToGetNnumbers(4, 6, 49));
        }
        [TestMethod]
        public void Loto6x49cat4()
        {
            Assert.AreEqual(0.0176504039, CalulateChancesToGetNnumbers(3, 6, 49));
        }
        [TestMethod]
        public void Loto5x40cat1()
        {
            Assert.AreEqual(0.0000015197, CalulateChancesToGetNnumbers(5, 5, 40));
        }

        double CalculateChances(double totalNumbers, double numbers)
        { 
            double chance = 1;  
             for (double i = numbers; i > 0; i--) 
             { 
                chance *= totalNumbers / i; 
                totalNumbers--; 
            } 
             
            return chance;  
        } 
        double CalulateChancesToGetNnumbers(double n, double allNumbers, double totalNumbers)
         { 
            double chanceToGetNoIwant = 0; 
            chanceToGetNoIwant = CalculateChances(allNumbers, n) * CalculateChances(totalNumbers - allNumbers, allNumbers - n)/ CalculateChances(totalNumbers, allNumbers); 
            return Math.Round(chanceToGetNoIwant, 10); 

 
        } 


    }
}
