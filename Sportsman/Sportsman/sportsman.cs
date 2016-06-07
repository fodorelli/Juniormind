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
                        int repetitions = NumberOfRepetitions(5);
                        Assert.AreEqual(25, repetitions);
        }
        int NumberOfRepetitions(int numberpreparationrounds)
        {
            return numberpreparationrounds * numberpreparationrounds;
        }
    }
}
