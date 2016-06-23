using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArchaeologicalSite
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
         double MinimumArea= CalculateMinimumArea(2, 3, 1, 2, 3, 1);
            Assert.AreEqual(24, MinimumArea);
        }
        double CalculateMinimumArea(double firstColumnX, double firstColumnY, double secondColumnX, double secondColumnY, double thirdColumnX, double thirdColumnY)
        {
                         double side1 = Math.Sqrt((firstColumnX - secondColumnX)* (firstColumnX - secondColumnX) + (firstColumnY - secondColumnY)* (firstColumnY - secondColumnY));
                        double side2 = Math.Sqrt((firstColumnX - thirdColumnX)* (firstColumnX - thirdColumnX) + (firstColumnY - thirdColumnY)* (firstColumnY - thirdColumnY));
                         double side3 = Math.Sqrt((secondColumnX - thirdColumnX)* (secondColumnX - thirdColumnX) + (secondColumnY - thirdColumnY)* (secondColumnY - thirdColumnY));
                        double perimeter = (side1 + side2 + side3) / 2;
                        double area = Math.Sqrt(perimeter * (perimeter - side1) * (perimeter - side2) * (perimeter - side3));
            return area;



        }
    }
}
