using System;
using MCCEvaluasi_Perkantoran.PIlihan;

namespace MCCEvaluasi_Perkantoran
{
    public class Program
    {
        public static void Main()
        {
            MenuUtama menu = new MenuUtama();
            menu.Tulisan();
        }


    }

    public class MenuUtama
    {
        public void Tulisan()
        {
            Console.WriteLine("Selamat Datang Pada Aplikasi Kelola Karyawan");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Kelola Data Karyawan");
            Console.WriteLine("2. Kelola Data Gaji");
            Console.WriteLine("3. Registrasi");
            Console.WriteLine("4. Exit");
            Console.WriteLine("==============================================");
            Console.Write("Masukkan pilihan Anda :  ");
            short value = Convert.ToInt16(Console.ReadLine());
            switch (value)
            {
                case 1:
                    Console.WriteLine("Pilihan : " + value);
                    PilihanKaryawan pilihanKaryawan = new PilihanKaryawan();
                    pilihanKaryawan.Menu();
                    break;
                case 2:
                    Console.WriteLine("Pilihan : " + value);
                    PilihanGaji pilihanGaji = new PilihanGaji();
                    pilihanGaji.Menu();
                    break;
                case 3:
                    Console.WriteLine("Pilihan : " + value);
                    PilihanRegistrasi pilihanRegistrasi = new PilihanRegistrasi();
                    pilihanRegistrasi.Menu();
                    break;
                case 4:
                    Console.WriteLine("Pilihan : " + value);
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("nilai tidak diketahui");
                    break;
            }
        }
    }
    
}
