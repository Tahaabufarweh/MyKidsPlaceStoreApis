﻿using Domains.Models;
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
    public class ItemService : IItemService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public ItemService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }

        public Item Add(Item entity)
        {
            _repositoryUnitOfWork.Item.Value.Add(entity);
            return entity;
        }


        public Item Update(Item entity)
        {
            _repositoryUnitOfWork.Item.Value.Update(entity);
            return entity;
        }

        public Item Get(int Id)
        {
            Item Item = _repositoryUnitOfWork.Item.Value.Get(Id);
            return Item;
        }

        public List<Item> List(BaseSearch search)
        {
            List<Item> Items = _repositoryUnitOfWork.Item.Value.List(x => string.IsNullOrEmpty(search.Name) || x.Description.Contains(search.Name), search.PageSize, search.PageNumber);
            return Items;
        }

        public List<Item> GetItemsBySubCategoryId(int Id, BaseSearch search)
        {
            List<Item> Items = _repositoryUnitOfWork.Item.Value.List(x => x.SubCategoryId == Id && string.IsNullOrEmpty(search.Name) || x.Description.Contains(search.Name), search.PageSize, search.PageNumber);
            return Items;
        }
        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.Item.Value.Remove(Id);
            return true;
        }

        public IEnumerable<Item> AddRange(IEnumerable<Item> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> UpdateRange(IEnumerable<Item> entities)
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

        public IEnumerable<Item> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
