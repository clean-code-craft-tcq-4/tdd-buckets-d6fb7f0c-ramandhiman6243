using System.Collections.Generic;

namespace Range
{
    public class RangeListOperations
    {
        public static List<RangeData> GetConsecutiveRangesFromSortedList(List<int> values)
        {
            List<RangeData> ranges = new List<RangeData>();

            int lastNumber = 0;
            RangeData currentRange = null;

            GetRangesByRecursion(0, ref values, ref currentRange, ranges, lastNumber);

            return ranges;
        }

        static void GetRangesByRecursion(int i, ref List<int> inputValues, ref RangeData currentRange, List<RangeData> ranges, int lastNumber)
        {
            if (i < inputValues.Count)
            {
                int currentValue = inputValues[i];
                GetRanges(i, ref currentRange, ranges, ref lastNumber, currentValue);
                GetRangesByRecursion(++i, ref inputValues, ref currentRange, ranges, lastNumber);
            }
        }

        private static void GetRanges(int i, ref RangeData currentRange, List<RangeData> ranges, ref int lastNumber, int currentValue)
        {
            if (i == 0)
            {
                NewRange(out currentRange, ranges, out lastNumber, currentValue);
            }
            else
            {
                AppendRange(ref currentRange, ranges, ref lastNumber, currentValue);
            }
        }

        private static void NewRange(out RangeData currentRange, List<RangeData> ranges, out int lastNumber, int currentValue)
        {
            currentRange = CreateNewRangeItem(ranges, currentValue);
            lastNumber = currentValue;
        }

        private static RangeData CreateNewRangeItem(List<RangeData> ranges, int currentValue)
        {
            RangeData currentRange = new RangeData();
            currentRange.AddNumber(currentValue);
            ranges.Add(currentRange);
            return currentRange;
        }

        private static void AppendRange(ref RangeData currentRange, List<RangeData> ranges, ref int lastNumber, int currentValue)
        {
            if (DoesNumberBelongInRange(currentValue, lastNumber))
            {
                currentRange.AddNumber(currentValue);
            }
            else
            {
                currentRange = CreateNewRangeItem(ranges, currentValue);
            }
            lastNumber = currentValue;
        }

        static bool DoesNumberBelongInRange(int currentNumber, int previousNumber)
        {
            return currentNumber == previousNumber || currentNumber == previousNumber + 1;
        }
    }
}
