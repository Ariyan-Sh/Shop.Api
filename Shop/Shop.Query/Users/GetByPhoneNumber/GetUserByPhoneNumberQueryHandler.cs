using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.GetByPhoneNumber
{
    internal class GetUserByPhoneNumberQueryHandler : IQueryHandler<GetUserByPhoneNumberQuery, UserDto?>
    {
        private readonly ShopContext _context;

        public GetUserByPhoneNumberQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<UserDto?> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(s=>s.PhoneNumber == request.PhoneNumber,cancellationToken);
            if (user == null)
            {
                return null;
            }
            return await user.Map().SetUserRoleTitle(_context);
        }
    }
}
