using System.Collections.Generic;
using Xunit;

namespace Range.Tests
{
    public class A2DConverterTests
    {
        private const int ErrorValue12Bit = -1;
        private const int ErrorValue10Bit = -16;

        private static A2DConverter Get12BitConverter()
        {
            A2DConverter converter = new A2DConverter(12, 0, 10, ErrorValue12Bit);
            return converter;
        }

        private static A2DConverter Get10BitConverter()
        {
            A2DConverter converter = new A2DConverter(10, -15, 15, ErrorValue10Bit);
            return converter;
        }

        private static void TestConversion(A2DConverter converter, List<int> inputValues, List<int> expectedOutputValues, List<int> expectedErrorValues)
        {
            A2DConversionOutput output = converter.ConvertToDigital(inputValues);

            Assert.Equal(output.GetOutputValues(), expectedOutputValues);
            Assert.Equal(output.GetErrorValues(), expectedErrorValues);
        }

        public class TestsFor12BitConverter
        {
            [Fact]
            private void TestValidValuesConversion()
            {
                TestConversion(Get12BitConverter(), new List<int> { 0, 1 }, new List<int> { 0, 0 }, new List<int>());
                TestConversion(Get12BitConverter(), new List<int> { 4093, 4094 }, new List<int> { 10, 10 }, new List<int>());
                TestConversion(Get12BitConverter(), new List<int> { 0, 1, 1146, 4093, 4094 }, new List<int> { 0, 0, 3, 10, 10 }, new List<int>());
            }

            [Fact]
            private void TestErrorValuesConversion()
            {
                TestConversion(Get12BitConverter(), new List<int> { 4095, 5012 }, new List<int> { ErrorValue12Bit, ErrorValue12Bit }, new List<int> { 4095, 5012 });
                TestConversion(Get12BitConverter(), new List<int> { -1 }, new List<int> { ErrorValue12Bit }, new List<int> { -1 });
            }

            [Fact]
            private void TestMixedValuesConversion()
            {
                TestConversion(Get12BitConverter(), new List<int> { 4093, 4094, 4095 }, new List<int> { 10, 10, ErrorValue12Bit }, new List<int> { 4095 });
                TestConversion(Get12BitConverter(), new List<int> { -1, 0, 1, 1146, 4093, 4094, 4095 }, new List<int> { ErrorValue12Bit, 0, 0, 3, 10, 10, ErrorValue12Bit }, new List<int> { -1, 4095 });
            }

            [Fact]
            private void TestEmptyValuesConversion()
            {
                TestConversion(Get12BitConverter(), new List<int>(), new List<int>(), new List<int>());
            }

            [Fact]
            private void TestNullValuesConversion()
            {
                TestConversion(Get12BitConverter(), null, new List<int>(), new List<int>());
            }
        }

        public class TestsFor10BitConverter
        {
            [Fact]
            private void TestValidValuesConversion()
            {
                TestConversion(Get10BitConverter(), new List<int> { 0, 1 }, new List<int> { -15, -15 }, new List<int>());
                TestConversion(Get10BitConverter(), new List<int> { 1021, 1022 }, new List<int> { 15, 15 }, new List<int>());
                TestConversion(Get10BitConverter(), new List<int> { 0, 1, 511, 1021, 1022 }, new List<int> { -15, -15, 0, 15, 15 }, new List<int>());
            }

            [Fact]
            private void TestErrorValuesConversion()
            {
                TestConversion(Get10BitConverter(), new List<int> { 1023, 1024 }, new List<int> { ErrorValue10Bit, ErrorValue10Bit }, new List<int> { 1023, 1024 });
                TestConversion(Get10BitConverter(), new List<int> { -1 }, new List<int> { ErrorValue10Bit }, new List<int> { -1 });
            }

            [Fact]
            private void TestMixedValuesConversion()
            {
                TestConversion(Get10BitConverter(), new List<int> { 1021, 1022, 1023 }, new List<int> { 15, 15, ErrorValue10Bit }, new List<int> { 1023 });
                TestConversion(Get10BitConverter(), new List<int> { -1, 0, 1, 511, 1021, 1022, 1023 }, new List<int> { ErrorValue10Bit, -15, -15, 0, 15, 15, ErrorValue10Bit }, new List<int> { -1, 1023 });
            }

            [Fact]
            private void TestEmptyValuesConversion()
            {
                TestConversion(Get10BitConverter(), new List<int>(), new List<int>(), new List<int>());
            }

            [Fact]
            private void TestNullValuesConversion()
            {
                TestConversion(Get10BitConverter(), null, new List<int>(), new List<int>());
            }
        }
    }
}
