using MCCEvaluasi_Perkantoran.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MCCEvaluasi_Perkantoran.PIlihan
{
    public class PilihanKaryawan
    {
        SqlConnection conn;
        string connectionString = "Data Source=DESKTOP-V48IK6S; Initial Catalog=Penggajian; " +
            "User ID=mccdts;Password=mccdts;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static string[] arrString = new string[8] { "Id Karyawan", "Nama Karyawan", "No KTP", 
            "No Telepon","Id Jabatan", "Id Cabang", "Id Departemen","Id Gaji" };

        public void ProsesInput()
        {
            string[] arrayKaryawan = new string[8];
            for (int i = 0; i < arrString.Length; i++)
            {

                Console.Write(arrString[i] + " :  ");
                string isi = Console.ReadLine();
                arrayKaryawan[i] = isi;
            }
            PilihanKaryawan pilihanKaryawan = new PilihanKaryawan();
            pilihanKaryawan.ProsesInputData(arrayKaryawan);

        }

        public void ProsesInputData(string[] arrayKaryawan)
        {
            PilihanKaryawan pilihanKaryawan = new PilihanKaryawan();
            Karyawan Karyawan = new Karyawan()
            {
                Id = int.Parse(arrayKaryawan[0]),
                Nama = arrayKaryawan[1],
                Ktp = arrayKaryawan[2],
                Telfon = arrayKaryawan[3],
                Jabatan = int.Parse(arrayKaryawan[4]),
                Cabang = int.Parse(arrayKaryawan[5]),
                Departemen = int.Parse(arrayKaryawan[6]),
                Gaji = int.Parse(arrayKaryawan[7])
            };
            pilihanKaryawan.Insert(Karyawan);
        }

        public void ProsesEdit()
        {
            string[] arrayKaryawan = new string[8];
            for (int i = 0; i < arrString.Length; i++)
            {

                Console.Write(arrString[i] + " :  ");
                string isi = Console.ReadLine();
                arrayKaryawan[i] = isi;
            }
            PilihanKaryawan pilihanKaryawan = new PilihanKaryawan();
            pilihanKaryawan.ProsesEditData(arrayKaryawan);

        }

        public void ProsesEditData(string[] arrayKaryawan)
        {
            PilihanKaryawan pilihanKaryawan = new PilihanKaryawan();
            Karyawan Karyawan = new Karyawan()
            {
                Id = int.Parse(arrayKaryawan[0]),
                Nama = arrayKaryawan[1],
                Ktp = arrayKaryawan[2],
                Telfon = arrayKaryawan[3],
                Jabatan = int.Parse(arrayKaryawan[4]),
                Cabang = int.Parse(arrayKaryawan[5]),
                Departemen = int.Parse(arrayKaryawan[6]),
                Gaji = int.Parse(arrayKaryawan[7])
            };
            pilihanKaryawan.Update(Karyawan);
        }

        public void Menu()
        {
            Console.WriteLine("Pilihan Kelola Karyawan");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Lihat Data Karyawan");
            Console.WriteLine("2. Lihat Data Karyawan Berdasarkan Id");
            Console.WriteLine("3. Tambah Data Karyawan Baru");
            Console.WriteLine("4. Update Data Karyawan");
            Console.WriteLine("5. Hapus Data Karyawan");
            Console.WriteLine("6. Menu Utama");
            Console.WriteLine("==============================================");
            Console.Write("Masukkan pilihan Anda :  ");
            PilihanKaryawan pilihanKaryawan = new PilihanKaryawan();
            PilihanGaji pilihanGaji = new PilihanGaji();
            int value = Convert.ToInt32(Console.ReadLine());
            switch (value)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Pilihan : " + value);
                    pilihanKaryawan.GetAll();
                    Console.WriteLine();
                    pilihanKaryawan.Menu();
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Pilihan : " + value);
                    Console.Write("Masukkan Id :  ");
                    short id = Convert.ToInt16(Console.ReadLine());
                    pilihanKaryawan.GetById(id);
                    Console.WriteLine();
                    pilihanKaryawan.Menu();
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("Pilihan : " + value);
                    Console.WriteLine();
                    Console.WriteLine("Berikut data Karyawan yang ada");
                    pilihanKaryawan.GetAll();
                    Console.WriteLine();
                    Console.WriteLine("DATA JABATAN");
                    pilihanKaryawan.GetAllJabatan();
                    Console.WriteLine();
                    Console.WriteLine("DATA CABANG");
                    pilihanKaryawan.GetAllCabang();
                    Console.WriteLine();
                    Console.WriteLine("DATA DEPARTEMEN");
                    pilihanKaryawan.GetAllDepartemen();
                    Console.WriteLine();
                    Console.WriteLine("DATA GAJI");
                    pilihanKaryawan.GetAllGaji();
                    Console.WriteLine();
                    Console.WriteLine("Masukkan data yang akan ditambah");
                    pilihanKaryawan.ProsesInput();
                    Console.WriteLine();
                    pilihanKaryawan.GetAll();
                    Console.WriteLine();
                    pilihanKaryawan.Menu();
                    break;
                case 4:
                    Console.WriteLine();
                    Console.WriteLine("Pilihan : " + value);
                    pilihanKaryawan.GetAll();
                    Console.WriteLine();
                    Console.WriteLine("Masukkan data yang akan dirubah");
                    pilihanKaryawan.ProsesEdit();
                    Console.WriteLine();
                    pilihanKaryawan.GetAll();
                    Console.WriteLine();
                    pilihanKaryawan.Menu();
                    break;
                case 5:
                    Console.WriteLine();
                    Console.WriteLine("Pilihan : " + value);
                    pilihanKaryawan.GetAll();
                    Console.WriteLine();
                    Console.Write("Masukkan id dari data yang akan dihapus : ");
                    short idHapus = Convert.ToInt16(Console.ReadLine());
                    pilihanKaryawan.DeleteReg(idHapus);
                    pilihanKaryawan.Delete(idHapus);
                    Console.WriteLine();
                    pilihanKaryawan.GetAll();
                    Console.WriteLine();
                    pilihanKaryawan.Menu();
                    break;
                case 6:
                    MenuUtama menu = new MenuUtama();
                    menu.Tulisan();
                    break;
                default:
                    Console.WriteLine("nilai tidak diketahui");
                    break;
            }
        }

        public void GetAll()
        {
            string query = "SELECT * FROM Karyawan";

            conn = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[0] + " | " + sqlDataReader[1] + " | " + sqlDataReader[2]
                                + " | " + sqlDataReader[3] + " | " + sqlDataReader[4] + " | " + sqlDataReader[5] 
                                + " | " + sqlDataReader[6] + " | " + sqlDataReader[7]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetById(int id)
        {
            string query = "SELECT * FROM Karyawan WHERE Id_Karyawan = @id";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@id";
            sqlParameter.Value = id;

            conn = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.Add(sqlParameter);
            try
            {
                conn.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[0] + " | " + sqlDataReader[1] + " | " + sqlDataReader[2]
                               + " | " + sqlDataReader[3] + " | " + sqlDataReader[4] + " | " + sqlDataReader[5]
                               + " | " + sqlDataReader[6] + " | " + sqlDataReader[7]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetAllGaji()
        {
            string query = "SELECT * FROM Gaji";

            conn = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[0] + " | " + sqlDataReader[1] + " | " + sqlDataReader[2]
                                + " | " + sqlDataReader[3] + " | " + sqlDataReader[4] + " | " + sqlDataReader[5]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetAllJabatan()
        {
            string query = "SELECT * FROM Jabatan";

            conn = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[0] + " | " + sqlDataReader[1] + " | " + sqlDataReader[2]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetAllCabang()
        {
            string query = "SELECT * FROM Cabang";

            conn = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[0] + " | " + sqlDataReader[1] + " | " + sqlDataReader[2]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetAllDepartemen()
        {
            string query = "SELECT * FROM Departement";

            conn = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[0] + " | " + sqlDataReader[1]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void Insert(Karyawan karyawan)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@id_karyawan";
                sqlParameter1.Value = karyawan.Id;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@nama";
                sqlParameter2.Value = karyawan.Nama;

                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@ktp";
                sqlParameter3.Value = karyawan.Ktp;

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@telfon";
                sqlParameter4.Value = karyawan.Telfon;

                SqlParameter sqlParameter5 = new SqlParameter();
                sqlParameter5.ParameterName = "@jabatan";
                sqlParameter5.Value = karyawan.Jabatan;

                SqlParameter sqlParameter6 = new SqlParameter();
                sqlParameter6.ParameterName = "@cabang";
                sqlParameter6.Value = karyawan.Cabang;

                SqlParameter sqlParameter7 = new SqlParameter();
                sqlParameter7.ParameterName = "@departemen";
                sqlParameter7.Value = karyawan.Departemen;

                SqlParameter sqlParameter8 = new SqlParameter();
                sqlParameter8.ParameterName = "@gaji";
                sqlParameter8.Value = karyawan.Gaji;

                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);
                sqlCommand.Parameters.Add(sqlParameter5);
                sqlCommand.Parameters.Add(sqlParameter6);
                sqlCommand.Parameters.Add(sqlParameter7);
                sqlCommand.Parameters.Add(sqlParameter8);

                try
                {
                    sqlCommand.CommandText = "INSERT INTO Karyawan " +
                        "VALUES (@id_karyawan, @nama, @ktp, @telfon, @jabatan, @cabang," +
                        "@departemen,@gaji)";

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        void Update(Karyawan karyawan)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@id_karyawan";
                sqlParameter1.Value = karyawan.Id;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@nama";
                sqlParameter2.Value = karyawan.Nama;

                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@ktp";
                sqlParameter3.Value = karyawan.Ktp;

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@telfon";
                sqlParameter4.Value = karyawan.Telfon;

                SqlParameter sqlParameter5 = new SqlParameter();
                sqlParameter5.ParameterName = "@jabatan";
                sqlParameter5.Value = karyawan.Jabatan;

                SqlParameter sqlParameter6 = new SqlParameter();
                sqlParameter6.ParameterName = "@cabang";
                sqlParameter6.Value = karyawan.Cabang;

                SqlParameter sqlParameter7 = new SqlParameter();
                sqlParameter7.ParameterName = "@departemen";
                sqlParameter7.Value = karyawan.Departemen;

                SqlParameter sqlParameter8 = new SqlParameter();
                sqlParameter8.ParameterName = "@gaji";
                sqlParameter8.Value = karyawan.Gaji;

                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);
                sqlCommand.Parameters.Add(sqlParameter5);
                sqlCommand.Parameters.Add(sqlParameter6);
                sqlCommand.Parameters.Add(sqlParameter7);
                sqlCommand.Parameters.Add(sqlParameter8);

                try
                {
                    sqlCommand.CommandText =
                    "UPDATE Karyawan " +
                        "SET Nama_Karyawan = @nama, No_Ktp = @ktp, No_Telepon = @telfon, " +
                        "Id_Jabatan = @jabatan, Id_Cabang = @cabang, Id_Departemen = @departemen, " +
                        "Id_Gaji = @gaji WHERE Id_Karyawan = @id_karyawan ";

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        void Delete(int id)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@id";
                sqlParameter.Value = id;

                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.CommandText =
                    "DELETE FROM Karyawan WHERE Id_Karyawan = @id";

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        void DeleteReg(int id)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@id";
                sqlParameter.Value = id;

                sqlCommand.Parameters.Add(sqlParameter);

                
                try
                {
                    sqlCommand.CommandText =
                    "DELETE FROM Registrasi WHERE Id_Karyawan = @id";

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
