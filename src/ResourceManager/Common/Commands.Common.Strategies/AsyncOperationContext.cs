using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    sealed class AsyncOperationContext
    {
        public IClient Client { get; }

        public CancellationToken CancellationToken { get; }

        public IState Result => State;

        public AsyncOperationContext(IClient client, CancellationToken cancellationToken)
        {
            Client = client;
            CancellationToken = cancellationToken;
        }

        public async Task<Model> GetOrAdd<Model>(
            ResourceConfig<Model> config, Func<Task<Model>> create)
            where Model : class
        {
            var result = await TaskMap.GetOrAdd(
                config.DefaultIdStr(),
                async _ =>
                {
                    var model = await create();
                    if (model != null)
                    {
                        State.GetOrAdd(config, () => model);
                    }
                    return model;
                });
            return result as Model;
        }

        State State { get; } = new State();

        ConcurrentDictionary<string, Task<object>> TaskMap { get; }
            = new ConcurrentDictionary<string, Task<object>>();
    }
}
