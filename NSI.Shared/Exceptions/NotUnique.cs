using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI.Shared.Exceptions
{
    public class NotUnique : Exception
    {
        public NotUnique()
            : base("Böyle bir kayıt zaten var!")
        {
        }
    }
}
