using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    abstract class AsyncOperationVisitor : IResourceConfigVisitor<Task<object>>
    {
        public IClient Client { get; }

        public CancellationToken CancellationToken { get; }

        public State Result { get; } = new State();


        public AsyncOperationVisitor(IClient client, CancellationToken cancellationToken)
        {
            Client = client;
            CancellationToken = cancellationToken;
        }

        public async Task<object> GetOrAddUntyped(IResourceConfig config)
            => await TaskMap.GetOrAdd(
                config,
                async _ =>
                {
                    var model = await config.Apply(this);
                    Result.GetOrAddUntyped(config, () => model);
                    return model;
                });

        public async Task<Model> GetOrAdd<Model>(IResourceConfig<Model> config)
            where Model : class
        {
            var model = await GetOrAddUntyped(config);
            return model as Model;
        }

        public abstract Task<object> Visit<Model>(ResourceConfig<Model> config) where Model : class;

        public abstract Task<object> Visit<Model, ParentModel>(
            NestedResourceConfig<Model, ParentModel> config)
            where Model : class
            where ParentModel : class;

        ConcurrentDictionary<IResourceConfig, Task<object>> TaskMap { get; }
            = new ConcurrentDictionary<IResourceConfig, Task<object>>();
    }
}
