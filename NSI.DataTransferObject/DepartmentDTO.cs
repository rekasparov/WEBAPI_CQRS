using System;
using System.Collections.Generic;

namespace NSI.DataTransferObject;

public partial class DepartmentDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public ICollection<EmployeeDTO> Employees { get; set; } = null!;
}
