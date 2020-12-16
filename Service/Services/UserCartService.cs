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
    public class UserCartService : IUserCartService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public UserCartService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public UserCart Add(UserCart entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserCart> AddRange(IEnumerable<UserCart> entities)
        {
            throw new NotImplementedException();
        }

        public UserCart Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserCart> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserCart Remove(UserCart entity)
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

        public UserCart Update(UserCart entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserCart> UpdateRange(IEnumerable<UserCart> entities)
        {
            throw new NotImplementedException();
        }
    }
}
