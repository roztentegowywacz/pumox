using System;
using System.Threading.Tasks;

namespace Pumox.Services.Dispatchers
{
  public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _provider;

        public CommandDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task SendAsync<T>(T command) where T : ICommand
        {
            var handler = _provider.Resolve<ICommandHandler<T>>();

            if (handler is null)
            {
                throw new ArgumentException($"Command handler: '{typeof(T).Name} was not found.'",
                    nameof(handler));
            }

            await handler.HandleAsync(command);
        }
    }
}