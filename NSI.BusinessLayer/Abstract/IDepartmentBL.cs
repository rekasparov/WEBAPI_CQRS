using NSI.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI.BusinessLayer.Abstract
{
    public interface IDepartmentBL
    {
        Task<ICollection<DepartmentDTO>> GetAsync(int take, int skip);
        Task<DepartmentDTO> GetByIdAsync(int id);
        Task AddAsync(DepartmentDTO dto, CancellationToken cancellationToken);
        Task EditAsync(DepartmentDTO dto);
        Task RemoveAsync(int id);
        Task<int> SaveChangesAsync();
    }
}
