
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.UnitOfWork
{
    public interface IRepositoryUnitOfWork : IDisposable
    {
         Lazy<IBrandRepository> Brand { get; set; }
         Lazy<ICartItemRepository> CartItem { get; set; }
         Lazy<ICategoryRepository> Category { get; set; }
         Lazy<IMasterCategoryRepository> MasterCategory { get; set; }
         Lazy<ISubCategoryRepository> SubCategory { get; set; }
         Lazy<ISaleRepository> Sale { get; set; }
         Lazy<ISetRepository> Set { get; set; }
         Lazy<IUserCartRepository> UserCart { get; set; }
         Lazy<IUserOrderRepository> UserOrder { get; set; }

    }
}
