using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagrams
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNoOfAnagrams1()
        {
            Assert.AreEqual(1, CalculateNumberOfAnagrams("a"));
        }
        [TestMethod]
        public void TestNoOfAnagrams2()
        {
            Assert.AreEqual(6, CalculateNumberOfAnagrams("cdcd"));
        }
        [TestMethod]
        public void TestNoOfAnagrams3()
        {
            Assert.AreEqual(3, CalculateNumberOfAnagrams("ccd"));
        }
        [TestMethod]
        public void TestNoOfAnagrams4()
        {
            Assert.AreEqual(24, CalculateNumberOfAnagrams("abcd"));
        }

        int CalculateNumberOfAnagrams(string word)
         { 
             int factorial = 1; 
             for (int i = 'a'; i<='z'; i++) 
                 factorial *= Factorial(GetRepeatingLetter(i, word)); 
             return Factorial(word.Length)/factorial; 
         } 
 
 
         private int Factorial(int length)
         { 
             int result = 1; 
             for (int i = 2; i <= length; i++) 
                 result *= i; 
             return result; 
        } 
        int GetRepeatingLetter(int letterToCompare, string word)
         { 
            int counter = 0; 
            for (int i = 0; i<word.Length; i++) 
                if (letterToCompare == word[i]) 
                    counter++; 
            return counter; 
         } 

    }
}
