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
    public class CategoryService : ICategoryService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public CategoryService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public Category Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> AddRange(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public Category Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category Remove(Category entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> RemoveRange(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> UpdateRange(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }
    }
}
