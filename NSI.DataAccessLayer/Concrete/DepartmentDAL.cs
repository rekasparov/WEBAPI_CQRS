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
    public class DepartmentDAL : BaseRepository<Department>, IDepartmentDAL
    {
        public DepartmentDAL(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
