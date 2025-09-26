using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.SetActiveAddress
{
    public record SetActiveAddressCommand(long UserId,long AddressId):IBaseCommand;
}
