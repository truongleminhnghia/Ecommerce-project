using ShoppEcommerce_WebApp.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppEcommerce_WebApp.BLL.JWTServices
{
    public interface IJwtService
    {
        public string GenerateJwtToken(Account _account);
        public int? ValidateToken(string token);
        public string GetAccountId();
        public string GetEmail();
        public string GetRole();
        public string GetTokenId();
    }
}
