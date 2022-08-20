using System.Collections.Generic;

namespace Range
{
    public class RangeChecker
    {
        public static string GetContinuousRangesInCsv(List<int> values, string outputFormat)
        {
            if (values != null)
            {
                List<List<int>> ranges = GetConsecutiveRanges(values);
                string finalCsv = StringUtility.ConvertRangesToString(ranges, outputFormat);
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
