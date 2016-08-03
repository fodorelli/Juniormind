using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExcelColumns
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FindTheColumn()
        {
            Assert.AreEqual("A", CalculateColumn(1));
        }
        [TestMethod]
        public void FindTheColumn1()
        {
            Assert.AreEqual("AA", CalculateColumn(27));
        }
        [TestMethod]
        public void FindTheColumn2()
        {
            Assert.AreEqual("AB", CalculateColumn(28));
        }
        [TestMethod]
        public void FindTheColumn3()
        {
            Assert.AreEqual("AZ", CalculateColumn(52));
        }

        public string CalculateColumn(int numberInserted)
         { 
            int i = 0; 
            string output = string.Empty; 
              
             while(numberInserted>0) 
             { 
                 numberInserted--; 
 
 
                 output= TransformToChar(numberInserted % 26) + output; 
                 numberInserted /= 26; 
             } 
            return output; 
       
 
 
              
         } 
 
 
         private static char TransformToChar(int numberInserted)
         { 
             return ((char)('A' + numberInserted)); 
        } 

    }
}
