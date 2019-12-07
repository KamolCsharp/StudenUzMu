using StudenUzMu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.ViewModel
{
    public class UqituvFanViewModel
    {
        public UqituvFan UqituvFan { get; set; }
        public IEnumerable<Uqituvchi> Uqituvchis { get; set; }
        public IEnumerable<Fanlar> Fanlars { get; set; }
    }
}
