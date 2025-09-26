using Common.Application;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.SiteEntities.ShippingMethod.Create
{
    internal class CreateShippingMethodCommandHandler : IBaseCommandHandler<CreateShippingMethodCommand>
    {
        private readonly IShippingMethodRepository _repository;

        public CreateShippingMethodCommandHandler(IShippingMethodRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateShippingMethodCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(new Domain.SiteEntities.ShippingMethod(request.Title, request.Cost));
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
