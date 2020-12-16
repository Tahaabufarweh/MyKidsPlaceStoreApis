using Domains.Models;
using Repository.Context;
using Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class MasterCategoryRepository : Repository<MasterCategory>, IMasterCategoryRepository
    {
        private MyKidsStoreDbContext _context;
        public MasterCategoryRepository(MyKidsStoreDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
