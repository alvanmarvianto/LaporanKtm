namespace LaporanKtmLibrary.Common
{
    public static class Search<T> where T : IComparable<T>
    {
        public static int ByNIM(List<T> sortedList, int nim, Func<T, int> nimSelector)
        {
            int left = 0;
            int right = sortedList.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nimSelector(sortedList[mid]) == nim)
                {
                    return mid;
                }
                else if (nimSelector(sortedList[mid]) < nim)
                {
                    left = mid + 1; 
                }
                else
                {
                    right = mid - 1; 
                }
            }

            return -1;
        }
    }
}