using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI.Shared.Exceptions
{
    public class NullReference : Exception
    {
        public NullReference()
            : base("Kayıt bulunamadı!")
        {
        }
    }
}
