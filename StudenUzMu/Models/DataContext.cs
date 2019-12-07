using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
       : base(options) { }
        public DbSet<Uquvchi> Uquvchi { get; set; }
        public DbSet<Uqituvchi> Uqituvchi { get; set; }
        public DbSet<Fakultet> Fakultet { get; set; }
        public DbSet<Fanlar> Fanlar { get; set; }
        public DbSet<Yonalish> Yonalish { get; set; }
        public DbSet<Jurnal> Jurnal { get; set; }
        public DbSet<JurnalVaqti> JurnalVaqti { get; set; }
        public DbSet<UqituvFan> UqituvFan { get; set; }
    }
}
