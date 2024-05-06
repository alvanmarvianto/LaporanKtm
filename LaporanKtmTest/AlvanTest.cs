
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
                    new Laporan("John", "john@example.com", "1234567890", State.Start,default),
                    new Laporan("Alice", "alice@example.com", "0987654321", State.MembuatLaporan, default),
                    new Laporan("Bob", "bob@example.com", "1234560987", State.MengeditLaporan, default),
                    new Laporan("Eve", "eve@example.com", "0987612345", State.Ketemu, default)
                };

                // Act
                int index = Search<Laporan>.ByNim(list, new Laporan("", "", "1234560987", State.Start, default));

                // Assert
                Assert.AreEqual(2, index);
            }

            [TestMethod]
            public void ByNim_ShouldReturnMinusOne_WhenItemDoesNotExist()
            {
                // Arrange
                var list = new List<Laporan>
                {
                    new Laporan("John", "john@example.com", "1212121212", State.Start,default),
                    new Laporan("Alice", "alice@example.com", "2323232323", State.MembuatLaporan, default),
                    new Laporan("Bob", "bob@example.com", "5656565656", State.MengeditLaporan, default),
                    new Laporan("Eve", "eve@example.com", "7878787878", State.Ketemu, default)
                };

                // Act
                int index = Search<Laporan>.ByNim(list, new Laporan("", "", "9999999999", State.Start, default));

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
                    new Laporan("John", "john@example.com", "1010101010", State.Start, twoDaysAgo),
                    new Laporan("Alice", "alice@example.com", "4040404040", State.MembuatLaporan, today),
                    new Laporan("Bob", "bob@example.com", "5757575757", State.MengeditLaporan, yesterday),
                    new Laporan("Eve", "eve@example.com", "9393939393", State.Ketemu, default)
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