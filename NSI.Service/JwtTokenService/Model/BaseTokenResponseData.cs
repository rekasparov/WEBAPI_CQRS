using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI.Service.JwtTokenService.Model
{
    public class BaseTokenResponseData : IDisposable
    {
        public string Token { get; }
        public DateTime TokenExpireDate { get; }

        public BaseTokenResponseData(string token, DateTime tokenExpireDate)
        {
            Token = token;
            TokenExpireDate = tokenExpireDate;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
