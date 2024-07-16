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
        Task<int> AddAsync(DepartmentDTO dto, CancellationToken cancellationToken);
        Task<int> EditAsync(DepartmentDTO dto, CancellationToken cancellationToken);
        Task<int> RemoveAsync(int id, CancellationToken cancellationToken);
    }
}
