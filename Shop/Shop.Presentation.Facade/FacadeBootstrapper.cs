using Microsoft.Extensions.DependencyInjection;
using Shop.Presentation.Facade.Categories;
using Shop.Presentation.Facade.Comments;
using Shop.Presentation.Facade.Orders;
using Shop.Presentation.Facade.Products;
using Shop.Presentation.Facade.Roles;
using Shop.Presentation.Facade.Sellers;
using Shop.Presentation.Facade.Sellers.Inventories;
using Shop.Presentation.Facade.Siteentities.Banner;
using Shop.Presentation.Facade.Siteentities.Slider;
using Shop.Presentation.Facade.Users;
using Shop.Presentation.Facade.Users.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade
{
    public static class FacadeBootstrapper
    {
        public static void InitFacadeDependency(this IServiceCollection service)
        {
            service.AddScoped<ICategoryFacade, CategoryFacade>();
            service.AddScoped<ICommentFacade, CommentFacade>();
            service.AddScoped<IOrderFacade, OrderFacade>();
            service.AddScoped<IProductFacade,  ProductFacade>();
            service.AddScoped<IRoleFacade, RoleFacade>();
            service.AddScoped<ISellerFacade,  SellerFacade>();
            service.AddScoped<ISellerInventoryFacade, SellerInventoryFacade>();
            service.AddScoped<IBannerFacade,  BannerFacade>();
            service.AddScoped<ISliderFacade, SliderFacade>();
            service.AddScoped<IUserFacade,  UserFacade>();
            service.AddScoped<IUserAddressFacade, UserAdsressFacade>();
        }
    }
}
