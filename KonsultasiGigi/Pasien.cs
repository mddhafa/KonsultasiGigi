using System;
using System.Data;
using System.Data.SqlClient;

namespace KonsultasiGigi
{
    internal class Pasien
    {
        public void Main()
        {
            SqlConnection conn = null;

            while (true)
            {
                try
                {
                    string strKoneksi = "Data source = DESKTOP-CF1TJJB;" + "initial catalog = KonsultasiDokterGigi; " + "User ID = sa; Password = 1234";
                    conn = new SqlConnection(strKoneksi);
                    conn.Open();
                    Console.Clear();

                    if (Login(conn))
                    {
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("\nMenu");
                                Console.WriteLine("1. Melihat Seluruh Data");
                                Console.WriteLine("2. Cari Data Pasien");
                                Console.WriteLine("3. Keluar");
                                Console.WriteLine("\n Enter your choice (1-3): ");
                                char ch = Convert.ToChar(Console.ReadLine());
                                switch (ch)
                                {
                                    case '1':
                                        Console.Clear();
                                        Console.WriteLine("Data Pasien\n");
                                        Console.WriteLine();
                                        BacaData(conn);
                                        break;
                                    case '2':
                                        Console.Clear();
                                        Console.WriteLine("Cari Data Pasien Berdasarkan ID Pasien\n");
                                        Console.WriteLine("Masukkan ID Pasien yang ingin dicari: ");
                                        string searchIdPasien = Console.ReadLine();
                                        try
                                        {
                                            SearchByIdPasien(searchIdPasien, conn);
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
        }

        public bool Login(SqlConnection conn)
        {
            Console.WriteLine("=== Selamat Datang di Aplikasi Konsultasi Gigi ===");
            Console.WriteLine("Silakan masukkan id pengguna dan kata sandi untuk masuk.");
            Console.Write("ID Pasien: ");
            string username = Console.ReadLine();
            Console.Write("Kata Sandi: ");
            string password = Console.ReadLine();

            string query = "SELECT COUNT(*) FROM Pasien WHERE Id_Pasien = @username AND Password_pasien = @password";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM Pasien", con);
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

        public void SearchByIdPasien(string idPasien, SqlConnection con)
        {
            string query = "SELECT * FROM Pasien WHERE Id_Pasien = @idPasien";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@idPasien", idPasien);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine("Hasil Pencarian:\n");
                while (reader.Read())
                {
                    Console.WriteLine($"ID Pasien: {reader["Id_Pasien"]}, Nama Pasien: {reader["Nama_Pasien"]}, Jenis Kelamin: {reader["Jenis_Kelamin"]}, Email: {reader["Email"]}, No. HP: {reader["No_HP"]}, Alamat: {reader["Alamat"]}");
                }
            }
            else
            {
                Console.WriteLine("Data Pasien tidak ditemukan.");
            }

            reader.Close();
        }
    }
}
