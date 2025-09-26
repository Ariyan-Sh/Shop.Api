﻿using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.Addresses.GetById
{
    internal class GetUserAddressByIdQueryHandler : IQueryHandler<GetUserAddressByIdQuery, AddressDto?>
    {
        private readonly DapperContext _dapperContext;

        public GetUserAddressByIdQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<AddressDto?> Handle(GetUserAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var sql = $"Select top 1 * from {_dapperContext.UserAddresses} where id=@id";
            using var context = _dapperContext.CreateConnection();
            return await context.QueryFirstOrDefaultAsync(sql, new { id = request.AddressId });
        }
    }
}
