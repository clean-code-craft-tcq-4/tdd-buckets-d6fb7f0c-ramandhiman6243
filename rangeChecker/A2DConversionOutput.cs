using System;
using System.Collections.Generic;

namespace Range
{
    public class A2DConversionOutput
    {
        private List<int> outputValues;
        private List<int> errorValues;

        public A2DConversionOutput()
        {
            outputValues = new List<int>();
            errorValues = new List<int>();
        }

        public void AppendOutputValue(int value)
        {
            outputValues.Add(value);
        }

        public void AppendErrorValue(int value)
        {
            errorValues.Add(value);
        }

        public List<int> GetOutputValues()
        {
            return outputValues;
        }

        public List<int> GetErrorValues()
        {
            return errorValues;
        }

        public List<int> GetAbsoluteOutputValues()
        {
            List<int> absoluteValues = new List<int>();
            foreach (var value in GetOutputValues())
            {
                absoluteValues.Add(Math.Abs(value));
            }
            return absoluteValues;
        }
    }
}
