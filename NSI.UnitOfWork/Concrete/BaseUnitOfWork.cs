using Microsoft.EntityFrameworkCore;
using NSI.DataAccessLayer.Abstract;
using NSI.DataAccessLayer.Concrete;
using NSI.Entity;
using NSI.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI.UnitOfWork.Concrete
{
    public class BaseUnitOfWork : IBaseUnitOfWork
    {
        private readonly DbContext _dbContext = new NSIContext();

        public IDepartmentDAL Department => new DepartmentDAL(_dbContext);

        public IEmployeeDAL Employee => new EmployeeDAL(_dbContext);

        public IEmployeeTitleDAL EmployeeTitle => new EmployeeTitleDAL(_dbContext);

        public IUserDAL User => new UserDAL(_dbContext);

        public IUserRoleDAL UserRole => new UserRoleDAL(_dbContext);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
