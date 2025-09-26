using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.AddToken
{
    public class AddUserTokenCommand:IBaseCommand
    {
        public AddUserTokenCommand(long userId, string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            UserId = userId;
            HashJwtToken = hashJwtToken;
            HashRefreshToken = hashRefreshToken;
            TokenExpireDate = tokenExpireDate;
            RefreshTokenExpireDate = refreshTokenExpireDate;
            Device = device;
        }

        public long UserId { get; internal set; }
        public string HashJwtToken { get; private set; }
        public string HashRefreshToken { get; private set; }
        public DateTime TokenExpireDate { get; set; }
        public DateTime RefreshTokenExpireDate { get; private set; }
        public string Device { get; private set; }
    }
}
