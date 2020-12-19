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
    public class MasterCategoryService : IMasterCategoryService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public MasterCategoryService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public MasterCategory Add(MasterCategory entity)
        {
            _repositoryUnitOfWork.MasterCategory.Value.Add(entity);
            return entity;
        }


        public MasterCategory Update(MasterCategory entity)
        {
            _repositoryUnitOfWork.MasterCategory.Value.Update(entity);
            return entity;
        }

        public MasterCategory Get(int Id)
        {
            MasterCategory MasterCategory = _repositoryUnitOfWork.MasterCategory.Value.Get(Id);
            return MasterCategory;
        }

        public List<MasterCategory> List(BaseSearch search)
        {
            List<MasterCategory> MasterCategorys = _repositoryUnitOfWork.MasterCategory.Value.List(x => string.IsNullOrEmpty(search.Name) || x.CategoryName.Contains(search.Name), search.PageSize, search.PageNumber);
            return MasterCategorys;
        }

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.MasterCategory.Value.Remove(Id);
            return true;
        }

        public IEnumerable<MasterCategory> AddRange(IEnumerable<MasterCategory> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MasterCategory> UpdateRange(IEnumerable<MasterCategory> entities)
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

        public IEnumerable<MasterCategory> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
