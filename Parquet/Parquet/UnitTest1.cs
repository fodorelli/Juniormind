using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Parquet
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            double totalnoofParquet = noParquet(20, 6, 2, 1);
            Assert.AreEqual(69, totalnoofParquet);
        }
        double noParquet(int n, int m, int a, int b)
        { 
           return (double)(n/a)* (double)(m/b)*115/100; 
       }
}
}
