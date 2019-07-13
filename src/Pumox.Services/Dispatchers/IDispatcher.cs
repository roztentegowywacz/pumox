using System.Threading.Tasks;

namespace Pumox.Services.Dispatchers
{
    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TResult> SendAndResponseDataAsync<TResult>(ICommand<TResult> command);
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}