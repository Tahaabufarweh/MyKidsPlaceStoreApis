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
    public class ItemSizeService : IItemSizeService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public ItemSizeService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public ItemSizes Add(ItemSizes entity)
        {
            _repositoryUnitOfWork.ItemSize.Value.Add(entity);
            return entity;
        }


        public ItemSizes Update(ItemSizes entity)
        {
            _repositoryUnitOfWork.ItemSize.Value.Update(entity);
            return entity;
        }

        public ItemSizes Get(int Id)
        {
            ItemSizes ItemSize = _repositoryUnitOfWork.ItemSize.Value.Get(Id);
            return ItemSize;
        }

        public BaseListResponse<ItemSizes> List(BaseSearch search)
        {
            BaseListResponse<ItemSizes> ItemSizes = _repositoryUnitOfWork.ItemSize.Value.List(x => true, search.PageSize, search.PageNumber);
            return ItemSizes;
        }

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.ItemSize.Value.Remove(Id);
            return true;
        }

        public IEnumerable<ItemSizes> AddRange(IEnumerable<ItemSizes> entities)
        {
            throw new NotImplementedException();
        }

       
        public IEnumerable<ItemSizes> GetAll()
        {
            return _repositoryUnitOfWork.ItemSize.Value.GetAll();
        }

        

        

        public IEnumerable<ItemSizes> RemoveRange(IEnumerable<ItemSizes> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemSizes> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<ItemSizes> UpdateRange(IEnumerable<ItemSizes> entities)
        {
            throw new NotImplementedException();
        }

    
    }
}
