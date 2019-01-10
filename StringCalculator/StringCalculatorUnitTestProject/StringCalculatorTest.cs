using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculatorUnitTestProject
{
    [TestClass]
    public class StringCalculatorTest
    {
        private StringCalc _objStringCalcTest;

        [TestInitialize]
        public void SetUp()
        {
            _objStringCalcTest = new StringCalc();
        }

        [DataTestMethod]
        [DataRow("", 0)]
        [DataRow(null, 0)]
        [DataRow("0", 0)]
        public void Returns_0_When_0_Or_Null_Or_EmptyString(string numbers, int result)
        {
            int actual = Get_SumOfNumbers(numbers);

            Assert.AreEqual(result, actual);
        }

        [DataTestMethod]
        [DataRow("1", 1)]
        [DataRow("10,20", 30)]
        [DataRow("111,222,333", 666)]
        public void Returns_Sum_When_ValidNumbersIn_String(string numbers, int result)
        {
            int actual = Get_SumOfNumbers(numbers);

            Assert.AreEqual(result, actual);
        }

        [DataTestMethod]
        [DataRow("1,2,3,4,5,6", 21)]
        [DataRow("11,22,33,44,55,66", 231)]
        public void Returns_Sum_When_UnknownAmountOf_Numbers(string numbers, int result)
        {
            int actual = Get_SumOfNumbers(numbers);

            Assert.AreEqual(result, actual);
        }

        [DataTestMethod]
        [DataRow("\n10,20", 30)]
        [DataRow("11\n22,33", 66)]
        [DataRow("2,6\n8", 16)]
        public void Returns_Sum_When_NewLinePresentAnywhereIn_String(string numbers, int result)
        {
            int actual = Get_SumOfNumbers(numbers);

            Assert.AreEqual(result, actual);
        }

        [DataTestMethod]
        [DataRow("//;\n1;2;3", 6)]
        [DataRow("//;\n10;20;30", 60)]
        [DataRow("//$\n4$5$10", 19)]
        [DataRow("//$\n15$25$30", 70)]
        public void Returns_Sum_When_CustomDelimiterPrefixedIn_Numbers(string numbers, int result)
        {
            int actual = Get_SumOfNumbers(numbers);

            Assert.AreEqual(result, actual);
        }

        [DataTestMethod]
        [DataRow("//[;]\n1;2;3", 6)]
        [DataRow("//[;]\n10;20;30", 60)]
        [DataRow("//[$]\n11$22$33", 66)]
        [DataRow("//[$]\n15$30$60", 105)]
        public void Returns_Sum_When_CustomDelimiterInBracketsIn_Numbers(string numbers, int result)
        {
            int actual = Get_SumOfNumbers(numbers);

            Assert.AreEqual(result, actual);
        }

        [DataTestMethod]
        [DataRow("-1", -1)]
        [DataRow("10,-20", -10)]
        [DataRow("1,2,-3,4,-5,6", 1)]
        [DataRow("11\n-22,35", 2)]
        [DataRow("//;\n10;-20;-30", -40)]
        [DataRow("//[;]\n10;-20;30", 20)]
        public void Throws_Exception_When_NegativeNumberIn_String(string numbers, int result)
        {
            try
            {
                int actual = Get_SumOfNumbers(numbers);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private int Get_SumOfNumbers(string numbers)
        {
            var calculatedResult = _objStringCalcTest.Add(numbers);

            return calculatedResult;
        }
    }
}

