using MCCEvaluasi_Perkantoran.Models;
using MCCEvaluasi_Perkantoran.Proses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MCCEvaluasi_Perkantoran.PIlihan
{
    public class PilihanGaji : IRead
    {
        SqlConnection conn;
        string connectionString = "Data Source=DESKTOP-V48IK6S; Initial Catalog=Penggajian; " +
            "User ID=mccdts;Password=mccdts;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static string[] arrString = new string[6] { "Id Gaji", "Gaji Pokok", "Tunjangan Jabatan", "Uang Akomodasi", "Nama Bank", "Rekening" };

        public void ProsesInput() {
            string[] arrayGaji = new string[6];
                for (int i = 0; i < arrString.Length; i++)
                {

                    Console.Write(arrString[i] + " :  ");
                    string isi = Console.ReadLine();
                    arrayGaji[i] = isi;
                }
                PilihanGaji pilihanGaji = new PilihanGaji();
                pilihanGaji.ProsesInputData(arrayGaji);
                
        }

        public void ProsesInputData(string [] arrayGaji) {
            PilihanGaji pilihanGaji = new PilihanGaji();
            Gaji gaji = new Gaji()
            {
                Id = int.Parse(arrayGaji[0]),
                Pokok = int.Parse(arrayGaji[1]),
                Tunjangan = int.Parse(arrayGaji[2]),
                Akomodasi = int.Parse(arrayGaji[3]),
                Bank = arrayGaji[4],
                Rekening = arrayGaji[5]
            };
                pilihanGaji.Insert(gaji);
        }

        public void ProsesEdit()
        {
            string[] arrayGaji = new string[6];
            for (int i = 0; i < arrString.Length; i++)
            {

                Console.Write(arrString[i] + " :  ");
                string isi = Console.ReadLine();
                arrayGaji[i] = isi;
            }
            PilihanGaji pilihanGaji = new PilihanGaji();
            pilihanGaji.ProsesEditData(arrayGaji);

        }

        public void ProsesEditData(string[] arrayGaji)
        {
            PilihanGaji pilihanGaji = new PilihanGaji();
            Gaji gaji = new Gaji()
            {
                Id = int.Parse(arrayGaji[0]),
                Pokok = int.Parse(arrayGaji[1]),
                Tunjangan = int.Parse(arrayGaji[2]),
                Akomodasi = int.Parse(arrayGaji[3]),
                Bank = arrayGaji[4],
                Rekening = arrayGaji[5]
            };
            pilihanGaji.Update(gaji);
        }

        public void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Pilihan Kelola Gaji");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Lihat Data Gaji");
            Console.WriteLine("2. Lihat Data Gaji Berdasarkan Id");
            Console.WriteLine("3. Tambah Data Gaji Baru");
            Console.WriteLine("4. Update Data Gaji");
            Console.WriteLine("5. Hapus Data Gaji");
            Console.WriteLine("6. Menu Utama");
            Console.WriteLine("==============================================");
            Console.Write("Masukkan pilihan Anda :  ");
            PilihanGaji pilihanGaji = new PilihanGaji();
            int value = Convert.ToInt32(Console.ReadLine());
            switch (value)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Pilihan : " + value);
                    pilihanGaji.GetAll();
                    Console.WriteLine();
                    pilihanGaji.Menu();
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Pilihan : " + value);
                    Console.Write("Masukkan Id :  ");
                    short id = Convert.ToInt16(Console.ReadLine());
                    pilihanGaji.GetById(id);
                    Console.WriteLine();
                    pilihanGaji.Menu();
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("Pilihan : " + value);
                    Console.WriteLine();
                    Console.WriteLine("Masukkan data yang akan ditambah");
                    pilihanGaji.ProsesInput();
                    Console.WriteLine();
                    pilihanGaji.GetAll();
                    Console.WriteLine();
                    pilihanGaji.Menu();
                    break;
                case 4:
                    Console.WriteLine();
                    Console.WriteLine("Pilihan : " + value);
                    pilihanGaji.GetAll();
                    Console.WriteLine();
                    Console.WriteLine("Masukkan data yang akan dirubah");
                    pilihanGaji.ProsesEdit();
                    Console.WriteLine();
                    pilihanGaji.GetAll();
                    Console.WriteLine();
                    pilihanGaji.Menu();
                    break;
                case 5:
                    Console.WriteLine();
                    Console.WriteLine("Pilihan : " + value);
                    pilihanGaji.GetAll();
                    Console.WriteLine();
                    Console.Write("Masukkan id dari data yang akan dihapus : ");
                    short idHapus = Convert.ToInt16(Console.ReadLine());
                    pilihanGaji.Delete(idHapus);
                    Console.WriteLine();
                    pilihanGaji.GetAll();
                    Console.WriteLine();
                    pilihanGaji.Menu();
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

        public void GetById(int id)
        {
            string query = "SELECT * FROM Gaji WHERE Id_Gaji = @id";

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

        void Insert(Gaji gaji)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@id";
                sqlParameter1.Value = gaji.Id;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@pokok";
                sqlParameter2.Value = gaji.Pokok;

                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@tunjangan";
                sqlParameter3.Value = gaji.Tunjangan;

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@akomodasi";
                sqlParameter4.Value = gaji.Akomodasi;

                SqlParameter sqlParameter5 = new SqlParameter();
                sqlParameter5.ParameterName = "@bank";
                sqlParameter5.Value = gaji.Bank;

                SqlParameter sqlParameter6 = new SqlParameter();
                sqlParameter6.ParameterName = "@rekening";
                sqlParameter6.Value = gaji.Rekening;


                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);
                sqlCommand.Parameters.Add(sqlParameter5);
                sqlCommand.Parameters.Add(sqlParameter6);

                try
                {
                    sqlCommand.CommandText = "INSERT INTO Gaji " +
                        "VALUES (@id, @pokok, @tunjangan, @akomodasi, @bank, @rekening)";

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        void Update(Gaji gaji)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@id";
                sqlParameter1.Value = gaji.Id;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@pokok";
                sqlParameter2.Value = gaji.Pokok;

                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@tunjangan";
                sqlParameter3.Value = gaji.Tunjangan;

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@akomodasi";
                sqlParameter4.Value = gaji.Akomodasi;

                SqlParameter sqlParameter5 = new SqlParameter();
                sqlParameter5.ParameterName = "@bank";
                sqlParameter5.Value = gaji.Bank;

                SqlParameter sqlParameter6 = new SqlParameter();
                sqlParameter6.ParameterName = "@rekening";
                sqlParameter6.Value = gaji.Rekening;


                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);
                sqlCommand.Parameters.Add(sqlParameter5);
                sqlCommand.Parameters.Add(sqlParameter6);

                try
                {
                    sqlCommand.CommandText =
                    "UPDATE Gaji " +
                        "SET Gaji_Pokok = @pokok, Tunjangan_Jabatan = @tunjangan, Uang_Akomodasi = @akomodasi, " +
                        "Nama_Bank = @bank, No_Rekening = @rekening WHERE Id_Gaji = @id ";

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

                PilihanGaji pilihanGaji = new PilihanGaji();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@id";
                sqlParameter.Value = id;

                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.CommandText =
                    "DELETE FROM Gaji WHERE Id_Gaji = @id";

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Data tidak boleh dihapus");
                    Console.WriteLine();
                    pilihanGaji.Menu();
                }
            }
        }

    }
}
