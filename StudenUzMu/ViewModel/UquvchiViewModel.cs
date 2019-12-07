using StudenUzMu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.ViewModel
{
    public class UquvchiViewModel
    {
        public Uquvchi Uquvchi { get; set; }
        public IEnumerable<Fakultet> Fakultet { get; set; }
        public IEnumerable<Yonalish> Yonalish { get; set; }
    }
}
