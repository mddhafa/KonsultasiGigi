﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace KonsultasiGigi
{
    internal class Dokter
    {
        public void Main()
        {
            SqlConnection conn = null;

            try
            {
                string strKoneksi = "Data source = DESKTOP-CF1TJJB;" + "initial catalog = KonsultasiDokterGigi; " + "User ID = sa; Password = 1234";
                conn = new SqlConnection(strKoneksi);
                conn.Open();

                if (Login(conn))
                {
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("\nMenu");
                            Console.WriteLine("1. Melihat Seluruh Data");
                            Console.WriteLine("2. Cari Data Dokter");
                            Console.WriteLine("3. Keluar");
                            Console.WriteLine("\n Enter your choice (1-3): ");
                            char ch = Convert.ToChar(Console.ReadLine());
                            switch (ch)
                            {
                                case '1':
                                    Console.Clear();
                                    Console.WriteLine("Data Dokter\n");
                                    Console.WriteLine();
                                    BacaData(conn);
                                    break;

                                case '2':
                                    Console.Clear();
                                    Console.WriteLine("Cari Data Dokter Berdasarkan ID Dokter\n");
                                    Console.WriteLine("Masukkan ID Dokter yang ingin dicari: ");
                                    string searchIdDokter = Console.ReadLine();
                                    try
                                    {
                                        SearchByIdDokter(searchIdDokter, conn);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("\nTerjadi kesalahan dalam pencarian data: " + e.Message);
                                    }
                                    break;
                                case '3':
                                    conn.Close();
                                    Console.Clear();
                                    return;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("\n Invalid option");
                                    break;
                            }
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("\nCheck for the value entered");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Tidak Dapat Mengakses Database Tersebut\n");
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            finally
            {
                conn?.Close();
            }
        }

        public bool Login(SqlConnection conn)
        {
            Console.WriteLine("=== Selamat Datang di Aplikasi Konsultasi Gigi ===");
            Console.WriteLine("Silakan masukkan id pengguna dan kata sandi untuk masuk.");
            Console.Write("ID Dokter: ");
            string iddokter = Console.ReadLine();
            Console.Write("Kata Sandi: ");
            string password = Console.ReadLine();

            string query = "SELECT COUNT(*) FROM dokter WHERE Id_Dokter = @iddokter AND Password_dokter = @password";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@iddokter", iddokter);
            cmd.Parameters.AddWithValue("@password", password);

            int count = (int)cmd.ExecuteScalar();

            if (count > 0)
            {
                Console.WriteLine("Login berhasil!");
                return true;
            }
            else
            {
                Console.WriteLine("Nama pengguna atau kata sandi salah. Silakan coba lagi.");
                return false;
            }
        }


        public void BacaData(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Dokter", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }
        public void SearchByIdDokter(string idDokter, SqlConnection con)
        {
            string query = "SELECT * FROM Dokter WHERE Id_Dokter = @idDokter";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@idDokter", idDokter);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine("Hasil Pencarian:\n");
                while (reader.Read())
                {
                    Console.WriteLine($"ID Dokter: {reader["Id_Dokter"]}, Nama Dokter: {reader["Nama_Dokter"]}, Jenis Kelamin: {reader["Jenis_Kelamin"]}, Email: {reader["Email"]}, No. HP: {reader["No_HP"]}, Alamat: {reader["Alamat"]}");
                }
            }
            else
            {
                Console.WriteLine("Data Dokter tidak ditemukan.");
            }

            reader.Close();
        }
    }
}
