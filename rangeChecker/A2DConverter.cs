using System;
using System.Collections.Generic;

namespace Range
{
    public class A2DConverter
    {
        private int bitCount;
        private int minCurrentLimit;
        private int maxCurrentLimit;

        private int minAnalogValue;
        private int maxAnalogValue;

        public A2DConverter(int bitCount, int minCurrentLimit, int maxCurrentLimit)
        {
            this.bitCount = bitCount;
            this.minCurrentLimit = minCurrentLimit;
            this.maxCurrentLimit = maxCurrentLimit;

            minAnalogValue = 0;
            maxAnalogValue = (int)Math.Pow(2, bitCount) - 2;
        }

        public A2DConversionOutput ConvertToDigital(List<int> inputValues)
        {
            var conversionOutput = new A2DConversionOutput();

            if (inputValues != null)
            {
                ConvertNonNullList(inputValues, conversionOutput);
            }

            return conversionOutput;
        }

        private void ConvertNonNullList(List<int> inputValues, A2DConversionOutput conversionOutput)
        {
            for (int i = 0; i < inputValues.Count; i++)
            {
                AppendValueToOutput(inputValues[i], conversionOutput);
            }
        }

        private void AppendValueToOutput(int inputValue, A2DConversionOutput conversionOutput)
        {
            if (IsValueInDefinedRange(inputValue))
            {
                int outputValue = ConvertToDigital(inputValue);
                conversionOutput.AppendOutputValue(outputValue);
            }
            else
            {
                conversionOutput.AppendErrorValue(inputValue);
            }

        }

        private bool IsValueInDefinedRange(int inputValue)
        {
            return IsValueInRange(inputValue, minAnalogValue, maxAnalogValue);
        }

        private bool IsValueInRange(int inputValue, int minLimit, int maxLimit)
        {
            return IsValueMoreThanOrEqual(inputValue, minLimit) && IsValueLessThanOrEqual(inputValue, maxLimit);
        }

        private bool IsValueLessThanOrEqual(int inputValue, int maxLimit)
        {
            if (inputValue <= maxLimit)
            {
                return true;
            }
            return false;
        }

        private bool IsValueMoreThanOrEqual(int inputValue, int minLimit)
        {
            if (inputValue >= minLimit)
            {
                return true;
            }
            return false;
        }

        private float GetTotalAnalogRange()
        {
            return GetAbsMinAnalogValue() + GetAbsMaxAnalogValue();
        }

        private float GetAbsMinAnalogValue()
        {
            return Math.Abs(minAnalogValue);
        }

        private float GetAbsMaxAnalogValue()
        {
            return Math.Abs(maxAnalogValue);
        }

        private float GetTotalCurrentRange()
        {
            return GetAbsMinCurrentValue() + GetAbsMaxCurrentValue();
        }

        private float GetAbsMinCurrentValue()
        {
            return Math.Abs(minCurrentLimit);
        }

        private float GetAbsMaxCurrentValue()
        {
            return Math.Abs(maxCurrentLimit);
        }

        private int ConvertToDigital(int inputValue)
        {
            float normalizedValue = inputValue / GetTotalAnalogRange();
            float rawFinalValue = GetTotalCurrentRange() * normalizedValue;
            rawFinalValue = rawFinalValue - GetAbsMinCurrentValue();
            double roundedFinalValue = Math.Round(rawFinalValue);
            return (int)roundedFinalValue;
        }
    }
}
