using Newtonsoft.Json;

namespace Pumox.Services.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : ICommand
    {
        public ulong Id { get; }

        [JsonConstructor]
        public DeleteCompanyCommand(ulong id)
        {
            Id = id;
        }
    }
}