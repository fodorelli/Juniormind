using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace capre
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        decimal Calculatecapre(int z, int x, int y, decimal k, int q, int w)
        {
            return k=(z / x / y)*q*w;
           
            //x=nr de zile; y=nr de capre;z=nr kg de fan;
            //q=nr de capre din problema; w=nr de zile ;k=nr total de kg de fan

        }
    }
}
