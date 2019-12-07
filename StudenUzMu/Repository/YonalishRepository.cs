using Microsoft.EntityFrameworkCore;
using StudenUzMu.Interfaces;
using StudenUzMu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Repository
{
    public class YonalishRepository : Repository<Yonalish>, IYonalishRepository
    {
        public YonalishRepository(DataContext context):base(context)
        {

        }
        public IEnumerable<Yonalish> GetAllWithFakultet()
        {
            return _context.Yonalish.Include(a => a.Fakultet);
        }
    }
}
