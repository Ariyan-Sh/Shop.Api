using Common.Query;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.SearchUser
{
    public record SearchUserQuery(string Query, int Take = 20) : IQuery<List<Select2UserDto>>;
}
