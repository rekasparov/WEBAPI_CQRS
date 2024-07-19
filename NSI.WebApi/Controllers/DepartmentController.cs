using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSI.DataTransferObject;
using NSI.Shared.ResponseData.Abstract;
using NSI.Shared.ResponseData.Concrete;
using NSI.WebApi.Commands.Department.Requests;
using NSI.WebApi.Filters;
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
        [UserAuthorize()]
        public async Task<IBaseResponseData> Get(int take, int skip)
        {
            return await _mediator.Send(new GetDepartmentRequest(take, skip));
        }

        [HttpPost]
        public async Task<IBaseResponseData> Post(DepartmentDTO model)
        {
            return await _mediator.Send(new AddDepartmentRequest(model));
        }

        [HttpPut]
        public async Task<IBaseResponseData> Put(DepartmentDTO model)
        {
            return await _mediator.Send(new EditDepartmentRequest(model));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IBaseResponseData> Delete(int id)
        {
            return await _mediator.Send(new RemoveDepartmentRequest(id));
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
