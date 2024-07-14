using NSI.DataAccessLayer.Abstract;
using NSI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI.UnitOfWork.Abstract
{
    public interface IBaseUnitOfWork : IDisposable
    {
        public IDepartmentDAL Department { get; }
        public IEmployeeDAL Employee { get; }
        public IEmployeeTitleDAL EmployeeTitle { get; }
        public IUserDAL User { get; }
        public IUserRoleDAL UserRole { get; }

        public Task<int> SaveChangesAsync();
    }
}
