using Domains.Models;
using Repository.Context;
using Repository.Interfaces;
using Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class ItemColorsRepository : Repository<ItemColors>, IItemColorRepository
    {
        private MyKidsStoreDbContext _context;
        public ItemColorsRepository(MyKidsStoreDbContext context) : base(context)
        {
            _context = context;
        }
    }

}

