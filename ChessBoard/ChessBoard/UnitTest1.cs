
/// <summary>
/// Calculate how many squares can form a checkerboard size of 8 x 8 .
///We have the following options : size 64 square posibile 1x1 position (8 times as 8 - per line )
///2x2 49 (7 times each 7 - every 2 lines)
///3x3 36 (6 times each 6 - every 3 lines)
///4x4 25 ( 5 times 5 - every four lines)
///6x6 9 (3 times each 3 - every six lines)
///x7 4- ( 2 , times two for each 7 lines )
///8x8 1 ( Full chess board ) total 204 
/// </summary>

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
