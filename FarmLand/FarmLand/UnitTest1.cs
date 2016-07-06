using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FarmLand
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            
                      Assert.AreEqual(770, InitialDimension(770000, 230));
        }
        double InitialDimension(int newArea, int lengthOfNewArea)
         {
            double Delta = lengthOfNewArea * lengthOfNewArea + 4 * newArea;

            double x1 = (-lengthOfNewArea + Math.Sqrt(Delta)) / 2;
            double x2 = (-lengthOfNewArea + Math.Sqrt(Delta)) / 2;

            return x1 > 0 ? x1 : x2;

        }
}
}
