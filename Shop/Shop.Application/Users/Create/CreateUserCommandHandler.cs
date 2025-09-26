using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.Create
{
    internal class CreateUserCommandHandler:IBaseCommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUserDomainService _userDomainService;

        public CreateUserCommandHandler(IUserRepository repository, IUserDomainService userDomainService)
        {
            _repository = repository;
            _userDomainService = userDomainService;
        }

        public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var password = Sha256Hasher.Hash(request.Password);
            var user = new User(request.Name,request.Family,request.PhoneNumber,request.Email,password,request.Gender, _userDomainService);
            _repository.Add(user);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
