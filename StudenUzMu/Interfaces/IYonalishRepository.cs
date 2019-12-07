﻿using StudenUzMu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Interfaces
{
    public interface IYonalishRepository:IRepository<Yonalish>
    {
        IEnumerable<Yonalish> GetAllWithFakultet();
    }
}
