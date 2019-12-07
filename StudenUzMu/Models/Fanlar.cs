using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Models
{
    public class Fanlar
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public virtual IEnumerable<Jurnal> Jurnals { get; set; }
        public virtual IEnumerable<JurnalVaqti> JurnalVaqtis { get; set; }
        public virtual IEnumerable<UqituvFan> UqituvFans { get; set; }
    }
}
