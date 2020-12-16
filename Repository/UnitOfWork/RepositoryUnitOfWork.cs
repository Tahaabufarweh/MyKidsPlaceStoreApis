using Repository.Context;
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
        public Lazy<ICartItemRepository> CartItem{ get; set; }
        public Lazy<ICategoryRepository> Category { get; set; }
        public Lazy<IMasterCategoryRepository> MasterCategory { get; set; }
        public Lazy<ISubCategoryRepository> SubCategory { get; set; }
        public Lazy<ISaleRepository> Sale { get; set; }
        public Lazy<ISetRepository> Set { get; set; }
        public Lazy<IUserCartRepository> UserCart { get; set; }
        public Lazy<IUserOrderRepository> UserOrder { get; set; }
        

        public RepositoryUnitOfWork(MyKidsStoreDbContext context)
        {
            _Context = context;
            Brand = new Lazy<IBrandRepository>(() => new BrandRepository(_Context));
            CartItem = new Lazy<ICartItemRepository>(() => new CartItemRepository(_Context));
            Category = new Lazy<ICategoryRepository>(() => new CategoryRepository(_Context));
            MasterCategory = new Lazy<IMasterCategoryRepository>(() => new MasterCategoryRepository(_Context));
            SubCategory = new Lazy<ISubCategoryRepository>(() => new SubCategoryRepository(_Context));
            Sale = new Lazy<ISaleRepository>(() => new SaleRepository(_Context));
            Set = new Lazy<ISetRepository>(() => new SetRepository(_Context));
            UserCart = new Lazy<IUserCartRepository>(() => new UserCartRepository(_Context));
            UserOrder = new Lazy<IUserOrderRepository>(() => new UserOrderRepository(_Context));
        }

        public void Dispose()
        {
            _Context.Dispose();
            
        }
    }
}
