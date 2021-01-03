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
    public class ItemColorService : IItemColorService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public ItemColorService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public ItemColors Add(ItemColors entity)
        {
            _repositoryUnitOfWork.ItemColor.Value.Add(entity);
            return entity;
        }


        public ItemColors Update(ItemColors entity)
        {
            _repositoryUnitOfWork.ItemColor.Value.Update(entity);
            return entity;
        }

        public ItemColors Get(int Id)
        {
            ItemColors ItemColor = _repositoryUnitOfWork.ItemColor.Value.Get(Id);
            return ItemColor;
        }

        public BaseListResponse<ItemColors> List(BaseSearch search)
        {
            BaseListResponse<ItemColors> ItemColors = _repositoryUnitOfWork.ItemColor.Value.List(x => true, search.PageSize, search.PageNumber);
            return ItemColors;
        }

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.ItemColor.Value.Remove(Id);
            return true;
        }

        public IEnumerable<ItemColors> AddRange(IEnumerable<ItemColors> entities)
        {
            throw new NotImplementedException();
        }

       
        public IEnumerable<ItemColors> GetAll()
        {
            return _repositoryUnitOfWork.ItemColor.Value.GetAll();
        }

        

        

        public IEnumerable<ItemColors> RemoveRange(IEnumerable<ItemColors> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemColors> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<ItemColors> UpdateRange(IEnumerable<ItemColors> entities)
        {
            throw new NotImplementedException();
        }

    
    }
}
