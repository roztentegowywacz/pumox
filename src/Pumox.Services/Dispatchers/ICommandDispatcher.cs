using System.Threading.Tasks;

namespace Pumox.Services.Dispatchers
{
    public interface ICommandDispatcher
    {
        Task SendAsync<T>(T command) where T : ICommand;
    }
}