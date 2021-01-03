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
    public class SizeService : ISizeService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public SizeService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public Size Add(Size entity)
        {
            _repositoryUnitOfWork.Size.Value.Add(entity);
            return entity;
        }


        public Size Update(Size entity)
        {
            _repositoryUnitOfWork.Size.Value.Update(entity);
            return entity;
        }

        public Size Get(int Id)
        {
            Size Size = _repositoryUnitOfWork.Size.Value.Get(Id);
            return Size;
        }

        public BaseListResponse<Size> List(BaseSearch search)
        {
            BaseListResponse<Size> Sizes = _repositoryUnitOfWork.Size.Value.List(x => true, search.PageSize, search.PageNumber);
            return Sizes;
        }

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.Size.Value.Remove(Id);
            return true;
        }

        public IEnumerable<Size> AddRange(IEnumerable<Size> entities)
        {
            throw new NotImplementedException();
        }

       
        public IEnumerable<Size> GetAll()
        {
            return _repositoryUnitOfWork.Size.Value.GetAll();
        }

        

        

        public IEnumerable<Size> RemoveRange(IEnumerable<Size> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Size> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Size> UpdateRange(IEnumerable<Size> entities)
        {
            throw new NotImplementedException();
        }

    
    }
}
