using FluentValidation;
using NSI.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI.Validation
{
    public class DepartmentValidator : AbstractValidator<DepartmentDTO>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.Name).Length(1, 50);
        }
    }
}
