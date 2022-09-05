using System.Collections.Generic;
using Xunit;

namespace Range.Tests
{
    public class A2DRangeFormatterTests
    {
        private static A2DRangeFormatter Get12BitFormatter()
        {
            A2DConverter converter = new A2DConverter(12, 0, 10);
            return GetA2DRangeFormatter(converter);
        }

        private static A2DRangeFormatter Get10BitFormatter()
        {
            A2DConverter converter = new A2DConverter(10, -15, 15);
            return GetA2DRangeFormatter(converter);
        }

        private static A2DRangeFormatter GetA2DRangeFormatter(A2DConverter converter)
        {
            A2DRangeFormatter a2DRangeFormatter = new A2DRangeFormatter(converter);
            return a2DRangeFormatter;
        }

        private static void TestFormattedOutput(A2DRangeFormatter formatter, List<int> inputValues, string expectedCsv)
        {
            string outputFormat = "{0}-{1}, {2}\n";
            string actualOutput = formatter.Format(inputValues, outputFormat);
            Assert.Equal(expectedCsv, actualOutput);
        }

        public class TestsFor12BitConverter
        {
            [Fact]
            private void TestValidValuesConversion12Bit()
            {
                TestFormattedOutput(Get12BitFormatter(), new List<int> { 0, 220, 780, 1146 }, "0-3, 4\n");
                TestFormattedOutput(Get12BitFormatter(), new List<int> { 1146, 3750, 3800, 4094 }, "9-10, 3\n");
                TestFormattedOutput(Get12BitFormatter(), new List<int> { 3750, 3800, 4094, 4095 }, "9-10, 3\n");
                TestFormattedOutput(Get12BitFormatter(), new List<int> { -1, 0, 1146, 3500, 4093, 4095 }, "9-10, 2\n");
            }

            [Fact]
            private void TestEmptyValuesConversion12Bit()
            {
                TestFormattedOutput(Get12BitFormatter(), new List<int>(), string.Empty);
            }

            [Fact]
            private void TestNullValuesConversion12Bit()
            {
                TestFormattedOutput(Get12BitFormatter(), null, string.Empty);
            }
        }

        public class TestsFor10BitConverter
        {
            [Fact]
            private void TestValidValuesConversion10Bit()
            {
                TestFormattedOutput(Get10BitFormatter(), new List<int> { 501, 549, 588, 621 }, "0-3, 4\n");
                TestFormattedOutput(Get10BitFormatter(), new List<int> { 1025, 921, 960, 940, 990, 1011, 1034 }, "12-15, 5\n");
                TestFormattedOutput(Get10BitFormatter(), new List<int> { -10, -1, 921, 60, 940, 25, 1011, 1030 }, "12-15, 5\n");
                TestFormattedOutput(Get10BitFormatter(), new List<int> { 501, 549, 588, 621, 921, 60, 940, 25, 1011 }, "0-3, 4\n12-15, 5\n");
            }

            [Fact]
            private void TestEmptyValuesConversion10Bit()
            {
                TestFormattedOutput(Get10BitFormatter(), new List<int>(), string.Empty);
            }

            [Fact]
            private void TestNullValuesConversion10Bit()
            {
                TestFormattedOutput(Get10BitFormatter(), null, string.Empty);
            }
        }
    }
}