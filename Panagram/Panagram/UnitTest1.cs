using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panagram
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckIfPanagram1()
        {
            Assert.AreEqual(true, FindIfPanagram("The quick brown fox jumps over the lazy dog"));
        }
        [TestMethod]
        public void CheckIfPanagram2()
        {
            Assert.AreEqual(false, FindIfPanagram("dog"));
        }
        [TestMethod]
        public void CheckIfPanagram3()
        {
            Assert.AreEqual(true, FindIfPanagram("abcdefghijklmnopqrstuvwxyz"));
        }

        public bool FindIfPanagram(string sentence)
        {
            string lowerCaseTransform = sentence.ToLower();
            if (CheckIfPanagram(lowerCaseTransform))
                return true;
            else return false;
        }


        public bool CheckIfPanagram(string panagram)
        {

            for (int j = 'a'; j < 'z'; j++)


            {
                int count = 0;


                for (int i = 0; i < panagram.Length; i++)
                {
                    if (panagram[i] == j) count++;
                }
                if (count == 0) return false;

            }

            return true;


        }
    }
}
   
    

        
    
    


