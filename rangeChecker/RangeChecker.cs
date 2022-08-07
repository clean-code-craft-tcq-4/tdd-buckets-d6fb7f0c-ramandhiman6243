using System;
using System.Collections.Generic;

namespace rangeChecker
{
    public class RangeChecker
    {
        const string outputFormat = "{0}-{1}, {2}\n";

        static void Main()
        {
            GetContinuousRangesInCsv(new List<int>() { 3, 3, 5, 4, 10, 11, 12 });
            Console.WriteLine("All is well");
        }

        public static string GetContinuousRangesInCsv(List<int> values)
        {
            if (values != null)
            {
                values.Sort();
                string csvs = GetConsecutiveValues(values);
                return csvs;
            }
            return string.Empty;
        }

        static string GetConsecutiveValues(List<int> values)
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

            string output = string.Empty;
            for (int j = 0; j < ranges.Count; j++)
            {
                if (ranges[j].Count > 1)
                {
                    List<int> range = ranges[j];
                    output += string.Format(outputFormat, range[0], range[range.Count - 1], range.Count);
                }

            }
            Console.WriteLine(output);

            return output;
        }
    }
}
