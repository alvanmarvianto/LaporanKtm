using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaporanKtmLibrary.Output
{
    internal class GeneralMenu
    {

        public String startPage()
        {
            string x;
            Console.WriteLine("===== Layanan Pengaduan Kehilangan KTM =====");
            Console.WriteLine(" ");
            Console.WriteLine(" 1. Create Laporan Baru");
            Console.WriteLine(" 2. Lihat Laporan Aktif");
            Console.WriteLine(" 3. Ubah Laporan Aktif");
            Console.WriteLine(" 9. Exit");
            Console.WriteLine(" ");

            Console.WriteLine("Masukan: ");
            x = Console.ReadLine();

            if (x != "1" || x != "2" || x != "3" || x != "9")
            {
                return "Masukan angka valid!";
            }
            else if (x == "1")
            {
                createPage();
            }
            else if (x == "2")
            {
                lihatPage();
            }
            else if (x == "3")
            {
                editPage();
            }
            else if (x == "9")
            {
                return "end";
            }

            return "end";

        }

        public String createPage()
        {
            string x;
            Console.WriteLine("===== Create Laporan Baru =====");
            Console.WriteLine(" 1. Masukan Data Pelaporan");
            Console.WriteLine(" 9. Exit");

            Console.WriteLine("Masukan: ");
            x = Console.ReadLine();

            if (x != "1" || x != "9")
            {
                return "Masukan angka valid!";
            }
            else if (x == "1")
            {
                string nama;
                string NIM;

                Console.WriteLine("Masukan Nama Pelapor: ");
                nama = Console.ReadLine();

                Console.WriteLine("Masukan NIM: ");
                NIM = Console.ReadLine();

            }
            else if (x == "9")
            {
                return startPage();
            }

            return "end";

        }

        public String lihatPage()
        {
            string x;
            Console.WriteLine("===== Show Laporan Baru =====");
            Console.WriteLine(" 1. Tampilkan List Laporan");
            Console.WriteLine(" 9. Exit");

            Console.WriteLine("Masukan: ");
            x = Console.ReadLine();

            if (x != "1" || x != "9")
            {
                return "Masukan angka valid!";
            }
            else if (x == "1")
            {
                // x berupa panjang list laporan yang dibuat
                for (int i = 0; i < x; i++)
                {
                    x
                }
            }
            else if (x == "9")
            {
                return startPage();
            }

            return "end";
        }

        public String editPage()
        {
            string x;
            Console.WriteLine("===== Edit Laporan Baru =====");
            Console.WriteLine(" 1. List Laporan yang dapat diubah");
            Console.WriteLine(" 9. Exit");

            Console.WriteLine("Masukan: ");
            x = Console.ReadLine();

            if (x != "1" || x != "9")
            {
                return "Masukan angka valid!";
            }
            else if (x == "1")
            {
                // x berupa panjang list laporan yang dibuat
                for (int i = 0; i < x; i++)
                {
                    x
                }

            }
            else if (x == "9")
            {
                return startPage();
            }

            return "end";

        }

        public string endPage()
        {
            return "======== Terima Kasih Sudah Melapor! ========";
        }
    }
}
