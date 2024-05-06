
    using LaporanKtmLibrary.Common;
    using LaporanKtmAPI.Model;


    namespace LaporanKtmTest
    {
        [TestClass]
        public class AlvanTest
        {
            [TestMethod]
            public void ByNim_ShouldReturnCorrectIndex_WhenItemExists()
            {
                // Arrange
                var list = new List<Laporan>
                {
                    new Laporan("John", "john@example.com", "123456", State.Start,default),
                    new Laporan("Alice", "alice@example.com", "234567", State.MembuatLaporan, default),
                    new Laporan("Bob", "bob@example.com", "345678", State.MengeditLaporan, default),
                    new Laporan("Eve", "eve@example.com", "456789", State.Ketemu, default)
                };

                // Act
                int index = Search<Laporan>.ByNim(list, new Laporan("", "", "345678", State.Start, default));

                // Assert
                Assert.AreEqual(2, index);
            }

            [TestMethod]
            public void ByNim_ShouldReturnMinusOne_WhenItemDoesNotExist()
            {
                // Arrange
                var list = new List<Laporan>
                {
                    new Laporan("John", "john@example.com", "123456", State.Start, default),
                    new Laporan("Alice", "alice@example.com", "234567", State.MembuatLaporan, default),
                    new Laporan("Bob", "bob@example.com", "345678", State.MengeditLaporan, default),
                    new Laporan("Eve", "eve@example.com", "456789", State.Ketemu, default)
                };

                // Act
                int index = Search<Laporan>.ByNim(list, new Laporan("", "", "999999", State.Start, default));

                // Assert
                Assert.AreEqual(-1, index);
            }

            [TestMethod]
            public void SortByDate_SortsListInDescendingOrder()
            {
                // Arrange
                var today = DateOnly.FromDateTime(DateTime.Today);
                var yesterday = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));
                var twoDaysAgo = DateOnly.FromDateTime(DateTime.Today.AddDays(-2));
                var list = new List<Laporan>
                {
                    new Laporan("John", "john@example.com", "123456", State.Start, twoDaysAgo),
                    new Laporan("Alice", "alice@example.com", "234567", State.MembuatLaporan, today),
                    new Laporan("Bob", "bob@example.com", "345678", State.MengeditLaporan, yesterday),
                    new Laporan("Eve", "eve@example.com", "456789", State.Ketemu, default)
                };

                // Act
                Sort<Laporan>.ByDate(list, l => l.Date.ToDateTime(default));

                // Assert
                Assert.AreEqual("Alice", list[0].Name);
                Assert.AreEqual("Bob", list[1].Name);
                Assert.AreEqual("John", list[2].Name);
            }
        }
    }