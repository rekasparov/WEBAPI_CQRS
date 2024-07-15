using MediatR;
using NSI.BusinessLayer.Abstract;
using NSI.BusinessLayer.Concrete;
using NSI.Shared.ResponseData.Abstract;
using NSI.Shared.ResponseData.Concrete;
using NSI.WebApi.Commands.Department.Requests;

namespace NSI.WebApi.Commands.Department.Handlers
{
    public class RemoveDepartmentHandler : IRequestHandler<RemoveDepartmentRequest, IBaseResponseData>
    {
        private readonly IDepartmentBL _departmentBL = new DepartmentBL();

        public async Task<IBaseResponseData> Handle(RemoveDepartmentRequest request, CancellationToken cancellationToken)
        {
            using IBaseResponseData responseData = new BaseResponseData();
            try
            {
                await _departmentBL.RemoveAsync(request.Id);
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
