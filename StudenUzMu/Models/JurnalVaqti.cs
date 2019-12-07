using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Models
{
    public class JurnalVaqti
    {
        public int Id { get; set; }
        public int UqituvchiId { get; set; }
        public Uqituvchi Uqituvchi { get; set; }
        public int FanlarId { get; set; }
        public Fanlar Fanlar { get; set; }
        public DateTime Joriy_B { get; set; }
        public DateTime Joriy_T { get; set; }
        public DateTime Oraliq_1_B { get; set; }
        public DateTime Oraliq_1_T { get; set; }
        public DateTime Oraliq_2_B { get; set; }
        public DateTime Oraliq_2_T { get; set; }
        public DateTime Yakuniy_B { get; set; }
        public DateTime Yakuniy_T { get; set; }
        public int Semister { get; set; }
        public int FakultetId { get; set; }
        public Fakultet Fakultet { get; set; }
        public int Kurs { get; set; }
        public int Guruh_nomer { get; set; }
        public int YonalishId { get; set; }
        public Yonalish Yonalish { get; set; }
    }
}
