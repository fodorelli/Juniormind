using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mushrooms
{
    [TestClass]
    public class mushrooms
    {
        [TestMethod]
        public void TestMethod1()
        {
           
            Assert.AreEqual(6, RedMushrooms(9, 2));
        }
        int RedMushrooms(int Total, int RedMultiplier)
        {
            int a = Total / (1 + RedMultiplier);
                         return a * RedMultiplier;
        }
    }
}
