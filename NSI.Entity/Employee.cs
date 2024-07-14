using System;
using System.Collections.Generic;

namespace NSI.Entity;

public partial class Employee
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

    public virtual Department Department { get; set; } = null!;

    public virtual EmployeeTitle EmployeeTitle { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
