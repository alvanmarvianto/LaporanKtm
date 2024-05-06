
using LaporanKtmLibrary.Common;
using LaporanKtmAPI.Model;


namespace LaporanKtmTest
{
    [TestClass]
    public class fajartest
    {
        [TestMethod]
        public void By()
        {
            // Arrange
            var list = new List<Laporan>
            {
                new Laporan("John", "john@example.com", "123456", State.Start),
                new Laporan("Alice", "alice@example.com", "234567", State.MembuatLaporan),
                new Laporan("Bob", "bob@example.com", "345678", State.MengeditLaporan),
                new Laporan("Eve", "eve@example.com", "456789", State.Ketemu)
            };

            // Act
            int index = Search<Laporan>.ByNim(list, new Laporan("", "", "345678", State.Start));

            // Assert
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void ByNim_ShouldReturnMinusOne_WhenItemDoesNotExist()
        {
            // Arrange
            var list = new List<Laporan>
            {
                new Laporan("John", "john@example.com", "123456", State.Start),
                new Laporan("Alice", "alice@example.com", "234567", State.MembuatLaporan),
                new Laporan("Bob", "bob@example.com", "345678", State.MengeditLaporan),
                new Laporan("Eve", "eve@example.com", "456789", State.Ketemu)
            };

            // Act
            int index = Search<Laporan>.ByNim(list, new Laporan("", "", "999999", State.Start));

            // Assert
            Assert.AreEqual(-1, index);
        }
    }
}