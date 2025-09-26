using Common.Application;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.RemoveImage;
using Shop.Query.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Products
{
    public interface IProductFacade
    {
        Task<OperationResult> CreateProduct(CreateProductCommand command);
        Task<OperationResult> EditProduct(EditProductCommand command);
        Task<OperationResult> AddImage(AddProductImageCommand command);
        Task<OperationResult> RemoveImage(RemoveProductImageCommand command);

        Task<ProductDto?> GetProductById(long productId);
        Task<ProductFilterResult> GetProductsByFilter(ProductFilterParams filterParams);
        Task<ProductDto?> GetProductBySlug(string slug);
        Task<ProductShopResult> GetProductsForShop(ProductShopFilterParam filterParam);
    }
}
