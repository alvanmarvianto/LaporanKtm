namespace LaporanKtmLibrary.Common
{
    public static class Sort<T>
    {
        public static void ByDate(List<T> list, Func<T, DateTime> dateSelector)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (dateSelector(list[j]) > dateSelector(list[maxIndex]))
                    {
                        maxIndex = j;
                    }
                }

                if (maxIndex != i)
                {
                    T temp = list[i];
                    list[i] = list[maxIndex];
                    list[maxIndex] = temp;
                }
            }
        }


    }
}