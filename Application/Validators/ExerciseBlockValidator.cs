using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    internal class ExerciseBlockValidator : AbstractValidator<ExerciseBlock>
    {
        public ExerciseBlockValidator() 
        {
            RuleFor(x => x.LessonId).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(30);
            RuleFor(x => x.Theory.Url).NotEmpty().MaximumLength(50).MinimumLength(10);
        }
    }
}
