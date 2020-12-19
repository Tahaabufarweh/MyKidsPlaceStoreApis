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
    public class BrandService : IBrandService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public BrandService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public Brand Add(Brand entity)
        {
            _repositoryUnitOfWork.Brand.Value.Add(entity);
            return entity;
        }


        public Brand Update(Brand entity)
        {
            _repositoryUnitOfWork.Brand.Value.Update(entity);
            return entity;
        }

        public Brand Get(int Id)
        {
            Brand brand = _repositoryUnitOfWork.Brand.Value.Get(Id);
            return brand;
        }

        public List<Brand> List(BaseSearch search)
        {
            List<Brand> brands = _repositoryUnitOfWork.Brand.Value.List(x => string.IsNullOrEmpty(search.Name) || x.BrandName.Contains(search.Name), search.PageSize, search.PageNumber);
            return brands;
        }

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.Brand.Value.Remove(Id);
            return true;
        }

        public IEnumerable<Brand> AddRange(IEnumerable<Brand> entities)
        {
            throw new NotImplementedException();
        }

       
        public IEnumerable<Brand> GetAll()
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


        public IEnumerable<Brand> UpdateRange(IEnumerable<Brand> entities)
        {
            throw new NotImplementedException();
        }
    }
}
