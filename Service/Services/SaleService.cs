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
    public class SaleService : ISaleService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public SaleService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public Sale Add(Sale entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> AddRange(IEnumerable<Sale> entities)
        {
            throw new NotImplementedException();
        }

        public Sale Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> GetAll()
        {
            throw new NotImplementedException();
        }

        public Sale Remove(Sale entity)
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

        public Sale Update(Sale entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> UpdateRange(IEnumerable<Sale> entities)
        {
            throw new NotImplementedException();
        }
    }
}
