using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    internal class DisciplineValidator : AbstractValidator<Discipline>
    {
        public DisciplineValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(30);
            RuleFor(x => x.Year).NotEmpty().InclusiveBetween(2000, DateTime.Now.Year);
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }

    }
    
}
