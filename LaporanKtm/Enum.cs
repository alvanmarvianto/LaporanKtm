using System;
using System.Collections.Generic;

// Mendefinisikan state dalam automata
public enum State
{
    Start,
    MembuatLaporan,
    MengeditLaporan,
    MencariLaporan,
    MembacaLaporan
}
public enum Trigger { proses, cancel };

// Mendefinisikan transisi dalam automata
class Transition
{
    public State FromState { get; set; }
    public State ToState { get; set; }
    public State FinalState { get; set; }
    public string Input { get; set; }
}

// Mensimulasikan alur interaksi dalam aplikasi
public class AutomataSimulator
{
    private State currentState;

    public AutomataSimulator()
    {
        currentState = State.Start;
    }

    public void ProcessInput(string input)
    {
        // Mencari transisi yang sesuai dengan state dan input saat ini
        Transition transition = FindTransition(currentState, input);

        if (transition != null)
        {
            // Memperbarui state
            currentState = transition.ToState;

            // Melakukan tindakan berdasarkan state baru
            switch (currentState)
            {
                case State.MembuatLaporan:
                    // Tampilkan formulir untuk membuat laporan
                    break;
                case State.MengeditLaporan:
                    // Tampilkan formulir untuk mengedit laporan
                    break;
                case State.MencariLaporan:
                    // Tampilkan formulir untuk mencari laporan
                    break;
                case State.MembacaLaporan:
                    // Tampilkan laporan yang dipilih
                    break;
            }
        }
    }

    private Transition FindTransition(State currentState, string input)
    {
        // Implementasikan logika untuk mencari transisi yang sesuai
        // ...
    }

    public void AddTask(string task, State taskState)
    {
        tasks.Add(task, taskState);
        Console.WriteLine("Tambah task: " + task + " (State: " + taskState + ")");
    }

    public void DisplayTasks()
    {
        Console.WriteLine("Daftar task:");
        foreach (var task in tasks)
        {
            Console.WriteLine("- " + task.Key + " (State: " + task.Value + ")");
        }
    }

    public void ChangeTaskState(string task, State newState)
    {
        if (tasks.ContainsKey(task))
        {
            tasks[task] = newState;
            Console.WriteLine("ktm  task '" + task + "' berhasil diubah menjadi: " + newState);
        }
        else
        {
            Console.WriteLine("ktm '" + task + "' tidak ditemukan.");
        }
    }

    public void Run()
    {
        //puri masuk deh
        Console.WriteLine("Daftar trigger yang tersedia:");
        foreach (Trigger trigger in Enum.GetValues(typeof(Trigger)))
        {
            Console.WriteLine("- " + trigger);
        }

        Console.WriteLine();
        Console.Write("Masukkan jumlah task yang ingin ditambahkan: ");
        int jumlahTask = int.Parse(Console.ReadLine());

        for (int i = 0; i < jumlahTask; i++)
        {
            Console.Write("Masukkan nama task ke-" + (i + 1) + ": ");
            string namaTask = Console.ReadLine();
            AddTask(namaTask, State.Start);
        }

        DisplayTasks();

        Console.Write("Masukkan nama task yang ingin diubah statusnya: ");
        string taskYangDiubah = Console.ReadLine();
        Debug.Assert(!string.IsNullOrEmpty(taskYangDiubah), "Nama task tidak boleh kosong");

        Console.WriteLine("Daftar trigger yang tersedia:");
        foreach (Trigger trigger in Enum.GetValues(typeof(Trigger)))
        {
            Console.WriteLine("- " + trigger);
        }

        Console.WriteLine();
        Console.Write("Pilih trigger untuk task '" + taskYangDiubah + "': ");
        string triggerInput = Console.ReadLine();

        if (Enum.TryParse(triggerInput, out Trigger selectedTrigger))
        {
            ActivateTrigger(selectedTrigger);
            DisplayTasks();
        }
        else
        {
            Console.WriteLine("Trigger tidak valid.");
        }
    }

}