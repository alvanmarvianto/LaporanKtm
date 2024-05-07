
using LaporanKtmLibrary.Common;
using LaporanKtmAPI.Model;
using LaporanKtmLibrary.Output;


namespace LaporanKtmTest
{
    [TestClass]
    public class FajarTest
    {
        [TestMethod]
        public void pastikanbulan  ()
        {
            int ankga = 4;
           string huruf=Date.ConvertIntToMonthString(ankga);
            Assert.AreEqual(huruf, "April");
        }

           }
}