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
}
