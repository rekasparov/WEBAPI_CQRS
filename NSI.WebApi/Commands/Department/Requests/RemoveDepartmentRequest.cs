using MediatR;
using NSI.Shared.ResponseData.Abstract;

namespace NSI.WebApi.Commands.Department.Requests
{
    public class RemoveDepartmentRequest : IRequest<IBaseResponseData>
    {
        public int Id { get; }

        public RemoveDepartmentRequest(int id)
        {
            Id = id;
        }
    }
}
