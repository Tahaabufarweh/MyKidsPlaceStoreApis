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
    public class ColorService : IColorService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public ColorService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }
        public Colour Add(Colour entity)
        {
            _repositoryUnitOfWork.Color.Value.Add(entity);
            return entity;
        }


        public Colour Update(Colour entity)
        {
            _repositoryUnitOfWork.Color.Value.Update(entity);
            return entity;
        }

        public Colour Get(int Id)
        {
            Colour Colour = _repositoryUnitOfWork.Color.Value.Get(Id);
            return Colour;
        }

        public BaseListResponse<Colour> List(BaseSearch search)
        {
            BaseListResponse<Colour> Colours = _repositoryUnitOfWork.Color.Value.List(x => string.IsNullOrEmpty(search.Name) || x.Color.Contains(search.Name), search.PageSize, search.PageNumber);
            return Colours;
        }

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.Color.Value.Remove(Id);
            return true;
        }

        public IEnumerable<Colour> AddRange(IEnumerable<Colour> entities)
        {
            throw new NotImplementedException();
        }

       
        public IEnumerable<Colour> GetAll()
        {
            return _repositoryUnitOfWork.Color.Value.GetAll();
        }

        

        

        public IEnumerable<Colour> RemoveRange(IEnumerable<Colour> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Colour> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Colour> UpdateRange(IEnumerable<Colour> entities)
        {
            throw new NotImplementedException();
        }

    
    }
}
