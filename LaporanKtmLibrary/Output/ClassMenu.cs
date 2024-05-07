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
        public struct Laporan
        {
            public int Id { get; set; }
            public string Pelapor { get; set; }
            public DateTime tanggalLaporan { get; set; }
        }

        Laporan[] daftarLaporan = new Laporan[5];

        public void startPage()
        {
            int x;
            Console.WriteLine("===== Layanan Pengaduan Kehilangan KTM =====");
            Console.WriteLine(" ");
            Console.WriteLine(" 1. Create Laporan Baru");
            Console.WriteLine(" 2. Lihat Laporan Aktif");
            Console.WriteLine(" 3. Ubah Laporan Aktif");
            Console.WriteLine(" 4. Search Laporan");
            Console.WriteLine(" 9. Exit");
            Console.WriteLine(" ");

            Console.WriteLine("Masukan: ");
            x = Convert.ToInt32(Console.ReadLine());

            if (x < 0 || x > 9)
            {
                Console.WriteLine("Masukan angka valid!");
            }
            else if (x == 1)
            {
                createPage();
            }
            else if (x == 2)
            {
                lihatPage();
            }
            else if (x == 3)
            {
                editPage();
            }
            else if (x == 4) 
            { 
                
            }
            else if (x == 9)
            {
                Console.WriteLine("end");
            }

            Console.WriteLine("end");

        }

        public void createPage()
        {
            int x;
            Console.WriteLine("===== Create Laporan Baru =====");
            Console.WriteLine(" 1. Masukan Data Pelaporan");
            Console.WriteLine(" 9. Exit");

            Console.WriteLine("Masukan: ");
            x = Convert.ToInt32(Console.ReadLine());

            if (x != 1 || x != 9)
            {
                Console.WriteLine("Masukan angka valid!");
            }
            else if (x == 1)
            {
                Console.WriteLine("Masukan nama pelapor: ");
                daftarLaporan[0].Pelapor = Console.ReadLine();
            }
            else if (x == 9)
            {
                startPage();
            }

            Console.WriteLine("end");

        }

        public void lihatPage()
        {
            int x;
            Console.WriteLine("===== Show Laporan Baru =====");
            Console.WriteLine(" 1. Tampilkan List Laporan");
            Console.WriteLine(" 9. Exit");

            Console.WriteLine("Masukan: ");
            x = Convert.ToInt32(Console.ReadLine());

            if (x != 1 || x != 9)
            {
                Console.WriteLine("Masukan angka valid!");
            }
            else if (x == 1)
            {
                int i = 5;
                while (i != 0) 
                {
                    Console.WriteLine("Nama: " + daftarLaporan[i].Pelapor);
                    Console.WriteLine("ID: " + daftarLaporan[i].Id);
                    Console.WriteLine("Tanggal: " + daftarLaporan[i].tanggalLaporan);
                }
                i--;
            }
            else if (x == 9)
            {
                startPage();
            }

            Console.WriteLine("end");
        }

        public void editPage()
        {
            int x;
            Console.WriteLine("===== Edit Laporan Baru =====");
            Console.WriteLine(" 1. List Laporan yang dapat diubah");
            Console.WriteLine(" 9. Exit");

            Console.WriteLine("Masukan: ");
            x = Convert.ToInt32(Console.ReadLine());

            if (x != 1 || x != 9)
            {
                Console.WriteLine("Masukan angka valid!");
            }
            else if (x == 1)
            {
                int i = 0;
                while (i != 5)
                {
                    Console.WriteLine(i + ". Nama: " + daftarLaporan[i].Pelapor);
                    Console.WriteLine("ID: " + daftarLaporan[i].Id);
                    Console.WriteLine("Tanggal: " + daftarLaporan[i].tanggalLaporan);
                }
                i++;
            }
            else if (x == 9)
            {
                startPage();
            }

            Console.WriteLine("end");

        }

        public void search() 
        {
            string nim;
            Console.WriteLine("Masukan NIM yang dicari: ");
            nim = Console.ReadLine();

        }

        public void endPage()
        {
            Console.WriteLine("======== Terima Kasih Sudah Melapor! ========");
        }
    }
}
