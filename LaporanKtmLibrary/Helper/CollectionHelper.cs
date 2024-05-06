using System;
namespace LaporanKtmLibrary.Helper
{
	public class CollectionHelper
	{
        public static List<T> Add<T>(List<T> lists, T data)
        {
            lists.Add(data);
            return lists;
        }

        public static List<T> Delete<T>(List<T> lists, int id)
        {
            lists.Remove(lists[id]);
            return lists;
        }

        public static List<T> Update<T>(List<T> lists, T data, int id)
        {
            lists[id] = data;
            return lists;
        }

        public static List<T> GetAll<T>(List<T> lists)
        {
            return lists;
        }

        public static T GetById<T>(List<T> lists, int id)
        {
            return lists[id];
        }
    }
}

