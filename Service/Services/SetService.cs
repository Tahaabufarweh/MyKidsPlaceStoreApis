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
    public class SetService : ISetService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public SetService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public Set Add(Set entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Set> AddRange(IEnumerable<Set> entities)
        {
            throw new NotImplementedException();
        }

        public Set Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Set> GetAll()
        {
            throw new NotImplementedException();
        }

        public Set Remove(Set entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Set> RemoveRange(IEnumerable<Set> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Set> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public Set Update(Set entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Set> UpdateRange(IEnumerable<Set> entities)
        {
            throw new NotImplementedException();
        }
    }
}
