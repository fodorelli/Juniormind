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
            int red = RedMushrooms(2, 4);
            Assert.AreEqual(8, red);
        }
        int RedMushrooms(int whiteMushrooms, int x)
        {
            int redMushrooms = whiteMushrooms * x;
            return redMushrooms;
        }
    }
}
