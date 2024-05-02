using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections;
using KonsultasiGigi;

namespace KonsultasiKesehatanGigi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n Halaman Utama");
                Console.WriteLine("1. Menu Admin");
                Console.WriteLine("2. Menu Dokter");
                Console.WriteLine("3. Menu Pasien");

                Console.Write("Masukan Pilihan (1-3) : ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Admindrg admin = new Admindrg();
                        admin.Main();
                        break;
                    case "2":
                        Dokter dokter = new Dokter();
                        dokter.Main();
                        break;
                    case "3":
                        Pasien pasien = new Pasien();
                        pasien.Main();
                        break;
                    default:
                        Console.WriteLine("Pilihan Tidak Tersedia!");
                        break;
                }
            }
        }
    }
}
