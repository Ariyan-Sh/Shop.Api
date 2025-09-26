using Common.Application;
using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Presentation.Facade.Categories;
using Shop.Query.Categories.DTOs;
using System.Net;
using Shop.Domain.RoleAgg.Enums;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Api.Controllers
{
    [PermissionChecker(Permission.Category_Management)]
    public class CategoryController : ApiController
    {
        private readonly ICategoryFacade _categoryFacade;

        public CategoryController(ICategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResult<List<CategoryDto>>> GetCategories()
        {
            var result = await _categoryFacade.GetCategories();
            return QueryResult(result);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ApiResult<CategoryDto>> GetCategoryById(long id)
        {
            var result = await _categoryFacade.GetCategoryById(id);
            return QueryResult(result);
        }
        [HttpGet("getChild/{parentId}")]
        [AllowAnonymous]
        public async Task<ApiResult<List<ChildCategoryDto>>> GetCategoryByParentId(long parentId)
        {
            var result = await _categoryFacade.GetCategoriesByParentId(parentId);
            return QueryResult(result);
        }
        [HttpPost]
        public async Task<ApiResult<long>> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _categoryFacade.Create(command);
            var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
            return CommandResult(result,HttpStatusCode.Created,url);
        }
        [HttpPut]
        public async Task<ApiResult> EditCategory(EditCategoryCommand command)
        {
            var result = await _categoryFacade.Edit(command);
            return CommandResult(result);
        }
        [HttpDelete("{categoryId}")]
        public async Task<ApiResult> RemoveCategory(long categoryId)
        {
            var result = await _categoryFacade.Remove(categoryId);
            return CommandResult(result);
        }
        [HttpPost("AddChild")]
        public async Task<ApiResult<long>> AddChildCategory(AddChildCategoryCommand command)
        {
            var result = await _categoryFacade.AddChild(command);
            var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, HttpStatusCode.Created, url);
        }
    }
}
