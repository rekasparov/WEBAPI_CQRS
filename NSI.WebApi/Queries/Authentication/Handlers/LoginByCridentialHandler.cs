using MediatR;
using NSI.Service.JwtTokenService.Abstract;
using NSI.Service.JwtTokenService.Concrete;
using NSI.Service.JwtTokenService.Model;
using NSI.Shared.ResponseData.Abstract;
using NSI.Shared.ResponseData.Concrete;
using NSI.WebApi.Queries.Authentication.Requests;
using System.Security.Claims;

namespace NSI.WebApi.Queries.Authentication.Handlers
{
    public class LoginByCridentialHandler : IRequestHandler<LoginByCridentialRequest, IBaseResponseData>
    {
        private readonly IBaseJwtTokenService jwtTokenService = new BaseJwtTokenService();

        public async Task<IBaseResponseData> Handle(LoginByCridentialRequest request, CancellationToken cancellationToken)
        {
            using IBaseResponseData responseData = new BaseResponseData();
            try
            {
                var claims = new List<Claim> { new Claim("Username", "TEST") };

                responseData.Data = await jwtTokenService.GenerateJwtTokenAsync(new BaseTokenRequestData(
                    username: "TEST",
                    issuer: "IssuerInformation",
                    audience: "AudienceInformation",
                    secret: "JWTAuthenticationHIGHsecuredPasswordVVVp1OH7Xzyr",
                    claims: claims));
            }
            catch (Exception ex)
            {
                responseData.IsError = true;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
    }
}
