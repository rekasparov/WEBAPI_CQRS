using MediatR;
using NSI.BusinessLayer.Abstract;
using NSI.BusinessLayer.Concrete;
using NSI.CQRS.Queries.Department.Requests;
using NSI.Shared.ResponseData.Abstract;
using NSI.Shared.ResponseData.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI.CQRS.Queries.Department.Handlers
{
    public class GetDepartmentHandler : IRequestHandler<GetDepartmentRequest, IBaseResponseData>
    {
        private readonly IDepartmentBL _departmentBL = new DepartmentBL();

        async Task<IBaseResponseData> IRequestHandler<GetDepartmentRequest, IBaseResponseData>.Handle(GetDepartmentRequest request, CancellationToken cancellationToken)
        {
            using IBaseResponseData responseData = new BaseResponseData();
            try
            {
                responseData.Data = await _departmentBL.GetAsync(request.Take, request.Skip);
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
