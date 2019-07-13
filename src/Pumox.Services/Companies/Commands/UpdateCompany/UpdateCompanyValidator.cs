using System.Linq;
using FluentValidation;
using static Pumox.Services.Companies.Commands.UpdateCompany.UpdateCompanyCommand;

namespace Pumox.Services.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyCommand>
    {
        public UpdateCompanyValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.EstablishmentYear).NotEmpty();
            RuleForEach(x => x.Employees)
                .SetValidator(new UpdateEmployerValidator())
                .When(x => x.Employees.Any());
        }
    }

    public class UpdateEmployerValidator : AbstractValidator<UpdateEmployer>
    {
        public UpdateEmployerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.JobTitle).NotEmpty().IsInEnum();
        }        
    }
}