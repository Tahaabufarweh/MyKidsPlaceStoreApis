using Repository.Context;
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.UnitOfWork
{
    public class RepositoryUnitOfWork : IRepositoryUnitOfWork
    {
        private MyKidsStoreDbContext _Context;

        public Lazy<IBrandRepository> Brand { get; set; }
        public Lazy<ISizeRepository> Size { get; set; }
        public Lazy<IColorRepository> Color { get; set; }
        public Lazy<IOrderRepository> Order { get; set; }
        public Lazy<IItemColorRepository> ItemColor { get; set; }
        public Lazy<IItemSizeRepository> ItemSize { get; set; }
        public Lazy<IItemRepository> Item { get; set; }
        public Lazy<IRoleRepository> Roles { get; set; }
        public Lazy<ICartItemRepository> CartItem{ get; set; }
        public Lazy<ICategoryRepository> Category { get; set; }
        public Lazy<ISubCategoryRepository> SubCategory { get; set; }
        public Lazy<ISaleRepository> Sale { get; set; }
        public Lazy<ISetRepository> Set { get; set; }
        public Lazy<IUserCartRepository> UserCart { get; set; }
        public Lazy<IUserRoleRepository> UserRole { get; set; }

        public RepositoryUnitOfWork(MyKidsStoreDbContext context)
        {
            _Context = context;
            Item = new Lazy<IItemRepository>(() => new ItemsRepository(_Context));
            UserRole = new Lazy<IUserRoleRepository>(() => new UserRoleRepository(_Context));
            Brand = new Lazy<IBrandRepository>(() => new BrandRepository(_Context));
            Roles = new Lazy<IRoleRepository>(() => new RoleRepository(_Context));
            CartItem = new Lazy<ICartItemRepository>(() => new CartItemRepository(_Context));
            Category = new Lazy<ICategoryRepository>(() => new CategoryRepository(_Context));
            SubCategory = new Lazy<ISubCategoryRepository>(() => new SubCategoryRepository(_Context));
            Sale = new Lazy<ISaleRepository>(() => new SaleRepository(_Context));
            Set = new Lazy<ISetRepository>(() => new SetRepository(_Context));
            Order = new Lazy<IOrderRepository>(() => new OrderRepository(_Context));
            ItemSize = new Lazy<IItemSizeRepository>(() => new ItemSizeRepository(_Context));
            ItemColor = new Lazy<IItemColorRepository>(() => new ItemColorsRepository(_Context));
            Color = new Lazy<IColorRepository>(() => new ColorRepository(_Context));
            Size = new Lazy<ISizeRepository>(() => new SizeRepository(_Context));
            UserCart = new Lazy<IUserCartRepository>(() => new UserCartRepository(_Context));
        }

        public void Dispose()
        {
            _Context.Dispose();
            
        }
    }
}
