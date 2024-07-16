using Microsoft.EntityFrameworkCore;
using NSI.BusinessLayer.Abstract;
using NSI.DataTransferObject;
using NSI.Entity;
using NSI.Shared.Exceptions;
using NSI.UnitOfWork.Abstract;
using NSI.UnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI.BusinessLayer.Concrete
{
    public class DepartmentBL : IDepartmentBL
    {
        private readonly IBaseUnitOfWork unitOfWork = new BaseUnitOfWork();

        public async Task<int> AddAsync(DepartmentDTO dto, CancellationToken cancellationToken)
        {
            if (await unitOfWork.Department.Select().AnyAsync(x => x.Name.Equals(dto.Name)))
                throw new NotUnique();

            return await unitOfWork.Department
                .InsertAsync(new Entity.Department
                {
                    Name = dto.Name,
                    IsActive = true,
                }, cancellationToken);
        }

        public async Task<int> EditAsync(DepartmentDTO dto, CancellationToken cancellationToken)
        {
            var entity = await unitOfWork.Department
                .Select(x => x.Id == dto.Id)
                .FirstOrDefaultAsync();

            if (entity == null)
                throw new NullReference();

            if (await unitOfWork.Department.Select().AnyAsync(x => x.Name.Equals(dto.Name)))
                throw new NotUnique();

            entity.Name = dto.Name;
            entity.IsActive = dto.IsActive;

            return await unitOfWork.Department.UpdateAsync(entity, cancellationToken);
        }

        public async Task<ICollection<DepartmentDTO>> GetAsync(int take, int skip)
        {
            return await unitOfWork.Department
                .Select()
                .AsNoTracking()
                .Take(take)
                .Skip(skip)
                .Select(x => new DepartmentDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsActive = x.IsActive,
                })
                .ToListAsync();
        }

        public async Task<DepartmentDTO> GetByIdAsync(int id)
        {
            return (await unitOfWork.Department
                .Select(x => x.Id == id)
                .AsNoTracking()
                .Select(x => new DepartmentDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync())!;
        }

        public async Task<int> RemoveAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await unitOfWork.Department
                .Select(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (entity == null)
                throw new NullReference();

            return await unitOfWork.Department.DeleteAsync(entity, cancellationToken);
        }
    }
}
