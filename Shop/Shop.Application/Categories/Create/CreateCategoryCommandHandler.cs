using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.Create
{
    public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand, long>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainservice;

        public CreateCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainservice)
        {
            _repository = repository;
            _domainservice = domainservice;
        }

        public async Task<OperationResult<long>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.title, request.slug, request.SeoData, _domainservice);
            _repository.Add(category);
            await _repository.Save();
            return OperationResult<long>.Success(category.Id);
        }
    }
}
