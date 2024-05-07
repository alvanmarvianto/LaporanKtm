using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LaporanKtmTest
{
    [TestClass]
    public class PuriTest
    {
        [TestMethod]
        public void AddTaska_ShouldAddTaskToList()
        {
            // Arrange
            var stateTodo = new StateTodo();
            var expectedTask = "Membuat laporan";
            var expectedState = State.Start;

            // Act
            stateTodo.AddTaska(expectedTask, expectedState);

            // Assert
            var tasks = stateTodo.tasks;
            Assert.IsTrue(tasks.ContainsKey(expectedTask));
            Assert.AreEqual(expectedState, tasks[expectedTask]);
        }
    }
}
