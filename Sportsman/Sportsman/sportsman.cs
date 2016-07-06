using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sportsman
{
    [TestClass]
    public class sportsman
    {
        [TestMethod]
        public void TestMethod1()
        {
                        
                        Assert.AreEqual(25, NumberOfRepetitions(5));
        }
        int NumberOfRepetitions(int NoofPreparationRounds)
        {
            return NoofPreparationRounds * NoofPreparationRounds;
        }
    }
}
