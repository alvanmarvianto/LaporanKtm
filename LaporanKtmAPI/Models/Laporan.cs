using System;

namespace LaporanKtmAPI.Model
{
    public class Laporan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailSSO { get; set; }
        public string Nim { get; set; }
        public State Status { get; set; }
        public DateOnly Date { get; set; }
        public Laporan(int id, string name, string emailSSO, string nim, State status, DateOnly date)
        {
            Id = id;
            Name = name;
            EmailSSO = emailSSO;
            Nim = nim;
            Status = status;
            Date = date;
        }
    }
}
