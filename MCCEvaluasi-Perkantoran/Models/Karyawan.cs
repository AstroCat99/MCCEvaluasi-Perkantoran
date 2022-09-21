using System;
using System.Collections.Generic;
using System.Text;

namespace MCCEvaluasi_Perkantoran.Models
{
    public class Karyawan
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Ktp { get; set; }
        public string Telfon { get; set; }
        public int Jabatan { get; set; }
        public int Cabang { get; set; }
        public int Departemen { get; set; }
        public int Gaji { get; set; }
    }
}
