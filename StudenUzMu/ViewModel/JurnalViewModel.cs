using StudenUzMu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.ViewModel
{
    public class JurnalViewModel
    {
        public Jurnal Jurnal { get; set; }
        public IEnumerable<Uquvchi> Uquvchis { get; set; }
        public IEnumerable<Uqituvchi> Uqituvchis { get; set; }
        public IEnumerable<Fakultet> Fakultets { get; set; }
        public IEnumerable<Yonalish> Yonalishes { get; set; }
        public IEnumerable<Fanlar> Fanlars { get; set; }
    }
}
