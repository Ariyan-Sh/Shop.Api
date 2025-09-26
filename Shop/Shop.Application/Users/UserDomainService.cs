using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _repository;

        public UserDomainService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool IsEmailExist(string email)
        {
            return _repository.Exists(r => r.Email == email);
        }

        public bool PhoneNumberIsExist(string phoneNumber)
        {
            return _repository.Exists(r => r.PhoneNumber == phoneNumber);
        }
    }
}
