﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShoppEcommerce_WebApp.Common.Entities;
using ShoppEcommerce_WebApp.Common.ViewModels.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoppEcommerce_WebApp.BLL.JWTServices
{
    public class JwtService : IJwtService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JwtSettings _jwtSettings;
        public JwtService(IHttpContextAccessor httpContextAccessor, IOptions<JwtSettings> jwtOptions)
        {
            _httpContextAccessor = httpContextAccessor;
            _jwtSettings = jwtOptions.Value;
        }

        private ClaimsPrincipal GetUserClaims()
        {
            return _httpContextAccessor.HttpContext?.User;
        }

        public string GenerateJwtToken(Account _account)
        {
            var secretKey = _jwtSettings.SecretKey;
            var issuer = _jwtSettings.Issuer;
            var audience = _jwtSettings.Audience;
            var expiryMinutes = _jwtSettings.ExpiresInMinutes.ToString();

            if (string.IsNullOrEmpty(secretKey) || string.IsNullOrEmpty(issuer) ||
                string.IsNullOrEmpty(audience) || string.IsNullOrEmpty(expiryMinutes))
            {
                throw new InvalidOperationException("JWT environment variables are not set properly.");
            }
            var key = Encoding.UTF8.GetBytes(secretKey);
            var claims = new List<Claim> {
                new Claim("accountId", _account.Id.ToString()),
                new Claim("email", _account.Email),
                new Claim(ClaimTypes.Role, _account.Role.RoleName.ToString()),
                // new Claim("role", _account.Role.ToString())
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(expiryMinutes)), // token hết hạng trong 30 phút
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        public string GetAccountId()
        {
            return GetUserClaims().FindFirst("accountId")?.Value;
        }

        public string GetEmail()
        {
            return GetUserClaims().FindFirst("email")?.Value;
        }

        public string GetRole()
        {
            return GetUserClaims().FindFirst("roleName")?.Value;
        }

        public string GetTokenId()
        {
            return GetUserClaims().FindFirst("tokenId")?.Value;
        }

        public int? ValidateToken(string token)
        {
            if (token == null)
                return null;
            var secretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("JWT environment variables are not set properly.");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                return userId;
            }
            catch
            {
                return null;
            }
        }
    }
}
