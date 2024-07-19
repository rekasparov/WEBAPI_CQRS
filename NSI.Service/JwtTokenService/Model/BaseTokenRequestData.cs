using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NSI.Service.JwtTokenService.Model
{
    public class BaseTokenRequestData : IDisposable
    {
        public string Username { get; }
        public string Issuer { get; }
        public string Audience { get; }
        public string Secret { get; }
        public IEnumerable<Claim> Claims { get; }

        public BaseTokenRequestData(string username, string issuer, string audience, string secret, List<Claim> claims)
        {
            Username = username;
            Issuer = issuer;
            Audience = audience;
            Secret = secret;
            Claims = claims;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
