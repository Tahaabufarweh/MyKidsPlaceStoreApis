using Domains.Models;
using Repository.Context;
using Repository.Interfaces;
using Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class ColorRepository : Repository<Colour>, IColorRepository
    {
        private MyKidsStoreDbContext _context;
        public ColorRepository(MyKidsStoreDbContext context) : base(context)
        {
            _context = context;
        }
    }
  
}
