using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public static class ResourceOperations
    {
        public static async Task<IState> CreateAsync<Config>(
            this IResourceConfig<Config> config, IClient client, IState current, IState parameters)
            where Config : class
        {
            var visitor = new CreateAsyncVisitor(client, current, parameters);
            await visitor.GetOrAdd(config);
            return visitor.Result;
        }

        sealed class CreateAsyncVisitor : IResourceConfigVisitor<Task<object>>
        {
            public async Task<object> GetOrAddUntyped(IResourceConfig config)
                => await TaskMap.GetOrAdd(
                    config,
                    async _ =>
                    {
                        var info = await config.Apply(this);
                        if (info != null)
                        {
                            Result.GetOrAddUntyped(config, () => info);
                        }
                        return info;
                    });

            public async Task<Config> GetOrAdd<Config>(IResourceConfig<Config> config)
                where Config : class
            {
                var result = await GetOrAddUntyped(config);
                return result as Config;
            }

            public async Task<object> Visit<Config>(ResourceConfig<Config> config) where Config : class
            {
                var current = Current.GetOrNull(config);
                if (current != null)
                {
                    return current;
                }
                var tasks = config.Dependencies.Select(GetOrAddUntyped);
                await Task.WhenAll(tasks);
                return await config.Policy.CreateOrUpdateAsync(CreateOrUpdateAsyncParams.Create(
                    Client,
                    config.ResourceGroupName,
                    config.Name,
                    Parameters.GetOrNull(config),
                    new CancellationToken()));
            }

            public async Task<object> Visit<Config, ParentConfig>(
                NestedResourceConfig<Config, ParentConfig> config)
                where Config : class
                where ParentConfig : class
            {
                var parent = await GetOrAdd(config.Parent);
                return config.Policy.Get(parent);
            }

            public CreateAsyncVisitor(IClient client, IState current, IState parameters)
            {
                Client = client;
                Current = current;
                Parameters = parameters;
            }

            public State Result { get; } = new State();

            IClient Client { get; }

            IState Current { get; }
                
            IState Parameters { get; }

            ConcurrentDictionary<IResourceConfig, Task<object>> TaskMap { get; }
                = new ConcurrentDictionary<IResourceConfig, Task<object>>();
        }
    }

    /*
    public sealed class CreateOperation
    {
        public Func<IClient, IStateSet, Task> CreateAsync { get; }

        public IEnumerable<CreateOperation> Dependencies { get; }

        public CreateOperation(
            Func<IClient, Task> createAsync,
            IEnumerable<CreateOperation> dependencies)
        {
            CreateAsync = createAsync;
            Dependencies = dependencies;
        }

        public static CreateOperation Create<Config>(IState state, IResourceConfig<Config> config)
            where Config : class
            => new Visitor(state).Get(config);

        sealed class Visitor : IResourceConfigVisitor<CreateOperation>
        {
            public CreateOperation Get(IResourceConfig config)
                => Map.GetOrAdd(config, _ => config.Apply(this));

            public CreateOperation Visit<Config>(ResourceConfig<Config> config) where Config : class
            {
                var info = State.Get(config);
                return info == null
                    ? new CreateOperation(
                        async (client, state) =>
                        {
                            var p = config.CreateConfig(client.Context.SubscriptionId);
                            var i = await config.Policy.CreateOrUpdateAsync(new CreateOrUpdateAsyncParams<IClient, Config>(
                                client,
                                config.ResourceGroupName,
                                config.Name,
                                p,
                                new CancellationToken()));
                            state.Set(config, i);
                        },
                        config.Dependencies.Select(d => Get(d)).Where(d => d != null))
                    : null;
            }

            public CreateOperation Visit<Config, ParentConfig>(
                NestedResourceConfig<Config, ParentConfig> config)
                where Config : class
                where ParentConfig : class
                => Get(config.Parent);

            public Visitor(IStateGet state)
            {
                State = state;
            }

            IStateGet State { get; }

            ConcurrentDictionary<IResourceConfig, CreateOperation> Map { get; }
                = new ConcurrentDictionary<IResourceConfig, CreateOperation>();
        }
    }
    */
}
