using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lunch
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(12, GetNumberOfDaysUntilTheNextLunchMeeting(4, 6));
        }
        int LunchMeeting(int a, int b)
         { 
             while (a != b) 
             { 
                 if (a > b) 
 
 
                    a -= b; 
 
 
                 else 
                     b -= a; 

 
             } 
             return a; 
         } 
 
 
        int GetNumberOfDaysUntilTheNextLunchMeeting(int hisDay, int myDay)
        { 

 
 
 
            return hisDay* myDay / LunchMeeting(hisDay, myDay);  
         } 

    }
}
