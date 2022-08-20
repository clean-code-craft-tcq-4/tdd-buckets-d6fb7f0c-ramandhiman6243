using System.Collections.Generic;
using System.Text;

namespace Range
{
    public class StringUtility
    {
        public static string ConvertRangesToString(List<List<int>> ranges, string outputFormat)
        {
            StringBuilder outputString = new StringBuilder();

            for (int i = 0; i < ranges.Count; i++)
            {
                string range = ConvertRangeToString(ranges[i], outputFormat);
                AppendIfNotEmpty(outputString, range);
            }

            return outputString.ToString();
        }

        public static string ConvertRangeToString(List<int> range, string outputFormat)
        {
            if (range.Count > 1)
            {
                return string.Format(outputFormat, range[0], range[range.Count - 1], range.Count);
            }

            return string.Empty;
        }

        private static void AppendIfNotEmpty(StringBuilder outputString, string range)
        {
            if (!string.IsNullOrEmpty(range))
                outputString.Append(range);
        }
    }
}
