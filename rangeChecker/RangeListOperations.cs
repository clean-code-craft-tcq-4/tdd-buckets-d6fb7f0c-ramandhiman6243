using System.Collections.Generic;

namespace Range
{
    public class RangeListOperations
    {
        public static List<List<int>> GetConsecutiveRangesFromSortedList(List<int> values)
        {
            List<List<int>> ranges = new List<List<int>>();

            int lastNumber = 0;
            List<int> currentRange = null;

            GetRangesByRecursion(0, ref values, ref currentRange, ranges, lastNumber);

            return ranges;
        }

        static void GetRangesByRecursion(int i, ref List<int> inputValues, ref List<int> currentRange, List<List<int>> ranges, int lastNumber)
        {
            if (i < inputValues.Count)
            {
                int currentValue = inputValues[i];
                GetRanges(i, ref currentRange, ranges, ref lastNumber, currentValue);
                GetRangesByRecursion(++i, ref inputValues, ref currentRange, ranges, lastNumber);
            }
        }

        private static void GetRanges(int i, ref List<int> currentRange, List<List<int>> ranges, ref int lastNumber, int currentValue)
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

        private static void NewRange(out List<int> currentRange, List<List<int>> ranges, out int lastNumber, int currentValue)
        {
            currentRange = CreateNewRangeItem(ranges, currentValue);
            lastNumber = currentValue;
        }

        private static List<int> CreateNewRangeItem(List<List<int>> ranges, int currentValue)
        {
            List<int> currentRange = new List<int>() { currentValue };
            ranges.Add(currentRange);
            return currentRange;
        }

        private static void AppendRange(ref List<int> currentRange, List<List<int>> ranges, ref int lastNumber, int currentValue)
        {
            if (DoesNumberBelongInRange(currentValue, lastNumber))
            {
                currentRange.Add(currentValue);
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
