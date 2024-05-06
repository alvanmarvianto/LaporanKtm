using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LaporanKtm
{
    public class TableDrivenState
    {
        public enum state
        {
            Start,
            MembuatLaporan,
            MengeditLaporan,
            MencariLaporan,
            MembacaLaporan
        }

        public static readonly Dictionary<string, state> STATE = new Dictionary<string, state>
        {
            {"Start", state.Start},
            {"MembuatLaporan", state.MembuatLaporan},
            {"MengeditLaporan",state.MengeditLaporan},
            {"MencariLaporan", state.MencariLaporan},
            {"MembacaLaporan", state.MembacaLaporan},
        };
        public static state getstate(string State)
        {
            return STATE[State];
        }
    }
}

