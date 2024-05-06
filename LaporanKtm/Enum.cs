using System.Collections.Generic;
using System.Diagnostics;
using Utama.Transfer;

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
        State newState = GetNextState(currentState, trigger);
        Console.WriteLine("State Anda adalah: " + newState);

             foreach (var task in tasks.ToList())
        {
            if (task.Value == currentState)
            {
                tasks[task.Key] = newState;
            }
        }

        currentState = newState;
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
            Console.WriteLine("ktm   '" + task + "' berhasil diubah menjadi: " + newState);
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
        Debug.Assert(jumlahTask >= 0, "Jumlah task tidak boleh negatif");

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
            DisplayTasks(); // Perbarui tampilan setelah mengaktifkan trigger
            // Periksa apakah tugas selesai (berada dalam status Ketemu), jika iya, panggil metode Bayar()
            if (tasks.ContainsKey(taskYangDiubah) && tasks[taskYangDiubah] == State.Ketemu)
            {
                Console.WriteLine("Tugas selesai.");
                Bayar();
            }
        }
        else
        {
            Console.WriteLine("Trigger tidak valid.");
        }
    }

    public void Bayar()
    {
        BankTransferConfig config = new BankTransferConfig();
        Console.WriteLine("en/id:");

        Console.WriteLine("bayar");
        string Bahasa = Console.ReadLine();

        string langPrompt = Bahasa == "en" ? "Please insert the amount of money to transfer:" : "Masukkan jumlah uang yang akan di-transfer:";
        Console.WriteLine(langPrompt);
        int amount = int.Parse(Console.ReadLine());

        int totalAmount = amount;

        string feeOutput = Bahasa == "en" ? "Transfer fee = " : "Biaya transfer = ";
        string totalOutput = Bahasa == "en" ? "Total amount = " : "Total biaya = ";
        Console.WriteLine($"{totalOutput} {totalAmount}");

        string methodPrompt = Bahasa == "en" ? "Select transfer method:" : "Pilih metode transfer:";
        Console.WriteLine(methodPrompt);
        for (int i = 0; i < config.Methods.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {config.Methods[i]}");
        }

        Console.Write("Select transfer method number: ");
        int selectedMethodIndex = int.Parse(Console.ReadLine());

        Console.WriteLine($"Selected transfer method: {config.Methods[selectedMethodIndex - 1]}");

        string confirmationPrompt = Bahasa == "en" ? $"Please type \"{config.Confirmation.En}\" to confirm the transaction:" : $"Ketik \"{config.Confirmation.Id}\" untuk mengkonfirmasi transaksi:";
        Console.WriteLine(confirmationPrompt);
        string confirmation = Console.ReadLine();

        string successMessage = Bahasa == "en" ? "The transfer is completed" : "Proses transfer berhasil";
        string failureMessage = Bahasa == "en" ? "Transfer is cancelled" : "Transfer dibatalkan";
        if (confirmation == config.Confirmation.En || confirmation == config.Confirmation.Id)
        {
            Console.WriteLine(successMessage);
        }
        else
        {
            Console.WriteLine(failureMessage);
        }
    }
}
