using System;
using System.Collections.Generic;

namespace SportCenter.ViewModels
{
    public class ReportsViewModel
    {
        public List<EnCokKatilanUye> EnCokKatilanUyeler { get; set; }
        public List<EnPopulerProgram> EnPopulerProgramlar { get; set; }
        public List<AntrenorIstatistik> AntrenorIstatistikleri { get; set; }
    }

    public class EnCokKatilanUye
    {
        public int UyeId { get; set; }
        public string UyeAdi { get; set; }
        public int KatilimSayisi { get; set; }
    }

    public class EnPopulerProgram
    {
        public int ProgramId { get; set; }
        public string ProgramAdi { get; set; }
        public int KatilimSayisi { get; set; }
    }

    public class AntrenorIstatistik
    {
        public int AntrenorId { get; set; }
        public string AntrenorAdi { get; set; }
        public int ProgramSayisi { get; set; }
    }
} 