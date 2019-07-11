using System.Linq;
using FluentValidation;
using static Pumox.Services.Companies.Commands.UpdateCompany.UpdateCompanyCommand;

namespace Pumox.Services.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyCommand>
    {
        public UpdateCompanyValidator() 
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.EstablishmentYear).NotNull();
            RuleForEach(x => x.Employees)
                .SetValidator(new UpdateEmployerValidator())
                .When(x => x.Employees.Any());
        }
    }

    public class UpdateEmployerValidator : AbstractValidator<UpdateEmployer>
    {
        public UpdateEmployerValidator()
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.DateOfBirth).NotNull();
            RuleFor(x => x.JobTitle).NotNull().IsInEnum();
        }        
    }
}