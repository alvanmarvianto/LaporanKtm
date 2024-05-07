using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LaporanKtmAPI.Controllers
{
    public class TableDrivenBulan
    {
        public enum bulan
        {
            Januari = 1,
            Februari = 2,
            Maret = 3,
            April = 4,
            Mei = 5,
            Juni = 6,
            Juli = 7,
            Agustus = 8,
            September = 9,
            Oktober = 10,
            November = 11,
            Desember = 12
        }
        public static readonly Dictionary<string, bulan> Bulan = new Dictionary<string, bulan>
        {
            {"Januari", bulan.Januari },
            {"Februari", bulan.Februari},
            {"Maret", bulan.Maret},
            {"April", bulan.April},
            {"Mei", bulan.Mei },
            {"Juni", bulan.Juni },
            {"Juli", bulan.Juli },
            {"Agustus", bulan.Agustus},
            {"September", bulan.September},
            {"Oktober", bulan.Oktober },
            {"November", bulan.November },
            {"Desember", bulan.Desember },
        };
        public static bulan getbulan(string namabulan)
        {
            return Bulan[namabulan];
        }
    }
}
