using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    internal class ExerciseValidator : AbstractValidator<Exercise>
    {
        public ExerciseValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Example.Url).NotEmpty().MinimumLength(50);
            RuleFor(x => x.ExerciseNumber).NotEmpty();
            RuleFor(x => x.MethodicalInstructions.Url).NotEmpty();
            RuleFor(x => x.Test.Name).NotEmpty();
            RuleFor(x => x.Test.Url).NotEmpty().MaximumLength(50);
        }
    }
}
