using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cube
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(192, GetCubeNumber(1));
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(442, GetCubeNumber(2));
        }
        int GetCubeNumber(int wantedNumber)
         { 
             int counter = 0; 
             for(int i = 0; i<1000; i++) 
             { 
                 if(Math.Pow(i, 3) % 1000 == 888) 
                 { 
                     counter++; 
                     if (counter == wantedNumber) 
                         return i; 
                 } 
             } 
             return 0; 
         } 

    }
}
