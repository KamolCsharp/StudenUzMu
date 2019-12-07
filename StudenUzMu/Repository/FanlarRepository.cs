using Microsoft.EntityFrameworkCore;
using StudenUzMu.Interfaces;
using StudenUzMu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Repository
{
    public class FanlarRepository:Repository<Fanlar>,IFanlarRepository
    {
        public FanlarRepository(DataContext context):base(context)
        {
        }
    }
}
