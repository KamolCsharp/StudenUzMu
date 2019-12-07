using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Models
{
    public class Uquvchi
    {
        public int UquvchiId { get; set; }
        public string Familiyasi { get; set; }
        public string Ismi { get; set; }
        public string Sharifi { get; set; }
        public string Pasport { get; set; }
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Tugulgan_sana { get; set; }
        public string Rasmi { get; set; }
        public int FakultetId { get; set; }
        public virtual Fakultet Fakultet { get; set; }
        public string Manzil { get; set; }
        public string Parol { get; set; }
        public string Tel_raqami { get; set; }
        public bool Jinsi { get; set; }
        public string Nomer_Za { get; set; }
        public DateTime Oqishga_kirgan_yil { get; set; }
        public int Status { get; set; }
        public int YonalishId { get; set; }
        public Yonalish Yonalish { get; set; }
        public virtual IEnumerable<Jurnal> Jurnals { get; set; }

    }
}
