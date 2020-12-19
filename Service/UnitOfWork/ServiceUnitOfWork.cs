using Domains.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Repository;
using Repository.Context;
using Repository.UnitOfWork;
using Service.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.UnitOfWork
{
    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LoggedInUserService _loggedInUserService;

        public Lazy<IAuthService> Auth { get; set; }
        public Lazy<IBrandService> Brand { get; set; }
        public Lazy<ICartItemService> CartItem { get; set; }
        public Lazy<ICategoryService> Category { get; set; }
        public Lazy<IItemService> Item { get; set; }
        public Lazy<IMasterCategoryService> MasterCategory { get; set; }
        public Lazy<ISaleService> Sale { get; set; }
        public Lazy<ISetService> Set { get; set; }
        public Lazy<ISubCategoryService> SubCategory { get; set; }
        public Lazy<IUserCartService> UserCart { get; set; }
        public Lazy<IUserOrderService> UserOrder { get; set; }



        public ServiceUnitOfWork(
           MyKidsStoreDbContext context,
           UserManager<ApplicationUser> userManager,
           IHttpContextAccessor httpContextAccessor,
           SignInManager<ApplicationUser> signInManager
           )
        {
            _loggedInUserService = new LoggedInUserService(httpContextAccessor);
            _repositoryUnitOfWork = new RepositoryUnitOfWork(context);
            Auth = new Lazy<IAuthService>(() => new AuthService(userManager, _repositoryUnitOfWork, signInManager, _loggedInUserService));
            Brand = new Lazy<IBrandService>(() => new BrandService(_repositoryUnitOfWork));
            CartItem = new Lazy<ICartItemService>(() => new CartItemService(_repositoryUnitOfWork));
            Category = new Lazy<ICategoryService>(() => new CategoryService(_repositoryUnitOfWork));
            Item = new Lazy<IItemService>(() => new ItemService(_repositoryUnitOfWork));
            MasterCategory = new Lazy<IMasterCategoryService>(() => new MasterCategoryService(_repositoryUnitOfWork));
            Sale = new Lazy<ISaleService>(() => new SaleService(_repositoryUnitOfWork));
            Set = new Lazy<ISetService>(() => new SetService(_repositoryUnitOfWork));
            UserOrder = new Lazy<IUserOrderService>(() => new UserOrderService(_repositoryUnitOfWork));
            UserCart = new Lazy<IUserCartService>(() => new UserCartService(_repositoryUnitOfWork));
            SubCategory = new Lazy<ISubCategoryService>(() => new SubCategoryService(_repositoryUnitOfWork));
  
        }

        
        public void Dispose() {}
    }
}
