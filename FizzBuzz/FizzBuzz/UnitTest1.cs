using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod] 
         public void TestBuzz()
        {
                        Assert.AreEqual("BUZZ", FizzBuzz(10));
                    } 
         [TestMethod] 
         public void TestFizz()
         { 
             Assert.AreEqual("FIZZ", FizzBuzz(12)); 
         } 
         [TestMethod] 
         public void TestFizzBuzz()
         { 
             Assert.AreEqual("FIZZBUZZ", FizzBuzz(30)); 
         }

string FizzBuzz(int Number)
         { 
 
 
            if (Number % 5 == 0 && Number % 3 == 0) 
                return "FIZZBUZZ"; 
 
 
            if (Number % 5 == 0) 
                return "BUZZ"; 
 
 
             if (Number % 3 == 0) 
                return "FIZZ"; 

 
            return Number.ToString(); 
         }
}
}
