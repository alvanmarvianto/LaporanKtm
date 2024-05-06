using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace LaporanKtm
{
    public class TableDrivenHari
    {
        public enum hari
        {
            Senin = 1,
            Selasa = 2,
            Rabu = 3,
            Kamis = 4,
            Jumat = 5,
            Sabtu = 6,
            minggu = 7,
        }

        public static readonly Dictionary<string, hari> Hari = new Dictionary<string, hari>
        {
            {"senin", hari.Senin},
            {"selasa", hari.Selasa},
            {"rabu", hari.Rabu},
            {"kamis", hari.Kamis},
            {"jumat", hari.Jumat},
            {"sabtu", hari.Sabtu},
            {"minggu", hari.minggu},
        };
        public static hari gethari(string namahari)
        {
            return Hari[namahari];
        }
    }   
}
