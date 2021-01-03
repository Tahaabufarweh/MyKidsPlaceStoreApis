
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.UnitOfWork
{
    public interface IRepositoryUnitOfWork : IDisposable
    {
         Lazy<ISizeRepository> Size { get; set; }
         Lazy<IColorRepository> Color { get; set; }
         Lazy<IOrderRepository> Order { get; set; }
         Lazy<IItemColorRepository> ItemColor { get; set; }
         Lazy<IItemSizeRepository> ItemSize { get; set; }
         Lazy<IBrandRepository> Brand { get; set; }
         Lazy<IRoleRepository> Roles { get; set; }
         Lazy<IUserRoleRepository> UserRole { get; set; }
         Lazy<ICartItemRepository> CartItem { get; set; }
         Lazy<IItemRepository> Item { get; set; }
         Lazy<ICategoryRepository> Category { get; set; }
         Lazy<ISubCategoryRepository> SubCategory { get; set; }
         Lazy<ISaleRepository> Sale { get; set; }
         Lazy<ISetRepository> Set { get; set; }
         Lazy<IUserCartRepository> UserCart { get; set; }

    }
}
