using Microsoft.EntityFrameworkCore;
using StudenUzMu.Interfaces;
using StudenUzMu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Repository
{
    public class UquvchiRepository : Repository<Uquvchi>, IUquvchiRepository
    {
        public UquvchiRepository(DataContext context) : base(context)
        {
        }

        public IEnumerable<Uquvchi> GetAllWithFakultet()
        {
            return _context.Uquvchi.Include(a=>a.Yonalish).Include(a => a.Fakultet);
        }
    }
}
