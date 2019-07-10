using System.Threading.Tasks;

namespace Pumox.Services
{
    public interface ICommandHandler<in T>  where T : ICommand
    {
        Task HandleAsync(T command);
    }
}