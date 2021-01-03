using Domains.DTO;
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
            entity.CreatedDate = DateTime.Now;
            _repositoryUnitOfWork.SubCategory.Value.Add(entity);
            return entity;
        }


        public SubCategory Update(SubCategory entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _repositoryUnitOfWork.SubCategory.Value.Update(entity);
            return entity;
        }

        public SubCategory Get(int Id)
        {
            SubCategory SubCategory = _repositoryUnitOfWork.SubCategory.Value.Get(Id);
            return SubCategory;
        }

        public BaseListResponse<SubCategory> List(BaseSearch search)
        {
            BaseListResponse<SubCategory> SubCategorys = _repositoryUnitOfWork.SubCategory.Value.List(x => string.IsNullOrEmpty(search.Name) || (x.Name.Contains(search.Name) || x.NameAr.Contains(search.Name)), search.PageSize, search.PageNumber);
            return SubCategorys;
        }

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.SubCategory.Value.Remove(Id);
            return true;
        }

        public BaseListResponse<SubCategory> GetSubCategoryByCategoryId(int Id, BaseSearch search)
        {
            BaseListResponse<SubCategory> SubCategories = _repositoryUnitOfWork.SubCategory.Value.List(x => x.CategoryId == Id && string.IsNullOrEmpty(search.Name) || x.Name.Contains(search.Name), search.PageSize, search.PageNumber);
            return SubCategories;
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
            return _repositoryUnitOfWork.SubCategory.Value.GetAll();
        }
    }
}
