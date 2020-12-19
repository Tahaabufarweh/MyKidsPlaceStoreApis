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
    public class CategoryService : ICategoryService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public CategoryService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public Category Add(Category entity)
        {
            _repositoryUnitOfWork.Category.Value.Add(entity);
            return entity;
        }


        public Category Update(Category entity)
        {
            _repositoryUnitOfWork.Category.Value.Update(entity);
            return entity;
        }

        public Category Get(int Id)
        {
            Category Category = _repositoryUnitOfWork.Category.Value.Get(Id);
            return Category;
        }

        public List<Category> List(BaseSearch search)
        {
            List<Category> Categorys = _repositoryUnitOfWork.Category.Value.List(x => string.IsNullOrEmpty(search.Name) || x.CategoryName.Contains(search.Name), search.PageSize, search.PageNumber);
            return Categorys;
        }

        public List<Category> GetCategoryByMasterCategoryId(int Id, BaseSearch search)
        {
            List<Category> Categorys = _repositoryUnitOfWork.Category.Value.List(x => x.MasterCategoryId == Id && string.IsNullOrEmpty(search.Name) || x.CategoryName.Contains(search.Name), search.PageSize, search.PageNumber);
            return Categorys;
        }

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.Category.Value.Remove(Id);
            return true;
        }
    
        public IEnumerable<Category> AddRange(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> UpdateRange(IEnumerable<Category> entities)
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

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        
    }
}
