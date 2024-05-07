using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaporanKtm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LaporanKtmTest
{
    [TestClass]
    public class TableDrivenBulanTests
    { 
       [TestMethod]
        public void GetBulan_ReturnsCorrectValue()
        {
        // Arrange
        var expectedBulan = TableDrivenBulan.bulan.Februari;

        // Act
        var actualBulan = TableDrivenBulan.getbulan("Februari");

        // Assert
        Assert.AreEqual(expectedBulan, actualBulan);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetBulan_ThrowsExceptionForInvalidInput()
        {
         // Act & Assert
        TableDrivenBulan.getbulan("InvalidBulanName");
        }
    }
}
