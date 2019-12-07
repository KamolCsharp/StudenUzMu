using Microsoft.EntityFrameworkCore;
using StudenUzMu.Interfaces;
using StudenUzMu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Repository
{
    public class UqituvFanRepository: Repository<UqituvFan>, IUqituvFanRepository 
    {
        public UqituvFanRepository(DataContext context) : base(context)
        {
        }

        public UqituvFan FindWithFan(int id)
        {
            return _context.UqituvFan.Include(a => a.Fanlar)
                .Where(a => a.UqituvchiId == id).FirstOrDefault();
        }

        public IEnumerable<UqituvFan> GetAllWith()
        {
            return _context.UqituvFan
                .Include(a => a.Uqituvchi)
                .Include(a => a.Fanlar);
        }
    }
}
