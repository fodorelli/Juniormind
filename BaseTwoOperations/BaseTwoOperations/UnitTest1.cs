﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Ai un număr zecimal transformă-l în baza doi, reprezentat ca și un array de byte (byte[]).
Pentru un număr transformat implementează operațiile:
    NOT, AND, NOT, OR, XOR
    RightHandShift și LeftHandShift (shiftare de biți la dreapta și la stânga)
    LessThan
    Adunare și scădere
    Înmulțire și împărțire
    Folosește-te de LessThan pentru a implementa și alți operatori de comparare (GreaterThan, Equal, NotEqual)
Doar pentru numere pozitive.
Poți generaliza transformarea și operațiile de la 3-6 pentru o bază aleatoare (baza fiind între 2 și 255)?*/
namespace BaseTwoOperations
{
    [TestClass]
    public class BaseTwoOperationsTests
    {
        [TestMethod]
        public void ZeroToBinary()
        {
            CollectionAssert.AreEqual(new byte[] { 0 }, ToBinary(0));
        }
        [TestMethod]
        public void TestForTwelve()
        {
            byte[] binaryArray = { 1, 0, 1, 1, 1 };
            CollectionAssert.AreEqual(binaryArray, ToBinary(23));
        }
        [TestMethod]
        public void NumberOfBinaryDigits()
        {
            Assert.AreEqual(5, GetNumberOfBinaryDigits(23));
        }
        [TestMethod]
        public void TestNOTOperator()
        {
            byte[] binaryArray = { 0, 1, 1 };
            CollectionAssert.AreEqual(binaryArray, Not(ToBinary(4)));
        }
        [TestMethod]
        public void ElementFromGivenPosition()
        {
            byte[] array = { 0, 0, 1 };
            Assert.AreEqual(1, GetAt(array, 0));
        }

        [TestMethod]
        public void PositionNotInTheArray()
        {
            byte[] array = { 1, 1, 1 };
            Assert.AreEqual(0, GetAt(array, 4));
        }
        [TestMethod]
        public void NumberOfZeroes()
        {
            Assert.AreEqual(1, CountZeroes(ToBinary(23)));
        }
        [TestMethod]
        public void OnlyZeroes()
        {
            Assert.AreEqual(1, CountZeroes(ToBinary(0)));
        }

        [TestMethod]
        public void TrailingZero()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1 }, RemoveTrailingZeroes(new byte[] { 1, 1, 0 }));
        }
        [TestMethod]
        public void ANDOnlyZeroes()
        {
            CollectionAssert.AreEqual(new byte[] { 0 }, LogicOperations(ToBinary(4), ToBinary(3), "AND"));
        }

        [TestMethod]
        public void ANDForEqualLengthBinaryNumbers()
        {
            CollectionAssert.AreEqual(ToBinary(5 & 4), LogicOperations(ToBinary(5), ToBinary(4), "AND"));
        }

        [TestMethod]
        public void ANDForDifferentLengthBinaryNumbers()
        {
            CollectionAssert.AreEqual(ToBinary(5 & 9), LogicOperations(ToBinary(5), ToBinary(9), "AND"));
        }

        [TestMethod]
        public void ORForDifferentLegth()
        {
            CollectionAssert.AreEqual(ToBinary(5 | 9), LogicOperations(ToBinary(5), ToBinary(9), "OR"));
        }

        [TestMethod]
        public void ORForEqualLength()
        {
            CollectionAssert.AreEqual(ToBinary(5 | 4), LogicOperations(ToBinary(5), ToBinary(4), "OR"));
        }

        [TestMethod]
        public void XORForEqualLength()
        {
            CollectionAssert.AreEqual(ToBinary(5 ^ 4), LogicOperations(ToBinary(5), ToBinary(4), "XOR"));
        }

        [TestMethod]
        public void XORForDifferentLegth()
        {
            CollectionAssert.AreEqual(ToBinary(5 ^ 9), LogicOperations(ToBinary(5), ToBinary(9), "XOR"));
        }

        [TestMethod]
        public void And()
        {
            Assert.AreEqual(0, And(0, 1));
        }

        [TestMethod]
        public void Or()
        {
            Assert.AreEqual(1, Or(1, 0));
        }

        [TestMethod]
        public void Xor()
        {
            Assert.AreEqual(0, Xor(1, 1));
        }

        [TestMethod]
        public void LogicOperationSelection()
        {
            Assert.AreEqual(0, SelectLogicOperation(1, 1, "XOR"));
        }

        [TestMethod]
        public void RightShift()
        {
            CollectionAssert.AreEqual(ToBinary(5 >> 3), RightHandShift(ToBinary(5), 3));
        }

        [TestMethod]
        public void PositionsBiggerThanLength()
        {
            CollectionAssert.AreEqual(ToBinary(3 >> 5), RightHandShift(ToBinary(3), 5));
        }

        [TestMethod]
        public void LeftShift()
        {
            CollectionAssert.AreEqual(ToBinary(5 << 2), LeftHandShift(ToBinary(5), 2));
        }

        [TestMethod]
        public void LeftShiftForZero()
        {
            CollectionAssert.AreEqual(ToBinary(0 << 5), LeftHandShift(ToBinary(0), 5));
        }
        [TestMethod]
        public void LessThanEqualLengths()
        {
            Assert.AreEqual(true, LessThan(ToBinary(4), ToBinary(5)));
        }
        [TestMethod]
        public void GreaterThanCheck()
        {
            Assert.AreEqual(true, GreaterThan(ToBinary(5), ToBinary(4)));
        }

        [TestMethod]
        public void EqualOperator()
        {
            Assert.AreEqual(true, Equal(ToBinary(5), ToBinary(5)));
        }
        [TestMethod]
        public void NotEqualOpeator()
        {
            Assert.AreEqual(true, NotEqual(ToBinary(5), ToBinary(6)));
        }

        [TestMethod]
        public void SumWithoutExtraBit()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 1 }, Sum(ToBinary(3), ToBinary(4), 2));
        }

        [TestMethod]
        public void SumWithExtraBitNeeded()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 0, 0 }, Sum(ToBinary(3), ToBinary(5), 2));
        }

        [TestMethod]
        public void DifferenceWithoutZeroInFront()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 0 }, Difference(ToBinary(7), ToBinary(1), 2));
        }

        [TestMethod]
        public void DifferenceBetweenSixAndThree()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1 }, Difference(ToBinary(6), ToBinary(3), 2));
        }

        [TestMethod]
        public void DifferenceWithMultipleZeroesInFront()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 1, 0, 1 }, Difference(ToBinary(142), ToBinary(113), 2));
        }

        [TestMethod]
        public void MultplicationOfSevenWithTwo()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 1, 0 }, Multiplication(ToBinary(7), ToBinary(2), 2));
        }

        [TestMethod]
        public void MultiplicationOfSevenWithThree()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 1, 0, 1 }, Multiplication(ToBinary(7), ToBinary(3), 2));
        }

        [TestMethod]
        public void DivisionWithOne()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 1 }, Division(ToBinary(7), ToBinary(1), 2));
        }

        [TestMethod]
        public void DivisionSevenWithThee()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0 }, Division(ToBinary(7), ToBinary(3), 2));
        }

        [TestMethod]
        public void DivisionWihtZero()
        {
            CollectionAssert.AreEqual(new byte[] { 0 }, Division(ToBinary(7), ToBinary(0), 2));
        }

        [TestMethod]
        public void ConversionToBaseThree()
        {
            CollectionAssert.AreEqual(new byte[] { 2, 1 }, ConvertToAnyBase(7, 3));
        }

        [TestMethod]
        public void ConversionToBaseSixteen()
        {
            CollectionAssert.AreEqual(new byte[] { 4, 0 }, ConvertToAnyBase(64, 16));
        }

        [TestMethod]
        public void ConversionInABiggerBase()
        {
            CollectionAssert.AreEqual(new byte[] { 12 }, ConvertToAnyBase(12, 16));
        }

        [TestMethod]
        public void LessThanForBaseEight()
        {
            Assert.AreEqual(true, LessThan(ConvertToAnyBase(16, 8), ConvertToAnyBase(23, 8)));
        }

        [TestMethod]
        public void SumForOtherBases()
        {
            CollectionAssert.AreEqual(new byte[] { 4, 7 }, Sum(ConvertToAnyBase(16, 8), ConvertToAnyBase(23, 8), 8));
        }

        [TestMethod]
        public void DifferenceForOtherBases()
        {
            CollectionAssert.AreEqual(new byte[] { 2 }, Difference(ConvertToAnyBase(20, 16), ConvertToAnyBase(18, 16), 16));
        }

        [TestMethod]
        public void MultiplicationForOtherBases()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 6, 8 }, Multiplication(ConvertToAnyBase(20, 16), ConvertToAnyBase(18, 16), 16));
        }

        [TestMethod]
        public void DivisionForOtherBases()
        {
            CollectionAssert.AreEqual(new byte[] { 1 }, Division(ConvertToAnyBase(20, 16), ConvertToAnyBase(18, 16), 16));
        }

        [TestMethod]
        public void Factorial()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 0, 0, 0 }, ComputeFactorial(ConvertToAnyBase(4, 2), 2));
        }

        [TestMethod]
        public void FiveFactorial()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 1, 1, 0, 0, 0 }, ComputeFactorial(ConvertToAnyBase(5, 2), 2));
        }

        [TestMethod]
        public void DivisionOfFactorials()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 0, 0 }, Division(ComputeFactorial(ConvertToAnyBase(12, 2), 2), ComputeFactorial(ConvertToAnyBase(11, 2), 2), 2));
        }

        [TestMethod]
        public void DivisionOfFactorialsFortyNine()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 0, 0, 0, 1 }, Division(ComputeFactorial(ConvertToAnyBase(49, 2), 2), ComputeFactorial(ConvertToAnyBase(48, 2), 2), 2));
        }



        byte[] ToBinary(int number)
        {
            if (number == 0)
                return new byte[] { 0 };
            byte[] result = new byte[GetNumberOfBinaryDigits(number)];
            for (int i = result.Length - 1; i >= 0; i--)
            {
                result[i] = (byte)(number % 2);
                number = number / 2;
            }
            return result;
        }

        private static int GetNumberOfBinaryDigits(int number)
        {
            int length = 0;
            while (number > 0)
            {
                number /= 2;
                length++;
            }
            return length;
        }

        byte[] ConvertToAnyBase(int number, byte conversionBase)
        {
            if (number == 0)
                return new byte[] { 0 };
            byte[] result = new byte[GetNumberOfDigits(number, conversionBase)];
            for (int i = result.Length - 1; i >= 0; i--)
            {
                result[i] = (byte)(number % conversionBase);
                number = number / conversionBase;
            }
            return result;
        }

        private static int GetNumberOfDigits(int number, byte conversionBase)
        {
            int length = 0;
            while (number > 0)
            {
                number /= conversionBase;
                length++;
            }
            return length;
        }

        byte[] Not(byte[] binaryArray)
        {
            for (int i = 0; i < binaryArray.Length; i++)
            {
                binaryArray[i] = (byte)(binaryArray[i] == 0 ? 1 : 0);
            }
            return binaryArray;
        }

        byte[] LogicOperations(byte[] first, byte[] second, string operation)
        {
            byte[] resultedNumber = new byte[Math.Max(first.Length, second.Length)];
            byte firstBit = 0;
            byte secondBit = 0;
            for (int i = Math.Max(first.Length, second.Length) - 1; i >= 0; i--)
            {
                firstBit = GetAt(first, i);
                secondBit = GetAt(second, i);
                resultedNumber[i] = SelectLogicOperation(firstBit, secondBit, operation);
            }
            return RemoveTrailingZeroes(resultedNumber);
        }

        byte SelectLogicOperation(byte firstBit, byte secondBit, string operation)
        {
            switch (operation)
            {
                case "AND":
                    return And(firstBit, secondBit);
                case "OR":
                    return Or(firstBit, secondBit);
                case "XOR":
                    return Xor(firstBit, secondBit);
            }
            return 0;
        }

        byte And(byte firstBit, byte secondBit)
        {
            if (firstBit == 1 && secondBit == 1)
                return 1;
            return 0;
        }

        byte Or(byte firstBit, byte secondBit)
        {
            if (firstBit == 1 || secondBit == 1)
                return 1;
            return 0;
        }

        byte Xor(byte firstBit, byte secondBit)
        {
            if (firstBit != secondBit)
                return 1;
            return 0;
        }

        byte GetAt(byte[] binaryArray, int position)
        {
            if (position >= 0 && position < binaryArray.Length)
                return binaryArray[binaryArray.Length - position - 1];
            return 0;
        }

        private byte[] RemoveTrailingZeroes(byte[] number)
        {
            if (CountZeroes(number) == number.Length)
                return new byte[] { 0 };
            Array.Resize(ref number, number.Length - CountZeroes(number));
            Array.Reverse(number);
            return number;
        }

        int CountZeroes(byte[] number)
        {
            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (number[i] != 0)
                    return number.Length - i - 1;
            }
            return number.Length;
        }

        byte[] RightHandShift(byte[] number, int numberOfPositions)
        {
            if (numberOfPositions >= number.Length)
                return new byte[] { 0 };
            Array.Resize(ref number, number.Length - numberOfPositions);
            return number;
        }

        byte[] LeftHandShift(byte[] number, int numberOfPositions)
        {
            if (number.Length == 1 && number[0] == 0)
                return new byte[] { 0 };
            Array.Resize(ref number, number.Length + numberOfPositions);
            return number;
        }

        bool LessThan(byte[] first, byte[] second)
        {
            for (int i = Math.Max(first.Length, second.Length) - 1; i >= 0; i--)
            {
                if (GetAt(first, i) != GetAt(second, i))
                    return GetAt(first, i) < GetAt(second, i);
            }
            return false;
        }

        bool GreaterThan(byte[] first, byte[] second)
        {
            if (!LessThan(first, second) && !Equal(first, second))
                return true;
            return false;
        }

        bool Equal(byte[] first, byte[] second)
        {
            if (first.Length == second.Length && CountZeroes(first) == CountZeroes(second))
                return true;
            return false;
        }

        bool NotEqual(byte[] first, byte[] second)
        {
            if (!Equal(first, second))
                return true;
            return false;
        }

        byte[] Sum(byte[] first, byte[] second, byte baseValue)
        {
            var result = new byte[Math.Max(first.Length, second.Length)];
            int transport = 0;
            for (int i = 0; i < result.Length; i++)
            {
                var sum = GetAt(first, i) + GetAt(second, i) + transport;
                result[i] = (byte)(sum % baseValue);
                transport = sum / baseValue;
            }

            result = PutExtraBit(result, transport);
            Array.Reverse(result);
            return result;
        }

        private static byte[] PutExtraBit(byte[] result, int transport)
        {
            if (transport == 0)
                return result;
            Array.Resize(ref result, result.Length + 1);
            result[result.Length - 1] = (byte)transport;
            return result;
        }

        byte[] Difference(byte[] first, byte[] second, byte baseValue)
        {

            byte[] result = new byte[Math.Max(first.Length, second.Length)];
            int transport = 0;
            for (int i = 0; i < result.Length; i++)
            {
                var difference = baseValue + GetAt(first, i) - GetAt(second, i) - transport;
                result[i] = (byte)(difference % baseValue);
                transport = (difference < baseValue ? 1 : 0);
            }
            return RemoveTrailingZeroes(result);
        }

        byte[] Multiplication(byte[] first, byte[] second, byte baseValue)
        {
            byte[] result = new byte[Math.Max(first.Length, second.Length)];
            while (NotEqual(second, new byte[] { 0 }))
            {
                result = Sum(result, first, baseValue);
                second = Difference(second, new byte[] { 1 }, baseValue);
            }
            return result;
        }

        byte[] Division(byte[] first, byte[] second, byte baseValue)
        {
            if (second.Length == 1 && second[0] == 0)
                return new byte[] { 0 };
            byte[] result = new byte[Math.Min(first.Length, second.Length)];
            int length = 0;
            while (GreaterThan(first, second) || Equal(first, second))
            {
                first = Difference(first, second, baseValue);
                result = Sum(result, new byte[] { 1 }, baseValue);
                length++;
            }

            if (length < Math.Max(first.Length, second.Length))
            {
                Array.Reverse(result);
                return RemoveTrailingZeroes(result);
            }
            return result;
        }

        byte[] ComputeFactorial(byte[] number, byte baseValue)
        {
            byte[] factorial = new byte[] { 1 };
            for (byte[] i = new byte[] { 1, 0 }; LessThan(i, number) || Equal(i, number); i = Sum(i, new byte[] { 1 }, baseValue))
                factorial = Multiplication(factorial, i, baseValue);
            return factorial;
        }
    }
}
