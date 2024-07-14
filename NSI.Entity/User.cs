using System;
using System.Collections.Generic;

namespace NSI.Entity;

public partial class User
{
    public int Id { get; set; }

    public int UserRoleId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual UserRole UserRole { get; set; } = null!;
}
