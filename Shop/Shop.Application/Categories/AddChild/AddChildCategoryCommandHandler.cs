using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.AddChild
{
    public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand, long>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainservice;

        public AddChildCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainservice)
        {
            _repository = repository;
            _domainservice = domainservice;
        }

        public async Task<OperationResult<long>> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.ParentId);
            if (category == null)
            {
                return OperationResult<long>.NotFound();
            }
            category.AddChild(request.Title, request.Slug, request.SeoData, _domainservice);
            await _repository.Save();
            return OperationResult<long>.Success(category.Id);
        }
    }
}
