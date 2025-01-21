using System;

namespace statebase
{
    public enum State
    {
        Start,
        MembuatLaporan,
        MengeditLaporan,
        Ketemu
    }

    public enum Trigger { proses, cancel, cari, edit };

    public class StateTodo
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
            currentState = newState;
        }

        public void Runa()
        {
            Console.WriteLine("Daftar trigger yang tersedia:");
            foreach (Trigger trigger in Enum.GetValues(typeof(Trigger)))
            {
                Console.WriteLine("- " + trigger);
            }

            Console.WriteLine();
            Console.Write("Pilih trigger untuk memulai: ");
            string triggerInput = Console.ReadLine();

            if (Enum.TryParse(triggerInput, out Trigger selectedTrigger))
            {
                ActivateTrigger(selectedTrigger);
            }
            else
            {
                Console.WriteLine("Trigger tidak valid.");
            }
        }
    }
}
