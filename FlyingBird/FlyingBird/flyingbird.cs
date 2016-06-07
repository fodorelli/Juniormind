using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlyingBird
{
    [TestClass]
    public class flyingbird
    {
        [TestMethod]
        public void TestMethod1()
        {
            int distance = CalculateFlyingDistance(60, 240);
            Assert.AreEqual(120, distance);
        }
        int CalculateFlyingDistance(int trainSpeed, int trainDistance)
        {

                        int birdFlyingTime = trainDistance / (trainSpeed * 2) - ((trainDistance / 4) / trainSpeed);
                         return trainSpeed * 2 * birdFlyingTime;
        }
    }
}
