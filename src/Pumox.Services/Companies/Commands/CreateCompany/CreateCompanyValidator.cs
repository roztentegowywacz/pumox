using System.Linq;
using FluentValidation;
using static Pumox.Services.Companies.Commands.CreateCompany.CreateCompanyCommand;

namespace Pumox.Services.Companies.Commands.CreateCompany
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.EstablishmentYear).NotEmpty();
            RuleForEach(x => x.Employees)
                .SetValidator(new CreateEmployerValidator())
                .When(x => x.Employees.Any());
        }
    }

    public class CreateEmployerValidator : AbstractValidator<CreateEmployer>
    {
        public CreateEmployerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.JobTitle).NotEmpty().IsInEnum();
        }        
    }
}