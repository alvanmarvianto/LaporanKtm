using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaporanKtmLibrary.Output
{
    public static class Date
    {
        public static string ConvertIntToMonthString(int month)
        {
            String[] months = { "Januari", "Februrari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember" };
            return months[month - 1];
        }
        public static string ConvertDateOnlyToString(DateOnly date)
        {
            string dayOfWeek = date.DayOfWeek.ToString();
            string day = date.Day.ToString();
            string month = ConvertIntToMonthString(Int32.Parse(date.Month.ToString()));
            string year = date.Year.ToString();
            return dayOfWeek + ", " + day + " " + month + " " + year;
        }
    }
}