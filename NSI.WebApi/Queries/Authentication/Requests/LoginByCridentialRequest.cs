using MediatR;
using NSI.Shared.ResponseData.Abstract;

namespace NSI.WebApi.Queries.Authentication.Requests
{
    public class LoginByCridentialRequest : IRequest<IBaseResponseData>
    {
        public string Username { get; }
        public string Password { get; set; }

        public LoginByCridentialRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
