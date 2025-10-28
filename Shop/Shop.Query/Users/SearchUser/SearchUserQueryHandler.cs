using Common.Query;
using Shop.Domain.UserAgg;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.SearchUser
{
    internal class SearchUserQueryHandler : IQueryHandler<SearchUserQuery, List<Select2UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public SearchUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<Select2UserDto>> Handle(SearchUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.SearchUsersAsync(request.Query, request.Take);

            return users.Select(u => new Select2UserDto
            {
                id = u.Id,
                text = $"{u.Name} {u.Family} ({u.Email})"
            }).ToList();
        }
    }
}
