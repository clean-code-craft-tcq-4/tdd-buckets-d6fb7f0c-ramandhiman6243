using System.Collections.Generic;

namespace Range
{
    public class RangeData
    {
        public int Start
        {
            get
            {
                if (RangeList.Count > 0)
                    return RangeList[0];

                return 0;
            }
        }

        public int End
        {
            get
            {
                if (RangeList.Count > 0)
                    return rangeList[rangeList.Count - 1];

                return 0;
            }
        }

        public int Count
        {
            get
            {
                return RangeList.Count;
            }
        }

        public List<int> RangeList
        {
            get
            {
                if (rangeList == null)
                    rangeList = new List<int>();

                return rangeList;
            }
        }

        List<int> rangeList;

        public void AddNumber(int number)
        {
            RangeList.Add(number);
        }
    }
}
