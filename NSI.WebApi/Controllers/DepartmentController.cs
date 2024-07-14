using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSI.Shared.ResponseData.Abstract;
using NSI.Shared.ResponseData.Concrete;
using NSI.WebApi.Queries.Department.Requests;

namespace NSI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{take:int}/{skip:int}")]
        public async Task<IBaseResponseData> Get(int take, int skip)
        {
            return await _mediator.Send(new GetDepartmentRequest(take, skip));
        }

        [HttpGet("Test")]
        public IBaseResponseData Test()
        {
            using IBaseResponseData responseData = new BaseResponseData()
            {
                Message = "İşlem başarılı!"
            };

            return responseData;
        }
    }
}
