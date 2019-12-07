using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Models
{
    public class Yonalish
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public int FakultetId { get; set; }
        public virtual Fakultet Fakultet { get; set; }
        public virtual IEnumerable<JurnalVaqti> JurnalVaqtis { get; set; }
        public virtual IEnumerable<Uquvchi> Uquvchis { get; set; }
    }

}
