using MediatR;
using NSI.Shared.ResponseData.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI.WebApi.Queries.Department.Requests
{
    public class GetDepartmentRequest : IRequest<IBaseResponseData>
    {
        public int Take { get; }
        public int Skip { get; }
        public GetDepartmentRequest(int take, int skip)
        {
            Take = take;
            Skip = skip;
        }
    }
}
