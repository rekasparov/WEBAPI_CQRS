using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI.Shared.ResponseData.Abstract
{
    public interface IBaseResponseData : IDisposable
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
