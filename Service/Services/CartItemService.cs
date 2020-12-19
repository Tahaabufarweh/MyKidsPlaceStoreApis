using Domains.Models;
using Domains.SearchModels;
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
            _repositoryUnitOfWork.CartItem.Value.Add(entity);
            return entity;
        }

        public IEnumerable<CartItem> AddRange(IEnumerable<CartItem> entities)
        {
            throw new NotImplementedException();
        }

        public CartItem Get(int Id)
        {
            CartItem cartItem = _repositoryUnitOfWork.CartItem.Value.Get(Id);
            return cartItem;
        }

        public IEnumerable<CartItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CartItem> List(BaseSearch search)
        {
            List<CartItem> CartItems = _repositoryUnitOfWork.CartItem.Value.List(x=> true, search.PageSize, search.PageNumber);
            return CartItems;
        }

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.CartItem.Value.Remove(Id);
            return true;
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
            _repositoryUnitOfWork.CartItem.Value.Update(entity);
            return entity;
        }

        public IEnumerable<CartItem> UpdateRange(IEnumerable<CartItem> entities)
        {
            throw new NotImplementedException();
        }
    }
}
