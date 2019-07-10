using System.Threading.Tasks;

namespace Pumox.Services.Dispatchers
{
    public class Dispatcher : IDispatcher
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public Dispatcher(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
            => await _commandDispatcher.SendAsync(command);
    }
}