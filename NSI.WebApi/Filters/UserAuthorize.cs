using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NSI.Service.JwtTokenService.Abstract;
using NSI.Service.JwtTokenService.Concrete;
using NSI.Shared.ResponseData.Abstract;
using NSI.Shared.ResponseData.Concrete;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace NSI.WebApi.Filters
{
    public class UserAuthorize : TypeFilterAttribute
    {
        public UserAuthorize()
            : base(typeof(AuthorizeActionFilter))
        {
        }
    }

    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        private readonly IBaseJwtTokenService jwtTokenService = new BaseJwtTokenService();
        private readonly IBaseResponseData responseData = new BaseResponseData();

        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Headers.Any(x => x.Key.Equals("Authorization")))
            {
                var token = context.HttpContext.Request.Headers["Authorization"].ToString().Substring("Bearer ".Length);

                var tokenIsValid = await jwtTokenService.IsValidAsync("IssuerInformation", "AudienceInformation", "JWTAuthenticationHIGHsecuredPasswordVVVp1OH7Xzyr", token);

                if (!tokenIsValid)
                {
                    responseData.IsError = true;
                    responseData.Message = "Token geçerli değil.";

                    context.HttpContext.Response.StatusCode = 401;
                    context.Result = new JsonResult(responseData);
                }
            }
            else
            {
                responseData.IsError = true;
                responseData.Message = "Token bilgisi bulunamadı.";

                context.HttpContext.Response.StatusCode = 500;
                context.Result = new JsonResult(responseData);
            }
        }
    }
}
