using System;
using System.Collections.Generic;

namespace NSI.Entity;

public partial class UserRole
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
