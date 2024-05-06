using System;

namespace LaporanKtmAPI.Model
{
    public class Laporan
    {
        public string Name { get; set; }
        public string EmailSSO { get; set; }
        public string Nim { get; set; }
        public State Status { get; set; }
        public Laporan(string name, string emailSSO, string nim, State status)
        {
            Name = name;
            EmailSSO = emailSSO;
            Nim = nim;
            Status = status;
        }
    }
}
