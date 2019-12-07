using StudenUzMu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.ViewModel
{
    public class YonalishViewModel
    {
        public Yonalish Yonalish { get; set; }
        public IEnumerable<Fakultet> Fakultet { get; set; }
    }
}
