using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RomanNumbers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Convert21()
        {
            Assert.AreEqual("XXI", convertToRomanNumbers(21));
        }
        public void Convert525()
        {
            Assert.AreEqual("DXXV", convertToRomanNumbers(525));
        }
        string convertToRomanNumbers(int number)
        { 
             string[] romanUnitsNumbers = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" }; 
             string[] romanTensNumbers = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" }; 
            string[] romanHundredsNumbers = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "DC" }; 
             string hundreds = romanHundredsNumbers[number / 100]; 
             string tens = romanTensNumbers[number % 100 / 10]; 
             string units = romanUnitsNumbers[number % 10]; 

 
             return hundreds + tens + units; 
             
          }
}
}
