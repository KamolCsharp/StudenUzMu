using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Models
{
    public class Fakultet
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public virtual IEnumerable<Yonalish> Yonalishes { get; set; }
        public virtual IEnumerable<JurnalVaqti> JurnalVaqtis { get; set; }
        public virtual IEnumerable<Uquvchi> Uquvchis { get; set; }
    }
}
