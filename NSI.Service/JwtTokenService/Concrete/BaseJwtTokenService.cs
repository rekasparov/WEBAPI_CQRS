using Microsoft.IdentityModel.Tokens;
using NSI.Service.JwtTokenService.Abstract;
using NSI.Service.JwtTokenService.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI.Service.JwtTokenService.Concrete
{
    public class BaseJwtTokenService : IBaseJwtTokenService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<BaseTokenResponseData> GenerateJwtTokenAsync(BaseTokenRequestData tokenRequestData)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenRequestData.Secret));

            var currentDate = DateTime.UtcNow;
            var tokenExpireDate = currentDate.Add(TimeSpan.FromMinutes(100));

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: tokenRequestData.Issuer,
                audience: tokenRequestData.Audience,
                claims: tokenRequestData.Claims,
                notBefore: currentDate,
                expires: tokenExpireDate,
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256));

            return await Task.FromResult(new BaseTokenResponseData(
                token: new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                tokenExpireDate: tokenExpireDate));
        }

        public async Task<bool> IsValidAsync(string issuer, string audience, string secret, string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateLifetime = false,
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
            };

            SecurityToken securityToken = null!;
            var principal = await Task.FromResult(jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken));

            return principal.Identity!.IsAuthenticated;
        }
    }
}
