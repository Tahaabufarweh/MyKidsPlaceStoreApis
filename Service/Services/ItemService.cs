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
    public class ItemService : IItemService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public ItemService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }

        public Item Add(Item entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> AddRange(IEnumerable<Item> entities)
        {
            throw new NotImplementedException();
        }

        public Item Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetAll()
        {
            throw new NotImplementedException();
        }

        public Item Remove(Item entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> RemoveRange(IEnumerable<Item> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public Item Update(Item entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> UpdateRange(IEnumerable<Item> entities)
        {
            throw new NotImplementedException();
        }
    }
}
