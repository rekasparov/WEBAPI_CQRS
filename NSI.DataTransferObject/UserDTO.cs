using System;
using System.Collections.Generic;

namespace NSI.DataTransferObject;

public partial class UserDTO
{
    public int Id { get; set; }

    public int UserRoleId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public ICollection<EmployeeDTO> Employees { get; set; } = null!;

    public UserRoleDTO UserRole { get; set; } = null!;
}
