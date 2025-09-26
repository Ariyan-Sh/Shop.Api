using Common.Application;
using Shop.Domain.UserAgg;

namespace Shop.Application.Users.SetActiveAddress
{
    public class SetActiveAddressCommandHandler : IBaseCommandHandler<SetActiveAddressCommand>
    {
        private readonly IUserRepository _repository;

        public SetActiveAddressCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(SetActiveAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
            {
                return OperationResult.NotFound("کاربر یافت نشد");
            }
            user.SetActiveAddress(request.AddressId);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
