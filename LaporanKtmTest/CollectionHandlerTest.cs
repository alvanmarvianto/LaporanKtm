using System;
using LaporanKtmLibrary.Helper;
using LaporanKtmAPI.Model;
namespace LaporanKtmTest
{
	[TestClass]
	public class CollectionHandlerTest
	{
		[TestMethod]
		public void CreateList_ShouldBeAdded()
		{
			var obj = new Laporan(1, "Al", "al@gmail.com", "1302223047", 0, default);
            List<Laporan> laporan = new List<Laporan>();
            List<Laporan> result = new List<Laporan>();

            laporan.Add(obj);
			CollectionHelper.Add<Laporan>(result, obj);

			Assert.AreEqual(laporan.Count, result.Count);
		}

		[TestMethod]
		public void DeleteList_ShouldBeTrue()
		{
			var obj = new Laporan(0, "Al", "al@gmail.com", "1302223047", 0, default);
            List<Laporan> laporan = new List<Laporan>();
            laporan.Add(obj);

			CollectionHelper.Delete(laporan, 0);
			Assert.AreEqual(0, laporan.Count);
        }

		[TestMethod]
		public void FindIdList_ShouldBeTrue()
		{
            var obj = new Laporan(0, "Al", "al@gmail.com", "1302223047", 0, default);
            List<Laporan> laporan = new List<Laporan>();
			laporan.Add(obj);

			var updated = CollectionHelper.GetById(laporan, 0);

			Assert.AreEqual(0, updated.Id);
        }
	}
}

