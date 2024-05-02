using System;
using System.Data;
using System.Data.SqlClient;

namespace KonsultasiGigi
{
    internal class BookingJadwal
    {
        public void Main()
        {
            while (true)
            {
                try
                {
                    SqlConnection conn = null;
                    string strKoneksi = "Data source = DESKTOP-CF1TJJB;" + "initial catalog = KonsultasiDokterGigi; " + "User ID = sa; Password = 1234";
                    conn = new SqlConnection(strKoneksi);
                    conn.Open();
                    Console.Clear();
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("\nMenu");
                            Console.WriteLine("1. Melihat Seluruh Data");
                            Console.WriteLine("2. Tambah Data Booking");
                            Console.WriteLine("3. Hapus Data Booking");
                            Console.WriteLine("4. Edit Data Booking");
                            Console.WriteLine("5. Cari Data Booking");
                            Console.WriteLine("6. Keluar");
                            Console.WriteLine("\n Enter your choice (1-6): ");
                            char ch = Convert.ToChar(Console.ReadLine());
                            switch (ch)
                            {
                                case '1':
                                    Console.Clear();
                                    Console.WriteLine("Data Booking\n");
                                    Console.WriteLine();
                                    BacaData(conn);
                                    break;
                                case '2':
                                    Console.Clear();
                                    Console.WriteLine("Input Data Booking\n");
                                    Console.WriteLine("Masukkan ID Dokter : ");
                                    string idDokter = Console.ReadLine();
                                    Console.WriteLine("Masukkan ID Pasien : ");
                                    string idPasien = Console.ReadLine();
                                    try
                                    {
                                        InsertData(idDokter, idPasien, conn);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("\nAnda tidak memiliki " +
                                            "akses untuk menambah data");
                                    }
                                    break;
                                case '3':
                                    Console.Clear();
                                    Console.WriteLine("Masukkan ID Booking ingin dihapus:\n");
                                    string idBookingHapus = Console.ReadLine();
                                    try
                                    {
                                        DeleteData(idBookingHapus, conn);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("\nAnda tidak memiliki " +
                                            "akses untuk menghapus data atau data yang anda masukkan salah");
                                    }
                                    break;
                                case '4':
                                    Console.Clear();
                                    Console.WriteLine("Update Data Booking\n");
                                    Console.WriteLine("Masukkan ID Booking yang akan diupdate: ");
                                    string idBookingToUpdate = Console.ReadLine();
                                    Console.WriteLine("Masukkan data baru:\n");
                                    Console.WriteLine("Masukkan ID Dokter Baru : ");
                                    string newIdDokter = Console.ReadLine();
                                    Console.WriteLine("Masukkan ID Pasien Baru : ");
                                    string newIdPasien = Console.ReadLine();
                                    try
                                    {
                                        UpdateData(idBookingToUpdate, newIdDokter, newIdPasien, conn);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("\nAnda tidak memiliki akses untuk mengubah data atau data yang anda masukkan salah");
                                    }
                                    break;
                                case '5':
                                    Console.Clear();
                                    Console.WriteLine("Cari Data Booking Berdasarkan ID Booking\n");
                                    Console.WriteLine("Masukkan ID Booking yang ingin dicari: ");
                                    string searchIdBooking = Console.ReadLine();
                                    try
                                    {
                                        SearchByIdBooking(searchIdBooking, conn);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("\nTerjadi kesalahan dalam pencarian data: " + e.Message);
                                    }
                                    break;
                                case '6':
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
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Tidak Dapat Mengakses Database Tersebut\n");
                    Console.ResetColor();
                }
            }
        }

        public void BacaData(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM booking_jadwal", con);
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

        public void InsertData(string idDokter, string idPasien, SqlConnection conn)
        {
            if (string.IsNullOrEmpty(idDokter) || string.IsNullOrEmpty(idPasien))
            {
                Console.WriteLine("ID Dokter dan ID Pasien harus diisi.");
                return;
            }
            string str = "INSERT INTO booking_jadwal (Id_Dokter, Id_Pasien)" +
                "VALUES (@idDokter, @idPasien)";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@idDokter", idDokter);
            cmd.Parameters.AddWithValue("@idPasien", idPasien);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Booking Berhasil Ditambahkan");
        }

        public void DeleteData(string idBooking, SqlConnection con)
        {
            if (string.IsNullOrEmpty(idBooking))
            {
                Console.WriteLine("ID Booking harus diisi.");
                return;
            }
            string str = "DELETE FROM booking_jadwal WHERE Id_Booking = @idBooking";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@idBooking", idBooking);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Booking Berhasil Dihapus");
        }

        public void UpdateData(string idBooking, string newIdDokter, string newIdPasien, SqlConnection con)
        {
            if (string.IsNullOrEmpty(idBooking) || string.IsNullOrEmpty(newIdDokter) || string.IsNullOrEmpty(newIdPasien))
            {
                Console.WriteLine("ID Booking, ID Dokter, dan ID Pasien harus diisi.");
                return;
            }

            string str = "UPDATE booking_jadwal SET Id_Dokter = @newIdDokter, Id_Pasien = @newIdPasien WHERE Id_Booking = @idBooking";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@newIdDokter", newIdDokter);
            cmd.Parameters.AddWithValue("@newIdPasien", newIdPasien);
            cmd.Parameters.AddWithValue("@idBooking", idBooking);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Data Booking Berhasil diupdate.");
            }
            else
            {
                Console.WriteLine("Data Booking tidak ditemukan atau gagal diupdate.");
            }
        }

        public void SearchByIdBooking(string idBooking, SqlConnection con)
        {
            if (string.IsNullOrEmpty(idBooking))
            {
                Console.WriteLine("ID Booking harus diisi.");
                return;
            }

            string query = "SELECT * FROM booking_jadwal WHERE Id_Booking = @idBooking";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@idBooking", idBooking);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine("Hasil Pencarian:\n");
                while (reader.Read())
                {
                    Console.WriteLine($"ID Booking: {reader["Id_Booking"]}, ID Dokter: {reader["Id_Dokter"]}, ID Pasien: {reader["Id_Pasien"]}, Tanggal: {reader["Tanggal"]}, Jam: {reader["Jam"]}");
                }
            }
            else
            {
                Console.WriteLine("Data Booking tidak ditemukan.");
            }

            reader.Close();
        }
    }
}

