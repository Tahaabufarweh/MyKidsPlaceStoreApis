using Domains.Models;
using Repository.Context;
using Repository.Interfaces;
using Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class OrderRepository : Repository<Orders>, IOrderRepository
    {
        private MyKidsStoreDbContext _context;
        public OrderRepository(MyKidsStoreDbContext context) : base(context)
        {
            _context = context;
        }
    }

}


