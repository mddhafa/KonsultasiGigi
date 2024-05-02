using System;
using System.Data;
using System.Data.SqlClient;

namespace KonsultasiGigi
{
    internal class Admindrg
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
                            Console.WriteLine("A. Melihat Seluruh Data Dokter");
                            Console.WriteLine("B. Melihat Seluruh Data Pasien");
                            Console.WriteLine("C. Melihat Seluruh Data Admin");
                            Console.WriteLine("D. Tambah Data Dokter");
                            Console.WriteLine("E. Hapus Data Dokter");
                            Console.WriteLine("F. Edit Data Dokter");
                            Console.WriteLine("G. Cari Data Dokter");
                            Console.WriteLine("H. Tambah Data Pasien");
                            Console.WriteLine("I. Hapus Data Pasien");
                            Console.WriteLine("J. Edit Data Pasien");
                            Console.WriteLine("K. Cari Data Pasien");
                            Console.WriteLine("L. Tambah Data Admin");
                            Console.WriteLine("M. Hapus Data Admin");
                            Console.WriteLine("N. Edit Data Admin");
                            Console.WriteLine("O. Cari Data Admin");
                            Console.WriteLine("P. Lihat Jadwal Konsul");
                            Console.WriteLine("Q. Keluar");
                            Console.WriteLine("\n Enter your choice (A-Q): ");
                            char ch = Convert.ToChar(Console.ReadLine());
                            switch (ch)
                            {
                                //Lihat Data//
                                case 'A':
                                    Console.Clear();
                                    Console.WriteLine("Data Dokter\n");
                                    Console.WriteLine();
                                    ReadData(conn);
                                    break;
                                case 'B':
                                    Console.Clear();
                                    Console.WriteLine("Data Pasien\n");
                                    Console.WriteLine();
                                    LihatData(conn);
                                    break;
                                case 'C':
                                    Console.Clear();
                                    Console.WriteLine("Data Admin\n");
                                    Console.WriteLine();
                                    BacaData(conn);
                                    break;
                                //Kelola Data Dokter
                                case 'D':
                                    Console.Clear();
                                    Console.WriteLine("Input Data Dokter\n");
                                    Console.WriteLine("Masukkan Id Dokter : ");
                                    string idDokter = Console.ReadLine();
                                    Console.WriteLine("Masukkan Nama Dokter : ");
                                    string namaDokter = Console.ReadLine();
                                    Console.WriteLine("Masukkan Jenis Kelamin Dokter : ");
                                    string jenisKelaminDokter = Console.ReadLine();
                                    Console.WriteLine("Masukkan Email Dokter : ");
                                    string emailDokter = Console.ReadLine();
                                    Console.WriteLine("Masukkan Password Dokter : ");
                                    string passwordDokter = Console.ReadLine();
                                    Console.WriteLine("Masukkan Nomor HP Dokter : ");
                                    string noHpDokter = Console.ReadLine();
                                    Console.WriteLine("Masukkan Alamat Dokter : ");
                                    string alamatDokter = Console.ReadLine();
                                    try
                                    {
                                        InsertDatadrg(idDokter, namaDokter, jenisKelaminDokter, emailDokter, passwordDokter, noHpDokter, alamatDokter, conn);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("\nAnda tidak memiliki " +
                                            "akses untuk menambah data");
                                    }
                                    break;
                                case 'E':
                                    Console.Clear();
                                    Console.WriteLine("Masukkan ID Dokter ingin dihapus:\n");
                                    string idDokterHapus = Console.ReadLine();
                                    try
                                    {
                                        DeleteDatadrg(idDokterHapus, conn);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("\nAnda tidak memiliki " +
                                            "akses untuk menghapus data atau data yang anda masukkan salah");
                                    }
                                    break;
                                case 'F':
                                    Console.Clear();
                                    Console.WriteLine("Update Data Dokter\n");
                                    Console.WriteLine("Masukkan ID Dokter: ");
                                    string idDokterToUpdate = Console.ReadLine();
                                    Console.WriteLine("Masukkan Nama Dokter Baru : ");
                                    string newNamaDokter = Console.ReadLine();
                                    Console.WriteLine("Masukkan Jenis Kelamin Dokter Baru : ");
                                    string newJenisKelaminDokter = Console.ReadLine();
                                    Console.WriteLine("Masukkan Email Dokter Baru : ");
                                    string newEmailDokter = Console.ReadLine();
                                    Console.WriteLine("Masukkan Password Dokter Baru : ");
                                    string newPasswordDokter = Console.ReadLine();
                                    Console.WriteLine("Masukkan Nomor HP Dokter Baru : ");
                                    string newNoHpDokter = Console.ReadLine();
                                    Console.WriteLine("Masukkan Alamat Dokter Baru : ");
                                    string newAlamatDokter = Console.ReadLine();
                                    try
                                    {
                                        UpdateDatadrg(idDokterToUpdate, newNamaDokter, newJenisKelaminDokter, newEmailDokter, newPasswordDokter, newNoHpDokter, newAlamatDokter, conn);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("\nAnda tidak memiliki akses untuk mengubah data atau data yang anda masukkan salah");
                                    }
                                    break;
                                case 'G':
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

                                //Kelola Data Pasien//
                                case 'H':
                                    Console.Clear();
                                    Console.WriteLine("Input Data Pasien\n");
                                    Console.WriteLine("Masukkan Id Pasien : ");
                                    string idPasien = Console.ReadLine();
                                    Console.WriteLine("Masukkan Nama Pasien : ");
                                    string namaPasien = Console.ReadLine();
                                    Console.WriteLine("Masukkan Jenis Kelamin Pasien : ");
                                    string jenisKelaminPasien = Console.ReadLine();
                                    Console.WriteLine("Masukkan Email Pasien : ");
                                    string emailPasien = Console.ReadLine();
                                    Console.WriteLine("Masukkan Password Pasien : ");
                                    string passwordPasien = Console.ReadLine();
                                    Console.WriteLine("Masukkan Nomor HP Pasien : ");
                                    string noHpPasien = Console.ReadLine();
                                    Console.WriteLine("Masukkan Alamat Pasien : ");
                                    string alamatPasien = Console.ReadLine();
                                    try
                                    {
                                        InsertDatapsn(idPasien, namaPasien, jenisKelaminPasien, emailPasien, passwordPasien, noHpPasien, alamatPasien, conn);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("\nAnda tidak memiliki " +
                                            "akses untuk menambah data");
                                    }
                                    break;
                                case 'I':
                                    Console.Clear();
                                    Console.WriteLine("Masukkan ID Pasien ingin dihapus:\n");
                                    string idPasienHapus = Console.ReadLine();
                                    try
                                    {
                                        DeleteDatapsn(idPasienHapus, conn);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("\nAnda tidak memiliki " +
                                            "akses untuk menghapus data atau data yang anda masukkan salah");
                                    }
                                    break;
                                case 'J':
                                    Console.Clear();
                                    Console.WriteLine("Update Data Pasien\n");
                                    Console.WriteLine("Masukkan ID Pasien yang akan diupdate: ");
                                    string idPasienToUpdate = Console.ReadLine();
                                    Console.WriteLine("Masukkan data baru:\n");
                                    Console.WriteLine("Masukkan Nama Pasien Baru : ");
                                    string newNamaPasien = Console.ReadLine();
                                    Console.WriteLine("Masukkan Jenis Kelamin Pasien Baru : ");
                                    string newJenisKelaminPasien = Console.ReadLine();
                                    Console.WriteLine("Masukkan Email Pasien Baru : ");
                                    string newEmailPasien = Console.ReadLine();
                                    Console.WriteLine("Masukkan Password Pasien Baru : ");
                                    string newPasswordPasien = Console.ReadLine();
                                    Console.WriteLine("Masukkan Nomor HP Pasien Baru : ");
                                    string newNoHpPasien = Console.ReadLine();
                                    Console.WriteLine("Masukkan Alamat Pasien Baru : ");
                                    string newAlamatPasien = Console.ReadLine();
                                    try
                                    {
                                        UpdateDatapsn(idPasienToUpdate, newNamaPasien, newJenisKelaminPasien, newEmailPasien, newPasswordPasien, newNoHpPasien, newAlamatPasien, conn);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("\nAnda tidak memiliki akses untuk mengubah data atau data yang anda masukkan salah");
                                    }
                                    break;
                                case 'K':
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

                                //Kelola Data Admin//
                                case 'L':
                                    Console.Clear();
                                    Console.WriteLine("Input Data Admin\n");
                                    Console.WriteLine("Masukkan Id Admin : ");
                                    string idAdmin = Console.ReadLine();
                                    Console.WriteLine("Masukkan Nama Admin : ");
                                    string namaAdmin = Console.ReadLine();
                                    Console.WriteLine("Masukkan Email Admin : ");
                                    string emailAdmin = Console.ReadLine();
                                    Console.WriteLine("Masukkan Password Admin : ");
                                    string passwordAdmin = Console.ReadLine();
                                    try
                                    {
                                        InsertDataadm(idAdmin, namaAdmin, emailAdmin, passwordAdmin, conn);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("\nAnda tidak memiliki " +
                                            "akses untuk menambah data");
                                    }
                                    break;
                                case 'M':
                                    Console.Clear();
                                    Console.WriteLine("Masukkan ID Admin ingin dihapus:\n");
                                    string idAdminHapus = Console.ReadLine();
                                    try
                                    {
                                        DeleteDataadm(idAdminHapus, conn);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("\nAnda tidak memiliki " +
                                            "akses untuk menghapus data atau data yang anda masukkan salah");
                                    }
                                    break;
                                case 'N':
                                    Console.Clear();
                                    Console.WriteLine("Update Data Admin\n");
                                    Console.WriteLine("Masukkan ID Admin yang akan diupdate: ");
                                    string idAdminToUpdate = Console.ReadLine();
                                    Console.WriteLine("Masukkan data baru:\n");
                                    Console.WriteLine("Masukkan Nama Admin Baru : ");
                                    string newNamaAdmin = Console.ReadLine();
                                    Console.WriteLine("Masukkan Email Admin Baru : ");
                                    string newEmailAdmin = Console.ReadLine();
                                    Console.WriteLine("Masukkan Password Admin Baru : ");
                                    string newPasswordAdmin = Console.ReadLine();
                                    try
                                    {
                                        UpdateDataadm(idAdminToUpdate, newNamaAdmin, newEmailAdmin, newPasswordAdmin, conn);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("\nAnda tidak memiliki akses untuk mengubah data atau data yang anda masukkan salah");
                                    }
                                    break;
                                case 'O':
                                    Console.Clear();
                                    Console.WriteLine("Cari Data Admin Berdasarkan ID Admin\n");
                                    Console.WriteLine("Masukkan ID Admin yang ingin dicari: ");
                                    string searchIdAdmin = Console.ReadLine();
                                    try
                                    {
                                        SearchByIdAdmin(searchIdAdmin, conn);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("\nTerjadi kesalahan dalam pencarian data: " + e.Message);
                                    }
                                    break;
                                case 'P':
                                    BookingJadwal bookingJadwal = new BookingJadwal();
                                    bookingJadwal.Main();
                                    break;
                                case 'Q':
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

        //lihat data Dokter, Pasien, Admin//
        public void ReadData(SqlConnection con)
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

        public void LihatData(SqlConnection con)
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

        public void BacaData(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Admindrg", con);
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

        //kelola data dokter// 
        public void InsertDatadrg(string idDokter, string namaDokter, string jenisKelaminDokter, string emailDokter, string passwordDokter, string noHpDokter, string alamatDokter, SqlConnection conn)
        {
            if (string.IsNullOrEmpty(idDokter) || string.IsNullOrEmpty(namaDokter) || string.IsNullOrEmpty(jenisKelaminDokter) || string.IsNullOrEmpty(emailDokter) || string.IsNullOrEmpty(passwordDokter) || string.IsNullOrEmpty(noHpDokter) || string.IsNullOrEmpty(alamatDokter))
            {
                Console.WriteLine("Data Dokter harus diisi atau harus sesuai.");
                return;
            }
            string str = "INSERT INTO dokter (Id_Dokter, Nama_Dokter, Jenis_Kelamin, Email, Password_dokter, No_HP, Alamat)" +
                "VALUES (@idDokter, @namaDokter, @jenisKelaminDokter, @emailDokter, @passwordDokter, @noHpDokter, @alamatDokter)";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@idDokter", idDokter);
            cmd.Parameters.AddWithValue("@namaDokter", namaDokter);
            cmd.Parameters.AddWithValue("@jenisKelaminDokter", jenisKelaminDokter);
            cmd.Parameters.AddWithValue("@emailDokter", emailDokter);
            cmd.Parameters.AddWithValue("@passwordDokter", passwordDokter);
            cmd.Parameters.AddWithValue("@noHpDokter", noHpDokter);
            cmd.Parameters.AddWithValue("@alamatDokter", alamatDokter);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Dokter Berhasil Ditambahkan");
        }

        public void DeleteDatadrg(string idDokter, SqlConnection con)
        {
            if (string.IsNullOrEmpty(idDokter))
            {
                Console.WriteLine("Data Dokter harus diisi atau harus sesuai.");
                return;
            }
            string str = "DELETE FROM dokter WHERE Id_Dokter = @idDokter";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@idDokter", idDokter);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Dokter Berhasil Dihapus");
        }

        public void UpdateDatadrg(string idDokter, string newNamaDokter, string newJenisKelaminDokter, string newEmailDokter, string newPasswordDokter, string newNoHpDokter, string newAlamatDokter, SqlConnection con)
        {
            if (string.IsNullOrEmpty(idDokter) || string.IsNullOrEmpty(newNamaDokter) || string.IsNullOrEmpty(newJenisKelaminDokter) || string.IsNullOrEmpty(newEmailDokter) || string.IsNullOrEmpty(newPasswordDokter) || string.IsNullOrEmpty(newNoHpDokter) || string.IsNullOrEmpty(newAlamatDokter))
            {
                Console.WriteLine("Data Dokter harus diisi atau harus sesuai.");
                return;
            }
            string str = "UPDATE dokter SET Nama_Dokter = @newNamaDokter, Jenis_Kelamin = @newJenisKelaminDokter, Email = @newEmailDokter, Password = @newPasswordDokter, No_HP = @newNoHpDokter, Alamat = @newAlamatDokter WHERE Id_Dokter = @idDokter";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@newNamaDokter", newNamaDokter);
            cmd.Parameters.AddWithValue("@newJenisKelaminDokter", newJenisKelaminDokter);
            cmd.Parameters.AddWithValue("@newEmailDokter", newEmailDokter);
            cmd.Parameters.AddWithValue("@newPasswordDokter", newPasswordDokter);
            cmd.Parameters.AddWithValue("@newNoHpDokter", newNoHpDokter);
            cmd.Parameters.AddWithValue("@newAlamatDokter", newAlamatDokter);
            cmd.Parameters.AddWithValue("@idDokter", idDokter);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Data Dokter Berhasil diupdate.");
            }
            else
            {
                Console.WriteLine("Data Dokter tidak ditemukan atau gagal diupdate.");
            }
        }

        public void SearchByIdDokter(string idDokter, SqlConnection con)
        {
            if (string.IsNullOrEmpty(idDokter))
            {
                Console.WriteLine("Data Dokter harus diisi atau harus sesuai.");
                return;
            }
            string query = "SELECT * FROM Dokter WHERE Id_Dokter = @idDokter";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@idDokter", idDokter);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine("Hasil Pencarian:\n");
                while (reader.Read())
                {
                    Console.WriteLine($"ID Dokter: {reader["Id_Dokter"]}, Nama Dokter: {reader["Nama_Dokter"]}, Jenis Kelamin: {reader["Jenis_Kelamin"]}, Email: {reader["Email"]}, Password: {reader["Password_dokter"]} No. HP: {reader["No_HP"]}, Alamat: {reader["Alamat"]}");
                }
            }
            else
            {
                Console.WriteLine("Data Dokter tidak ditemukan.");
            }

            reader.Close();
        }

        //Kelola Data Pasien//
        public void InsertDatapsn(string idPasien, string namaPasien, string jenisKelaminPasien, string emailPasien, string passwordPasien, string noHpPasien, string alamatPasien, SqlConnection conn)
        {

            if (string.IsNullOrEmpty(idPasien) || string.IsNullOrEmpty(namaPasien) || string.IsNullOrEmpty(jenisKelaminPasien) || string.IsNullOrEmpty(emailPasien) || string.IsNullOrEmpty(passwordPasien) || string.IsNullOrEmpty(noHpPasien) || string.IsNullOrEmpty(alamatPasien))
            {
                Console.WriteLine("Data Dokter harus diisi atau harus sesuai.");
                return;
            }
            string str = "INSERT INTO pasien (Id_Pasien, Nama_Pasien, Jenis_Kelamin, Email, Password_pasien, No_HP, Alamat)" +
                "VALUES (@idPasien, @namaPasien, @jenisKelaminPasien, @emailPasien, @passwordPasien @noHpPasien, @alamatPasien)";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@idPasien", idPasien);
            cmd.Parameters.AddWithValue("@namaPasien", namaPasien);
            cmd.Parameters.AddWithValue("@jenisKelaminPasien", jenisKelaminPasien);
            cmd.Parameters.AddWithValue("@emailPasien", emailPasien);
            cmd.Parameters.AddWithValue("@passwordPasien", passwordPasien);
            cmd.Parameters.AddWithValue("@noHpPasien", noHpPasien);
            cmd.Parameters.AddWithValue("@alamatPasien", alamatPasien);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Pasien Berhasil Ditambahkan");
        }

        public void DeleteDatapsn(string idPasien, SqlConnection con)
        {
            if (string.IsNullOrEmpty(idPasien))
            {
                Console.WriteLine("Data Dokter harus diisi atau harus sesuai.");
                return;
            }

            string str = "DELETE FROM pasien WHERE Id_Pasien = @idPasien";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@idPasien", idPasien);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Pasien Berhasil Dihapus");
        }

        public void UpdateDatapsn(string idPasien, string newNamaPasien, string newJenisKelaminPasien, string newEmailPasien, string newPasswordPasien, string newNoHpPasien, string newAlamatPasien, SqlConnection con)
        {

            if (string.IsNullOrEmpty(idPasien) || string.IsNullOrEmpty(newNamaPasien) || string.IsNullOrEmpty(newJenisKelaminPasien) || string.IsNullOrEmpty(newEmailPasien) || string.IsNullOrEmpty(newPasswordPasien) || string.IsNullOrEmpty(newNoHpPasien) || string.IsNullOrEmpty(newAlamatPasien))
            {
                Console.WriteLine("Data Dokter harus diisi atau harus sesuai.");
                return;
            }
            string str = "UPDATE pasien SET Nama_Pasien = @newNamaPasien, Jenis_Kelamin = @newJenisKelaminPasien, Email = @newEmailPasien, Password_pasien = @newPassworPasien, No_HP = @newNoHpPasien, Alamat = @newAlamatPasien WHERE Id_Pasien = @idPasien";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@newNamaPasien", newNamaPasien);
            cmd.Parameters.AddWithValue("@newJenisKelaminPasien", newJenisKelaminPasien);
            cmd.Parameters.AddWithValue("@newEmailPasien", newEmailPasien);
            cmd.Parameters.AddWithValue("@newPassworPasien", newPasswordPasien);
            cmd.Parameters.AddWithValue("@newNoHpPasien", newNoHpPasien);
            cmd.Parameters.AddWithValue("@newAlamatPasien", newAlamatPasien);
            cmd.Parameters.AddWithValue("@idPasien", idPasien);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Data Pasien Berhasil diupdate.");
            }
            else
            {
                Console.WriteLine("Data Pasien tidak ditemukan atau gagal diupdate.");
            }
        }

        public void SearchByIdPasien(string idPasien, SqlConnection con)
        {
            if (string.IsNullOrEmpty(idPasien))
            {
                Console.WriteLine("Data Dokter harus diisi atau harus sesuai.");
                return;
            }

            string query = "SELECT * FROM pasien WHERE Id_Pasien = @idPasien";
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


        //Kelola Data admin//
        public void InsertDataadm(string idAdmin, string namaAdmin, string emailAdmin, string passwordAdmin, SqlConnection conn)
        {
            if (string.IsNullOrEmpty(idAdmin) || string.IsNullOrEmpty(idAdmin) || string.IsNullOrEmpty (namaAdmin) || string.IsNullOrEmpty (emailAdmin) || string.IsNullOrEmpty (passwordAdmin))
            {
                Console.WriteLine("Data Dokter harus diisi atau harus sesuai.");
                return;
            }
            string str = "INSERT INTO Admindrg (Id_Admin, Nama_Admin, Email, Password_admin)" +
                "VALUES (@idAdmin, @namaAdmin, @emailAdmin, @passwordAdmin)";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@idAdmin", idAdmin);
            cmd.Parameters.AddWithValue("@namaAdmin", namaAdmin);
            cmd.Parameters.AddWithValue("@emailAdmin", emailAdmin);
            cmd.Parameters.AddWithValue("@passwordAdmin", passwordAdmin);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Admin Berhasil Ditambahkan");
        }

        public void DeleteDataadm(string idAdmin, SqlConnection con)
        {
            if (string.IsNullOrEmpty(idAdmin))
            {
                Console.WriteLine("Data Dokter harus diisi atau harus sesuai.");
                return;
            }

            string str = "DELETE FROM Admindrg WHERE Id_Admin = @idAdmin";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@idAdmin", idAdmin);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Admin Berhasil Dihapus");
        }

        public void UpdateDataadm(string idAdmin, string newNamaAdmin, string newEmailAdmin, string newPasswordAdmin, SqlConnection con)
        {
            if (string.IsNullOrEmpty(idAdmin) ||string.IsNullOrEmpty (newNamaAdmin) || string.IsNullOrEmpty(newEmailAdmin) || string.IsNullOrEmpty(newPasswordAdmin))
            {
                Console.WriteLine("Data Dokter harus diisi atau harus sesuai.");
                return;
            }

            string str = "UPDATE Admindrg SET Nama_Admin = @newNamaAdmin, Email = @newEmailAdmin, Password_admin = @newPasswordAdmin WHERE Id_Admin = @idAdmin";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@newNamaAdmin", newNamaAdmin);
            cmd.Parameters.AddWithValue("@newEmailAdmin", newEmailAdmin);
            cmd.Parameters.AddWithValue("@newPasswordAdmin", newPasswordAdmin);
            cmd.Parameters.AddWithValue("@idAdmin", idAdmin);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Data Admin Berhasil diupdate.");
            }
            else
            {
                Console.WriteLine("Data Admin tidak ditemukan atau gagal diupdate.");
            }
        }

        public void SearchByIdAdmin(string idAdmin, SqlConnection con)
        {
            if (string.IsNullOrEmpty(idAdmin))
            {
                Console.WriteLine("Data Dokter harus diisi atau harus sesuai.");
                return;
            }

            string query = "SELECT * FROM Admindrg WHERE Id_Admin = @idAdmin";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@idAdmin", idAdmin);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine("Hasil Pencarian:\n");
                while (reader.Read())
                {
                    Console.WriteLine($"ID Admin: {reader["Id_Admin"]}, Nama Admin: {reader["Nama_Admin"]}, Email: {reader["Email"]}, Password Admin: {reader["Password_admin"]}");
                }
            }
            else
            {
                Console.WriteLine("Data Admin tidak ditemukan.");
            }

            reader.Close();
        }
    }
}
