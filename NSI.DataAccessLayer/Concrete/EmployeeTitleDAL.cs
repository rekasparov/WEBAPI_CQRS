using Microsoft.EntityFrameworkCore;
using NSI.DataAccessLayer.Abstract;
using NSI.Entity;
using NSI.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI.DataAccessLayer.Concrete
{
    public class EmployeeTitleDAL : BaseRepository<EmployeeTitle>, IEmployeeTitleDAL
    {
        public EmployeeTitleDAL(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
