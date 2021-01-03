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
    public class OrderService : IOrderService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public OrderService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public Orders Add(Orders entity)
        {
            _repositoryUnitOfWork.Order.Value.Add(entity);
            return entity;
        }


        public Orders Update(Orders entity)
        {
            _repositoryUnitOfWork.Order.Value.Update(entity);
            return entity;
        }

        public Orders Get(int Id)
        {
            Orders Order = _repositoryUnitOfWork.Order.Value.Get(Id);
            return Order;
        }

        public BaseListResponse<Orders> List(BaseSearch search)
        {
            BaseListResponse<Orders> Orders = _repositoryUnitOfWork.Order.Value.List(x => true, search.PageSize, search.PageNumber);
            return Orders;
        }

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.Order.Value.Remove(Id);
            return true;
        }

        public IEnumerable<Orders> AddRange(IEnumerable<Orders> entities)
        {
            throw new NotImplementedException();
        }

       
        public IEnumerable<Orders> GetAll()
        {
            return _repositoryUnitOfWork.Order.Value.GetAll();
        }

        

        

        public IEnumerable<Orders> RemoveRange(IEnumerable<Orders> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Orders> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Orders> UpdateRange(IEnumerable<Orders> entities)
        {
            throw new NotImplementedException();
        }

    
    }
}
