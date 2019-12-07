using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Models
{
    public class Jurnal
    {
        public int Id { get; set; }
        public int UquvchiId { get; set; }
        public virtual Uquvchi Uquvchi { get; set; }
        [Display(Name = "Sem")]
        public int Semister { get; set; }
        public int FanlarId { get; set; }
        public virtual Fanlar Fanlar { get; set; }
        public int Joriy { get; set; }
        public int Oraliq_1 { get; set; }
        public int Oraliq_2 { get; set; }
        public int Yakuniy { get; set; }
        public int Jami { get; set; }
        public int Reting { get; set; }
        public int Baxo { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Sana { get; set; }
        public int UqituvchiId { get; set; }
        public virtual Uqituvchi Uqituvchi { get; set; }
        [Display(Name = "G_nomer")]
        public int Guruh_nomeri { get; set; }
        public int Kursi { get; set; }
    }
}
