using Domains.Models;
using Repository.Interfaces.Common;
using Repository.UnitOfWork;
using Service.Interfaces;
using Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class CartItemService : ICartItemService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public CartItemService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public CartItem Add(CartItem entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartItem> AddRange(IEnumerable<CartItem> entities)
        {
            throw new NotImplementedException();
        }

        public CartItem Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public CartItem Remove(CartItem entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartItem> RemoveRange(IEnumerable<CartItem> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartItem> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public CartItem Update(CartItem entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartItem> UpdateRange(IEnumerable<CartItem> entities)
        {
            throw new NotImplementedException();
        }
    }
}
