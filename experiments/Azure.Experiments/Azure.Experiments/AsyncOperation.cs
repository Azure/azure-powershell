using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    abstract class AsyncOperation : IResourceConfigVisitor<Task<object>>
    {
        public AsyncOperation(IClient client, CancellationToken cancellationToken)
        {
            Client = client;
            CancellationToken = cancellationToken;
        }

        public async Task<object> GetOrAddUntyped(IResourceConfig config)
            => await TaskMap.GetOrAdd(
                config,
                async _ =>
                {
                    var info = await config.Apply(this);
                    Result.GetOrAddUntyped(config, () => info);
                    return info;
                });

        public async Task<Config> GetOrAdd<Config>(IResourceConfig<Config> config)
            where Config : class
        {
            var result = await GetOrAddUntyped(config);
            return result as Config;
        }

        public abstract Task<object> Visit<Config>(ResourceConfig<Config> config) where Config : class;

        public abstract Task<object> Visit<Config, ParentConfig>(NestedResourceConfig<Config, ParentConfig> config)
            where Config : class
            where ParentConfig : class;

        public IClient Client { get; }

        public CancellationToken CancellationToken { get; }

        public State Result { get; } = new State();

        ConcurrentDictionary<IResourceConfig, Task<object>> TaskMap { get; }
            = new ConcurrentDictionary<IResourceConfig, Task<object>>();
    }
}
