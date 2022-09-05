using System.Collections.Generic;

namespace Range
{
    public class A2DRangeFormatter
    {
        private A2DConverter converter;

        public A2DRangeFormatter(A2DConverter converter)
        {
            this.converter = converter;
        }

        private A2DConversionOutput ConvertToDigital(List<int> inputValues)
        {
            A2DConversionOutput conversionOutput = converter.ConvertToDigital(inputValues);
            return conversionOutput;
        }

        private string ConversionOutputToCsv(A2DConversionOutput conversionOutput, string format)
        {
            string formattedOutput = RangeChecker.GetContinuousRangesInCsv(conversionOutput.GetAbsoluteOutputValues(), format);
            return formattedOutput;
        }

        public string Format(List<int> inputValues, string outputFormat)
        {
            A2DConversionOutput conversionOutput = ConvertToDigital(inputValues);
            string formattedOutput = ConversionOutputToCsv(conversionOutput, outputFormat);
            return formattedOutput;
        }
    }
}