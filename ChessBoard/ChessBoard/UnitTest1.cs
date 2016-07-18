using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessBoard
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestChessBoard8x8()
        {
            Assert.AreEqual(204, CalculateTheSquaresOnAChessboard(8));
        }
        int CalculateTheSquaresOnAChessboard(int lenght)
          {  
 
           int noOfSquares = 0;  
           for (int i = 1; i <= lenght; i++)  
               noOfSquares += (i* i);  
           return noOfSquares;  
          }
}
}
