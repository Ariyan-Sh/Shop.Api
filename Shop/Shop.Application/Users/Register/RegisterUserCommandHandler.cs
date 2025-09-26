using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Services;
using Common.Application.SecurityUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.Register
{
    internal class RegisterUserCommandHandler:IBaseCommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUserDomainService _domainService;

        public RegisterUserCommandHandler(IUserRepository repository, IUserDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }
        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.RegisterUser(request.PhoneNumber.Value, Sha256Hasher.Hash(request.Password), _domainService);
            _repository.Add(user);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
