using Domains.Models;
using Domains.SearchModels;
using Repository.Interfaces.Common;
using Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface ISubCategoryService : IService<SubCategory, BaseSearch>
    {
        //List<Item> GetSubCategoryByCategoryId(int Id, BaseSearch search);
    }
}
