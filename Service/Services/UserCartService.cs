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
    public class UserCartService : IUserCartService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public UserCartService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public UserCart Add(UserCart entity)
        {
            _repositoryUnitOfWork.UserCart.Value.Add(entity);
            return entity;
        }


        public UserCart Update(UserCart entity)
        {
            _repositoryUnitOfWork.UserCart.Value.Update(entity);
            return entity;
        }

        public UserCart Get(int Id)
        {
            UserCart UserCart = _repositoryUnitOfWork.UserCart.Value.Get(Id);
            return UserCart;
        }

        public List<UserCart> List(BaseSearch search)
        {
            List<UserCart> UserCarts = _repositoryUnitOfWork.UserCart.Value.List(x => true, search.PageSize, search.PageNumber);
            return UserCarts;
        }

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.UserCart.Value.Remove(Id);
            return true;
        }

        public IEnumerable<UserCart> AddRange(IEnumerable<UserCart> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserCart> UpdateRange(IEnumerable<UserCart> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserCart> RemoveRange(IEnumerable<UserCart> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserCart> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserCart> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
