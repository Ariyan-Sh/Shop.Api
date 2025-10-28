using Microsoft.EntityFrameworkCore;
using Shop.Domain.UserAgg;
using Shop.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.UserAgg
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ShopContext _context;
        public UserRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<User>> SearchUsersAsync(string query, int take = 20)
        {
            query = query?.Trim() ?? "";

            return await _context.Users
                .Where(u => u.Name.Contains(query) ||
                            u.Family.Contains(query) ||
                            u.Email.Contains(query) ||
                            u.PhoneNumber.Contains(query))
                .Take(take)
                .ToListAsync();
        }
    }
}
