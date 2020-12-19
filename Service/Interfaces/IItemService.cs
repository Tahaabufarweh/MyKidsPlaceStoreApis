using Domains.Models;
using Domains.SearchModels;
using Repository.Interfaces.Common;
using Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IItemService : IService<Item, BaseSearch>
    {
        List<Item> GetItemsBySubCategoryId(int Id, BaseSearch search);
    }
}
