using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSI.Shared.ResponseData.Abstract;
using NSI.WebApi.Queries.Authentication.Requests;

namespace NSI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IBaseResponseData> Get()
        {
            return await _mediator.Send(new LoginByCridentialRequest("burak", "test"));
        }
    }
}
