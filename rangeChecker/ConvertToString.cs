using System.Collections.Generic;

namespace rangeChecker
{
    public class ConvertToString
    {
        const string outputFormat = "{0}-{1}, {2}\n";

        public static string ConvertRangesToString(List<List<int>> ranges)
        {
            string output = string.Empty;

            for (int i = 0; i < ranges.Count; i++)
            {
                output += ConvertRangeToString(ranges[i]);
            }

            return output;
        }

        public static string ConvertRangeToString(List<int> range)
        {
            if (range.Count > 1)
            {
                return string.Format(outputFormat, range[0], range[range.Count - 1], range.Count);
            }

            return string.Empty;
        }
    }
}
