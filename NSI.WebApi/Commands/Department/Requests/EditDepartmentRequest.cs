using MediatR;
using NSI.DataTransferObject;
using NSI.Shared.ResponseData.Abstract;

namespace NSI.WebApi.Commands.Department.Requests
{
    public class EditDepartmentRequest : IRequest<IBaseResponseData>
    {
        public DepartmentDTO Department { get; }

        public EditDepartmentRequest(DepartmentDTO department)
        {
            Department = department;
        }
    }
}
