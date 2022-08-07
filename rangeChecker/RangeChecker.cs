using System.Collections.Generic;

namespace rangeChecker
{
    public class RangeChecker
    {
        const string outputFormat = "{0}-{1}, {2}\n";
        
        static void Main() { }

        public static string GetContinuousRangesInCsv(List<int> values)
        {
            if (values != null)
            {
                List<List<int>> ranges = GetConsecutiveRanges(values);
                string finalCsv = ConvertRangesToString(ranges);
                return finalCsv;
            }
            return string.Empty;
        }

        static List<List<int>> GetConsecutiveRanges(List<int> values)
        {
            values.Sort();
            List<List<int>> ranges = GetConsecutiveRangesFromSortedList(values);
            return ranges;
        }

        static List<List<int>> GetConsecutiveRangesFromSortedList(List<int> values)
        {
            List<List<int>> ranges = new List<List<int>>();

            int lastNumber = 0;
            List<int> currentRange = null;

            for (int i = 0; i < values.Count; i++)
            {
                if (i == 0)
                {
                    currentRange = new List<int>() { values[i] };
                    ranges.Add(currentRange);
                    lastNumber = values[i];
                }
                else
                {
                    if (values[i] == lastNumber || values[i] == lastNumber + 1)
                    {
                        currentRange.Add(values[i]);
                    }
                    else
                    {
                        currentRange = new List<int>() { values[i] };
                        ranges.Add(currentRange);
                    }
                    lastNumber = values[i];
                }
            }

            return ranges;
        }

        static string ConvertRangesToString(List<List<int>> ranges)
        {
            string output = string.Empty;

            for (int i = 0; i < ranges.Count; i++)
            {
                output += ConvertRangeToString(ranges[i]);
            }

            return output;
        }

        static string ConvertRangeToString(List<int> range)
        {
            if (range.Count > 1)
            {
                return string.Format(outputFormat, range[0], range[range.Count - 1], range.Count);
            }

            return string.Empty;
        }
    }
}
