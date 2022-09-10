using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology
{
    public class CreateProgrammingTechnologyValidator : AbstractValidator<CreateProgrammingTechnologyCommand>
    {
        public CreateProgrammingTechnologyValidator()
        {
            RuleFor(c => c.ProgrammingLanguageId).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
