using NSI.Service.JwtTokenService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI.Service.JwtTokenService.Abstract
{
    public interface IBaseJwtTokenService : IDisposable
    {
        public Task<BaseTokenResponseData> GenerateJwtTokenAsync(BaseTokenRequestData tokenRequestData);
        public Task<bool> IsValidAsync(string issuer, string audience, string secret, string token);
    }
}
