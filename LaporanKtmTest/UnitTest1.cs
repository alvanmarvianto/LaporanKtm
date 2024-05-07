using Microsoft.VisualStudio.TestTools.UnitTesting;
using statebase;

[TestClass]
public class StateTodoTests
{
    private StateTodo stateTodo;

    [TestInitialize]
    public void Setup()
    {
        stateTodo = new StateTodo();
    }

    [TestMethod]
    public void TambahTask_JumlahTaskPositif_DitambahkanKeDaftar()
    {
        // Arrange
        int jumlahTask = 2;

        // Act
        stateTodo.Run();
        for (int i = 0; i < jumlahTask; i++)
        {
            stateTodo.AddTask($"Task {i + 1}", State.Start);
        }

        // Assert
        Assert.AreEqual(jumlahTask, stateTodo.tasks.Count);
        foreach (var task in stateTodo.tasks)
        {
            Assert.AreEqual(State.Start, task.Value);
        }
    }
}
