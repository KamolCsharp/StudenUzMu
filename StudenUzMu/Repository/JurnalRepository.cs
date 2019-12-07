using Microsoft.EntityFrameworkCore;
using StudenUzMu.Interfaces;
using StudenUzMu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Repository
{
    public class JurnalRepository:Repository<Jurnal>,IJurnalRepository 
    {
        public JurnalRepository(DataContext context):base(context)
        {

        }
        public IEnumerable<Jurnal> GetAllWithALL()
        {
            return _context.Jurnal
               .Include(a => a.Fanlar)
               .Include(a => a.Uqituvchi)
               .Include(a => a.Uquvchi);
        }
    }
}
