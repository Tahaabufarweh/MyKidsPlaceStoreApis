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
    public class UserOrderService : IUserOrderService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public UserOrderService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public UserOrder Add(UserOrder entity)
        {
            _repositoryUnitOfWork.UserOrder.Value.Add(entity);
            return entity;
        }


        public UserOrder Update(UserOrder entity)
        {
            _repositoryUnitOfWork.UserOrder.Value.Update(entity);
            return entity;
        }

        public UserOrder Get(int Id)
        {
            UserOrder UserOrder = _repositoryUnitOfWork.UserOrder.Value.Get(Id);
            return UserOrder;
        }

        public List<UserOrder> List(BaseSearch search)
        {
            List<UserOrder> UserOrders = _repositoryUnitOfWork.UserOrder.Value.List(x => true, search.PageSize, search.PageNumber);
            return UserOrders;
        }

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.UserOrder.Value.Remove(Id);
            return true;
        }

        public IEnumerable<UserOrder> AddRange(IEnumerable<UserOrder> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserOrder> UpdateRange(IEnumerable<UserOrder> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserOrder> RemoveRange(IEnumerable<UserOrder> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserOrder> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserOrder> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
