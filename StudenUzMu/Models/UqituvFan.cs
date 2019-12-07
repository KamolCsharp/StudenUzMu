using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Models
{
    public class UqituvFan
    {
        public int Id { get; set; }
        public int  UqituvchiId { get; set; }
        public Uqituvchi Uqituvchi { get; set; }
        public int FanlarId { get; set; }
        public Fanlar Fanlar { get; set; }
        public int Semister { get; set; }
    }
}
