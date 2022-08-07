using System.Collections.Generic;
using Xunit;

namespace rangeChecker.Tests
{
    public class Tests
    {
        void TestRange(List<int> values, string expectedOutput)
        {
            string actualOutput = RangeChecker.GetContinuousRangesInCsv(values);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        void TestRegularValues()
        {
            TestRange(new List<int>() { 3, 3, 5, 4, 10, 11, 12 }, "3-5, 4\n10-12, 3\n");
            TestRange(new List<int>() { 3, 5, 4, 10, 14, 12, 3 }, "3-5, 4\n");
            TestRange(new List<int>() { 3, 7, 5, 10, 11, 12, 10 }, "10-12, 4\n");
        }

        [Fact]
        void TestContinuousValuesOnly()
        {
            TestRange(new List<int>() { 3, 4, 5, 6 }, "3-6, 4\n");
            TestRange(new List<int>() { 3, 4, 4, 5, 3, 6 }, "3-6, 6\n");
            TestRange(new List<int>() { 3, 3, 4, 5, 10, 11, 11, 12 }, "3-5, 4\n10-12, 4\n");
        }

        [Fact]
        void TestNonContinuousValues()
        {
            TestRange(new List<int>() { 3, 6 }, string.Empty);
            TestRange(new List<int>() { 3, 8, 5, 10, 24, 15 }, string.Empty);
        }

        [Fact]
        void TestNullValuesArray()
        {
            TestRange(null, string.Empty);
        }

        [Fact]
        void TestEmptyValues()
        {
            TestRange(new List<int>(), string.Empty);
        }
    }
}
