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
    public class SubCategoryService : ISubCategoryService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public SubCategoryService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public SubCategory Add(SubCategory entity)
        {
            _repositoryUnitOfWork.SubCategory.Value.Add(entity);
            return entity;
        }


        public SubCategory Update(SubCategory entity)
        {
            _repositoryUnitOfWork.SubCategory.Value.Update(entity);
            return entity;
        }

        public SubCategory Get(int Id)
        {
            SubCategory SubCategory = _repositoryUnitOfWork.SubCategory.Value.Get(Id);
            return SubCategory;
        }

        public List<SubCategory> List(BaseSearch search)
        {
            List<SubCategory> SubCategorys = _repositoryUnitOfWork.SubCategory.Value.List(x => true, search.PageSize, search.PageNumber);
            return SubCategorys;
        }

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.SubCategory.Value.Remove(Id);
            return true;
        }

        public IEnumerable<SubCategory> AddRange(IEnumerable<SubCategory> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubCategory> UpdateRange(IEnumerable<SubCategory> entities)
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

        public IEnumerable<SubCategory> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
