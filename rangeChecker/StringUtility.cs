using System.Collections.Generic;
using System.Text;

namespace Range
{
    public class StringUtility
    {
        public static string ConvertRangesToString(List<RangeData> ranges, string outputFormat)
        {
            StringBuilder outputString = new StringBuilder();

            for (int i = 0; i < ranges.Count; i++)
            {
                string range = ConvertRangeToString(ranges[i], outputFormat);
                AppendIfNotEmpty(outputString, range);
            }

            return outputString.ToString();
        }

        public static string ConvertRangeToString(RangeData range, string outputFormat)
        {
            if (range.Count > 1)
            {
                return string.Format(outputFormat, range.Start, range.End, range.Count);
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
