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
    public class MasterCategoryService : IMasterCategoryService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public MasterCategoryService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public MasterCategory Add(MasterCategory entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MasterCategory> AddRange(IEnumerable<MasterCategory> entities)
        {
            throw new NotImplementedException();
        }

        public MasterCategory Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MasterCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public MasterCategory Remove(MasterCategory entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MasterCategory> RemoveRange(IEnumerable<MasterCategory> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MasterCategory> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public MasterCategory Update(MasterCategory entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MasterCategory> UpdateRange(IEnumerable<MasterCategory> entities)
        {
            throw new NotImplementedException();
        }
    }
}
