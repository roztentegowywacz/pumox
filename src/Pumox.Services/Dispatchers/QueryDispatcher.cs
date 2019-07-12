using System;
using System.Threading.Tasks;

namespace Pumox.Services.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _provider;

        public QueryDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>)
                .MakeGenericType(query.GetType(), typeof(TResult));
            
            dynamic handler = _provider.Resolve(handlerType);

            if (handler is null)
            {
                throw new ArgumentException($"Query handler: '{handlerType.Name} was not found.'",
                    nameof(handler));
            }

            return await handler.HandleAsync((dynamic)query);
        }
    }
}