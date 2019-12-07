using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Models
{
    public class Uqituvchi
    {
        public int Id { get; set; }
        public string Familiyasi { get; set; }
        public string Ismi { get; set; }
        public string Sharifi { get; set; }
        public string Pasport { get; set; }
        public string Email { get; set; }
        public string Parol { get; set; }
        public string Rasm { get; set; }
        public virtual IEnumerable<Jurnal> Jurnals { get; set; }
        public virtual IEnumerable<JurnalVaqti> JurnalVaqtis { get; set; }
        public virtual IEnumerable<UqituvFan> UqituvFans { get; set; }
    }
}
