using Domains.DTO;
using Domains.Models;
using Domains.SearchModels;
using Service.Interfaces.Common;

namespace Service.Interfaces
{
    public interface IItemService : IService<Item, BaseSearch>
    {
        BaseListResponse<Item> GetItemsBySubCategoryId(int Id, BaseSearch search);
    }
}
