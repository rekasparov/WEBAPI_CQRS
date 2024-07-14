using System;
using System.Collections.Generic;

namespace NSI.DataTransferObject;

public partial class EmployeeDTO
{
    public int Id { get; set; }

    public int DepartmentId { get; set; }

    public int UserId { get; set; }

    public int EmployeeTitleId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public bool Gender { get; set; }

    public string EmailAddress { get; set; } = null!;

    public bool IsActive { get; set; }

    public DepartmentDTO Department { get; set; } = null!;

    public EmployeeTitleDTO EmployeeTitle { get; set; } = null!;

    public UserDTO User { get; set; } = null!;
}
