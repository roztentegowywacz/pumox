using System.Threading.Tasks;

namespace Pumox.Services.Dispatchers
{
    public class Dispatcher : IDispatcher
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispacher;

        public Dispatcher(ICommandDispatcher commandDispatcher,
                          IQueryDispatcher queryDispacher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispacher = queryDispacher;
        }

        public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
            => await _commandDispatcher.SendAsync(command);

        public async Task<TResult> SendAndResponseDataAsync<TResult>(ICommand<TResult> command)
            => await _commandDispatcher.SendAndResponseDataAsync<TResult>(command);

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
            => await _queryDispacher.QueryAsync<TResult>(query);
    }
}