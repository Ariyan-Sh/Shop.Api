using Common.Query;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Roles.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Roles.GetById
{
    internal class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, RoleDto?>
    {
        private readonly ShopContext _context;

        public GetRoleByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<RoleDto?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(s=>s.Id == request.RoleId,cancellationToken);
            if (role == null)
            {
                return null;
            }
            return new RoleDto()
            {
                Id = role.Id,
                CreationDate = role.CreationDate,
                Permissions = role.Permissions.Select(f=>f.Permission).ToList(),
                Title = role.Title,
            };
        }
    }
}
