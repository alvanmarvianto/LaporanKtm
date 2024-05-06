using System;

namespace LaporanKtmAPI.Model
{
    public class Laporan : IComparable<Laporan>
    {
        public string Name { get; set; }
        public string EmailSSO { get; set; }
        public string Nim { get; set; }
        public State Status { get; set; }
        public DateOnly Date { get; set; }
        public Laporan(string name, string emailSSO, string nim, State status, DateOnly date)
        {
            Name = name;
            EmailSSO = emailSSO;
            Nim = nim;
            Status = status;
            Date = date;
        }
        public int CompareTo(Laporan other)
        {
            return string.Compare(Nim, other.Nim);
        }
    }
}
