using MediatR;
using Microsoft.IdentityModel.Tokens;
using NSI.Service.JwtTokenService.Abstract;
using NSI.Service.JwtTokenService.Concrete;
using NSI.Service.JwtTokenService.Model;
using NSI.Shared.ResponseData.Abstract;
using NSI.Shared.ResponseData.Concrete;
using NSI.WebApi.Queries.Authentication.Requests;
using System.Security.Claims;
using System.Text;

namespace NSI.WebApi.Queries.Authentication.Handlers
{
    public class LoginByCridentialHandler : IRequestHandler<LoginByCridentialRequest, IBaseResponseData>
    {
        private readonly IBaseJwtTokenService jwtTokenService = new BaseJwtTokenService();
        private readonly IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

        public async Task<IBaseResponseData> Handle(LoginByCridentialRequest request, CancellationToken cancellationToken)
        {
            using IBaseResponseData responseData = new BaseResponseData();
            try
            {
                var configurationSection = configurationBuilder.AddJsonFile("appsettings.json").Build().GetSection("JwtSettings");

                var claims = new List<Claim> { new Claim("Username", "TEST") };

                responseData.Data = await jwtTokenService.GenerateJwtTokenAsync(new BaseTokenRequestData(
                    username: "TEST",
                    issuer: configurationSection["Issuer"]!,
                    audience: configurationSection["Audience"]!,
                    secret: configurationSection["Secret"]!,
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
