﻿using Domains.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces.Common
{
    public interface IService<Entity, TEntity>
    {
        Entity Add(Entity entity);
        IEnumerable<Entity> AddRange(IEnumerable<Entity> entities);
        Entity Update(Entity entity);
        IEnumerable<Entity> UpdateRange(IEnumerable<Entity> entities);
        bool Remove(int Id);
        IEnumerable<Entity> RemoveRange(IEnumerable<Entity> entities);
        IEnumerable<Entity> RemoveRangeByIDs(IEnumerable<long> IDs);
        Entity Get(int Id);
        IEnumerable<Entity> GetAll();
        BaseListResponse<Entity> List(TEntity entity);

    }
}
