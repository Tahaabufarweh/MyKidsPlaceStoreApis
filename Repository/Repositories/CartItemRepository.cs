using Domains.Models;
using Repository.Context;
using Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        private MyKidsStoreDbContext _context;
        public CartItemRepository(MyKidsStoreDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
