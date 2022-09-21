using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MCCEvaluasi_Perkantoran.Models;
using MCCEvaluasi_Perkantoran.Proses;

namespace MCCEvaluasi_Perkantoran.PIlihan
{
    public class PilihanRegistrasi : IRead
    {
        SqlConnection conn;
        string connectionString = "Data Source=DESKTOP-V48IK6S; Initial Catalog=Penggajian; " +
            "User ID=mccdts;Password=mccdts;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static string[] arrString = new string[4] { "Id Registrasi", "Id Karyawan", "Username", "Password" };

        public void ProsesInput()
        {
            string[] arrayReg = new string[4];
            for (int i = 0; i < arrString.Length; i++)
            {

                Console.Write(arrString[i] + " :  ");
                string isi = Console.ReadLine();
                arrayReg[i] = isi;
            }
            PilihanRegistrasi pilihanRegistrasi = new PilihanRegistrasi();
            pilihanRegistrasi.ProsesInputData(arrayReg);

        }

        public void ProsesInputData(string[] arrayRegistrasi)
        {
            PilihanRegistrasi pilihanRegistrasi = new PilihanRegistrasi();
            Registrasi Registrasi = new Registrasi()
            {
                id = int.Parse(arrayRegistrasi[0]),
                id_karyawan = int.Parse(arrayRegistrasi[1]),
                username = arrayRegistrasi[2],
                password = arrayRegistrasi[3]
            };
            pilihanRegistrasi.Insert(Registrasi);
        }

        public void ProsesEdit()
        {
            string[] arrayRegistrasi = new string[4];
            for (int i = 0; i < arrString.Length; i++)
            {

                Console.Write(arrString[i] + " :  ");
                string isi = Console.ReadLine();
                arrayRegistrasi[i] = isi;
            }
            PilihanRegistrasi pilihanRegistrasi = new PilihanRegistrasi();
            pilihanRegistrasi.ProsesEditData(arrayRegistrasi);

        }

        public void ProsesEditData(string[] arrayRegistrasi)
        {
            PilihanRegistrasi pilihanRegistrasi = new PilihanRegistrasi();
            Registrasi Registrasi = new Registrasi()
            {
                id = int.Parse(arrayRegistrasi[0]),
                id_karyawan = int.Parse(arrayRegistrasi[1]),
                username = arrayRegistrasi[2],
                password = arrayRegistrasi[3]
            };
            pilihanRegistrasi.Update(Registrasi);
        }

        public void Menu()
        {
            Console.WriteLine("Pilihan Kelola Registrasi");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Lihat Data Registrasi");
            Console.WriteLine("2. Lihat Data Registrasi Berdasarkan Id");
            Console.WriteLine("3. Tambah Data Registrasi Baru");
            Console.WriteLine("4. Update Data Registrasi");
            Console.WriteLine("5. Hapus Data Registrasi");
            Console.WriteLine("6. Menu Utama");
            Console.WriteLine("==============================================");
            Console.Write("Masukkan pilihan Anda :  ");
            PilihanRegistrasi pilihanRegistrasi = new PilihanRegistrasi();
            PilihanKaryawan pilihanKaryawan = new PilihanKaryawan();
            int value = Convert.ToInt32(Console.ReadLine());
            switch (value)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Pilihan : " + value);
                    pilihanRegistrasi.GetAll();
                    Console.WriteLine();
                    pilihanRegistrasi.Menu();
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Pilihan : " + value);
                    Console.Write("Masukkan Id :  ");
                    short id = Convert.ToInt16(Console.ReadLine());
                    pilihanRegistrasi.GetById(id);
                    Console.WriteLine();
                    pilihanRegistrasi.Menu();
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("Pilihan : " + value);
                    Console.WriteLine();
                    Console.WriteLine("Berikut data Karyawan yang ada");
                    pilihanKaryawan.GetAll();
                    Console.WriteLine();
                    Console.WriteLine("Masukkan data yang akan ditambah");
                    pilihanRegistrasi.ProsesInput();
                    Console.WriteLine();
                    pilihanRegistrasi.GetAll();
                    Console.WriteLine();
                    pilihanRegistrasi.Menu();
                    break;
                case 4:
                    Console.WriteLine();
                    Console.WriteLine("Pilihan : " + value);
                    pilihanRegistrasi.GetAll();
                    Console.WriteLine();
                    Console.WriteLine("Masukkan data yang akan dirubah");
                    pilihanRegistrasi.ProsesEdit();
                    Console.WriteLine();
                    pilihanRegistrasi.GetAll();
                    Console.WriteLine();
                    pilihanRegistrasi.Menu();
                    break;
                case 5:
                    Console.WriteLine();
                    Console.WriteLine("Pilihan : " + value);
                    pilihanRegistrasi.GetAll();
                    Console.WriteLine();
                    Console.Write("Masukkan id dari data yang akan dihapus : ");
                    short idHapus = Convert.ToInt16(Console.ReadLine());
                    pilihanRegistrasi.Delete(idHapus);
                    Console.WriteLine();
                    pilihanRegistrasi.GetAll();
                    Console.WriteLine();
                    pilihanRegistrasi.Menu();
                    break;
                case 6:
                    MenuUtama menu = new MenuUtama();
                    menu.Tulisan();
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("nilai tidak diketahui");
                    break;
            }
        }

        public void GetAll()
        {
            string query = "SELECT * FROM Registrasi";

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
                                + " | " + sqlDataReader[3]);
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
            string query = "SELECT * FROM Registrasi WHERE id_registrasi = @id";

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
                                + " | " + sqlDataReader[3]);
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

        void Insert(Registrasi registrasi)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@id_reg";
                sqlParameter1.Value = registrasi.id;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@id_karyawan";
                sqlParameter2.Value = registrasi.id_karyawan;

                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@username";
                sqlParameter3.Value = registrasi.username;

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@password";
                sqlParameter4.Value = registrasi.password;


                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);

                try
                {
                    sqlCommand.CommandText = "INSERT INTO Registrasi " +
                        "VALUES (@id_reg, @id_karyawan, @username, @password)";

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        void Update(Registrasi registrasi)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@id_reg";
                sqlParameter1.Value = registrasi.id;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@id_karyawan";
                sqlParameter2.Value = registrasi.id_karyawan;

                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@username";
                sqlParameter3.Value = registrasi.username;

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@password";
                sqlParameter4.Value = registrasi.password;


                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);

                try
                {
                    sqlCommand.CommandText =
                    "UPDATE Registrasi " +
                        "SET id_karyawan = @id_karyawan, username = @username, " +
                        "password = @password WHERE id_registrasi = @id_reg ";

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
                    "DELETE FROM Registrasi WHERE id_registrasi = @id";

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
