using MediatR;
using NSI.DataTransferObject;
using NSI.Shared.ResponseData.Abstract;

namespace NSI.WebApi.Commands.Department.Requests
{
    public class AddDepartmentRequest : IRequest<IBaseResponseData>
    {
        public DepartmentDTO Department { get; }

        public AddDepartmentRequest(DepartmentDTO department)
        {
            Department = department;
        }
    }
}
