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
    public class UserOrderService : IUserOrderService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public UserOrderService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public UserOrder Add(UserOrder entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserOrder> AddRange(IEnumerable<UserOrder> entities)
        {
            throw new NotImplementedException();
        }

        public UserOrder Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserOrder> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserOrder Remove(UserOrder entity)
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

        public UserOrder Update(UserOrder entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserOrder> UpdateRange(IEnumerable<UserOrder> entities)
        {
            throw new NotImplementedException();
        }
    }
}
