using System.Collections.Generic;

namespace rangeChecker
{
    public class RangeChecker
    {
        public static string GetContinuousRangesInCsv(List<int> values)
        {
            if (values != null)
            {
                List<List<int>> ranges = GetConsecutiveRanges(values);
                string finalCsv = ConvertToString.ConvertRangesToString(ranges);
                return finalCsv;
            }
            return string.Empty;
        }

        static List<List<int>> GetConsecutiveRanges(List<int> values)
        {
            values.Sort();
            List<List<int>> ranges = RangeListOperations.GetConsecutiveRangesFromSortedList(values);
            return ranges;
        }

    }
}
