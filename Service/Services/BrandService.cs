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
    public class BrandService : IBrandService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public BrandService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public Brand Add(Brand entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Brand> AddRange(IEnumerable<Brand> entities)
        {
            throw new NotImplementedException();
        }

        public Brand Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Brand> GetAll()
        {
            throw new NotImplementedException();
        }

        public Brand Remove(Brand entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Brand> RemoveRange(IEnumerable<Brand> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Brand> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public Brand Update(Brand entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Brand> UpdateRange(IEnumerable<Brand> entities)
        {
            throw new NotImplementedException();
        }
    }
}
