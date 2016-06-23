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
            double dimension = InitialDimension(770000, 230);
                         Assert.AreEqual(592900, dimension);
        }
        double InitialDimension(int newArea, int lengthOfNewArea)
         { 
             int initialLength = 0; 
             double initialArea = newArea - initialLength * lengthOfNewArea; 
             initialArea=initialLength* initialLength; 
 
 
             double delta = Math.Pow(lengthOfNewArea, 2) + 4 * newArea; 
             initialArea = (-lengthOfNewArea + Math.Sqrt(delta)) / 2; 
 
 
                return Math.Pow(initialArea, 2); 
        
          }
}
}
