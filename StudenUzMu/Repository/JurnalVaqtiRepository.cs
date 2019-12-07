using Microsoft.EntityFrameworkCore;
using StudenUzMu.Interfaces;
using StudenUzMu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Repository
{
    public class JurnalVaqtiRepository:Repository<JurnalVaqti>,IJurnalVaqtiRepository
    {
        public JurnalVaqtiRepository(DataContext context):base(context)
        {

        }
        public IEnumerable<JurnalVaqti> GetAllWithALL()
        {
            return _context.JurnalVaqti
               .Include(a => a.Fakultet)
               .Include(a => a.Yonalish)
               .Include(a => a.Fanlar)
               .Include(a => a.Uqituvchi);
        }
    }
}
