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
    public class SaleService : ISaleService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public SaleService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public Sale Add(Sale entity)
        {
            _repositoryUnitOfWork.Sale.Value.Add(entity);
            return entity;
        }


        public Sale Update(Sale entity)
        {
            _repositoryUnitOfWork.Sale.Value.Update(entity);
            return entity;
        }

        public Sale Get(int Id)
        {
            Sale Sale = _repositoryUnitOfWork.Sale.Value.Get(Id);
            return Sale;
        }

        public List<Sale> List(BaseSearch search)
        {
            List<Sale> Sales = _repositoryUnitOfWork.Sale.Value.List(x=> true, search.PageSize, search.PageNumber);
            return Sales;
        }

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.Sale.Value.Remove(Id);
            return true;
        }

        public IEnumerable<Sale> AddRange(IEnumerable<Sale> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> UpdateRange(IEnumerable<Sale> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> RemoveRange(IEnumerable<Sale> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
