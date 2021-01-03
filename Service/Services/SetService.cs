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
    public class SetService : ISetService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public SetService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public Set Add(Set entity)
        {
            _repositoryUnitOfWork.Set.Value.Add(entity);
            return entity;
        }


        public Set Update(Set entity)
        {
            _repositoryUnitOfWork.Set.Value.Update(entity);
            return entity;
        }

        public Set Get(int Id)
        {
            Set Set = _repositoryUnitOfWork.Set.Value.Get(Id);
            return Set;
        }

        public BaseListResponse<Set> List(BaseSearch search)
        {
            BaseListResponse<Set> Sets = _repositoryUnitOfWork.Set.Value.List(x=> true, search.PageSize, search.PageNumber);
            return Sets;
        }

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.Set.Value.Remove(Id);
            return true;
        }

        public IEnumerable<Set> AddRange(IEnumerable<Set> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Set> UpdateRange(IEnumerable<Set> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Set> RemoveRange(IEnumerable<Set> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Set> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Set> GetAll()
        {
            return _repositoryUnitOfWork.Set.Value.GetAll();
        }
    }
}
