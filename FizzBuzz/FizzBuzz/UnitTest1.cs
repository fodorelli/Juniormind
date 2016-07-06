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
                        Assert.AreEqual("Buzz", FizzBuzz(10));
                    } 
         [TestMethod] 
         public void TestFizz()
         { 
             Assert.AreEqual("Fizz", FizzBuzz(12)); 
         } 
         [TestMethod] 
         public void TestFizzBuzz()
         { 
             Assert.AreEqual("FizzBuzz", FizzBuzz(30)); 
         }

string FizzBuzz(int Number)
         {


            return Number % 3 == 0 && Number % 5 == 0 ? "FizzBuzz" : Number % 3 == 0 ? "Fizz" : Number % 5 == 0 ? "Buzz" : Number.ToString();
            

         }
    }
}
