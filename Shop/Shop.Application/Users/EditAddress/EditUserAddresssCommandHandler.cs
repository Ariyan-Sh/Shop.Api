using Common.Application;
using Shop.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.EditAddress
{
    internal class EditUserAddresssCommandHandler:IBaseCommandHandler<EditUserAddresssCommand>
    {
        private readonly IUserRepository _repository;

        public EditUserAddresssCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(EditUserAddresssCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
            {
                return OperationResult.NotFound();
            }
            var address = new UserAddress(request.Shire, request.City, request.PostalCode, request.PostalAddress,
            request.PhoneNumber, request.Name, request.Family, request.NationalCode);
            user.EditAddress(address,request.Id);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
