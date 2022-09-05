using System.Collections.Generic;
using Xunit;

namespace Range.Tests
{
    public class A2DConverterTests
    {
        private static A2DConverter Get12BitConverter()
        {
            A2DConverter converter = new A2DConverter(12, 0, 10);
            return converter;
        }

        private static A2DConverter Get10BitConverter()
        {
            A2DConverter converter = new A2DConverter(10, -15, 15);
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
            private void TestValidValuesConversion12Bit()
            {
                TestConversion(Get12BitConverter(), new List<int> { 0, 1 }, new List<int> { 0, 0 }, new List<int>());
                TestConversion(Get12BitConverter(), new List<int> { 4093, 4094 }, new List<int> { 10, 10 }, new List<int>());
                TestConversion(Get12BitConverter(), new List<int> { 0, 1, 1146, 4093, 4094 }, new List<int> { 0, 0, 3, 10, 10 }, new List<int>());
            }

            [Fact]
            private void TestErrorValuesConversion12Bit()
            {
                TestConversion(Get12BitConverter(), new List<int> { 4095, 5012 }, new List<int>(), new List<int> { 4095, 5012 });
                TestConversion(Get12BitConverter(), new List<int> { -1 }, new List<int>(), new List<int> { -1 });
            }

            [Fact]
            private void TestMixedValuesConversion12Bit()
            {
                TestConversion(Get12BitConverter(), new List<int> { 4093, 4094, 4095 }, new List<int> { 10, 10 }, new List<int> { 4095 });
                TestConversion(Get12BitConverter(), new List<int> { -1, 0, 1, 1146, 4093, 4094, 4095 }, new List<int> { 0, 0, 3, 10, 10 }, new List<int> { -1, 4095 });
            }

            [Fact]
            private void TestEmptyValuesConversion12Bit()
            {
                TestConversion(Get12BitConverter(), new List<int>(), new List<int>(), new List<int>());
            }

            [Fact]
            private void TestNullValuesConversion12Bit()
            {
                TestConversion(Get12BitConverter(), null, new List<int>(), new List<int>());
            }
        }

        public class TestsFor10BitConverter
        {
            [Fact]
            private void TestValidValuesConversion10Bit()
            {
                TestConversion(Get10BitConverter(), new List<int> { 0, 1 }, new List<int> { -15, -15 }, new List<int>());
                TestConversion(Get10BitConverter(), new List<int> { 1021, 1022 }, new List<int> { 15, 15 }, new List<int>());
                TestConversion(Get10BitConverter(), new List<int> { 0, 1, 511, 1021, 1022 }, new List<int> { -15, -15, 0, 15, 15 }, new List<int>());
            }

            [Fact]
            private void TestErrorValuesConversion10Bit()
            {
                TestConversion(Get10BitConverter(), new List<int> { 1023, 1024 }, new List<int>(), new List<int> { 1023, 1024 });
                TestConversion(Get10BitConverter(), new List<int> { -1 }, new List<int>(), new List<int> { -1 });
            }

            [Fact]
            private void TestMixedValuesConversion10Bit()
            {
                TestConversion(Get10BitConverter(), new List<int> { 1021, 1022, 1023 }, new List<int> { 15, 15 }, new List<int> { 1023 });
                TestConversion(Get10BitConverter(), new List<int> { -1, 0, 1, 511, 1021, 1022, 1023 }, new List<int> { -15, -15, 0, 15, 15 }, new List<int> { -1, 1023 });
            }

            [Fact]
            private void TestEmptyValuesConversion10Bit()
            {
                TestConversion(Get10BitConverter(), new List<int>(), new List<int>(), new List<int>());
            }

            [Fact]
            private void TestNullValuesConversion10Bit()
            {
                TestConversion(Get10BitConverter(), null, new List<int>(), new List<int>());
            }
        }
    }
}
