using System;
using System.Collections.Generic;
using System.Text;

namespace MCCEvaluasi_Perkantoran.Models
{
    internal class Gaji
    {
        public int Id { get; set; }
        public int Pokok { get; set; }
        public int Tunjangan { get; set; }
        public int Akomodasi { get; set; }
        public string Bank { get; set; }
        public string Rekening { get; set; }

    }
}
