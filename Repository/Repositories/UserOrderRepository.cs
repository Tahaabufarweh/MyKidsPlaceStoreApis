using Domains.Models;
using Repository.Context;
using Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class UserOrderRepository : Repository<UserOrder>, IUserOrderRepository
    {
        private MyKidsStoreDbContext _context;
        public UserOrderRepository(MyKidsStoreDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
