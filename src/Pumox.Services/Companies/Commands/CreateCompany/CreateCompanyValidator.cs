using System.Linq;
using FluentValidation;
using static Pumox.Services.Companies.Commands.CreateCompany.CreateCompanyCommand;

namespace Pumox.Services.Companies.Commands.CreateCompany
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyValidator() 
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.EstablishmentYear).NotNull();
            RuleForEach(x => x.Employees)
                .SetValidator(new CreateEmployerValidator())
                .When(x => x.Employees.Any());
        }
    }

    public class CreateEmployerValidator : AbstractValidator<Employer>
    {
        public CreateEmployerValidator()
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.DateOfBirth).NotNull();
            RuleFor(x => x.JobTitle).NotNull().IsInEnum();
        }        
    }
}