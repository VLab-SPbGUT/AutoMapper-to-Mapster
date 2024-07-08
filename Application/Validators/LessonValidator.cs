using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    internal class LessonValidator : AbstractValidator<Lesson>
    {
        public LessonValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(30);
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.LessonNumber).NotEmpty();

        }

    }
}
