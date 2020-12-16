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
    public class SubCategoryService : ISubCategoryService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public SubCategoryService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public SubCategory Add(SubCategory entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubCategory> AddRange(IEnumerable<SubCategory> entities)
        {
            throw new NotImplementedException();
        }

        public SubCategory Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public SubCategory Remove(SubCategory entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubCategory> RemoveRange(IEnumerable<SubCategory> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubCategory> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public SubCategory Update(SubCategory entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubCategory> UpdateRange(IEnumerable<SubCategory> entities)
        {
            throw new NotImplementedException();
        }
    }
}
