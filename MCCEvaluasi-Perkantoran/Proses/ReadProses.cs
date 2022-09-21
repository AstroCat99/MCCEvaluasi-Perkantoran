using MCCEvaluasi_Perkantoran.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCCEvaluasi_Perkantoran.Proses
{
    interface IRead
    {
        public void GetAll();

        public void GetById(int id);
    }

}
