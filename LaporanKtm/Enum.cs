using System;
using System.Collections.Generic;

public enum State
{
    Start,
    MembuatLaporan,
    MengeditLaporan,
    Ketemu
}

public enum Trigger { proses, cancel, cari, edit };

class StateTodo
{
    public class Transition
    {
        public State StateAwal;
        public State StateAkhir;
        public Trigger Trigger;

        public Transition(State stateAwal, State stateAkhir, Trigger trigger)
        {
            this.StateAwal = stateAwal;
            this.StateAkhir = stateAkhir;
            this.Trigger = trigger;
        }
    }

    Transition[] transisi =
    {
        new Transition(State.Start, State.MembuatLaporan, Trigger.proses),
        new Transition(State.MembuatLaporan, State.Ketemu, Trigger.cari),
        new Transition(State.MembuatLaporan, State.Start, Trigger.cancel),
        new Transition(State.MembuatLaporan, State.MengeditLaporan, Trigger.edit),
        new Transition(State.MengeditLaporan, State.MembuatLaporan, Trigger.proses)
    };

    public State currentState = State.Start;
    public Dictionary<string, State> tasks = new Dictionary<string, State>();

    public State GetNextState(State stateAwal, Trigger trigger)
    {
        foreach (Transition perubahan in transisi)
        {
            if (stateAwal == perubahan.StateAwal && trigger == perubahan.Trigger)
            {
                return perubahan.StateAkhir;
            }
        }
        return stateAwal;
    }

    public void ActivateTrigger(Trigger trigger)
    {
        currentState = GetNextState(currentState, trigger);
        Console.WriteLine("State Anda adalah: " + currentState);
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