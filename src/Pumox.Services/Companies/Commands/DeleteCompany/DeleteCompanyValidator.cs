using FluentValidation;

namespace Pumox.Services.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyValidator : AbstractValidator<DeleteCompanyCommand>
    {
        public DeleteCompanyValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}