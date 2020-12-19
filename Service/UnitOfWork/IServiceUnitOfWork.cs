
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.UnitOfWork
{
    public interface IServiceUnitOfWork : IDisposable
    {
        Lazy<IAuthService> Auth { get; set; }
        Lazy<IBrandService> Brand { get; set; }
        Lazy<ICartItemService> CartItem { get; set; }
        Lazy<ICategoryService> Category { get; set; }
        Lazy<IItemService> Item { get; set; }
        Lazy<IMasterCategoryService> MasterCategory { get; set; }
        Lazy<ISaleService> Sale { get; set; }
        Lazy<ISetService> Set { get; set; }
        Lazy<ISubCategoryService> SubCategory { get; set; }
        Lazy<IUserCartService> UserCart { get; set; }
        Lazy<IUserOrderService> UserOrder { get; set; }


    }
}
