using NSI.Shared.ResponseData.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI.Shared.ResponseData.Concrete
{
    public class BaseResponseData : IBaseResponseData
    {
        public bool IsError { get; set; } = false;
        public string Message { get; set; } = null!;
        public object Data { get; set; } = null!;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
