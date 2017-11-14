using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public static class ResourceOperations
    {
        public static async Task<IState> CreateAsync<Config>(
            this IResourceConfig<Config> config,
            IClient client,
            IState current,
            IState parameters,
            CancellationToken cancellationToken)
            where Config : class
        {
            var visitor = new CreateAsyncVisitor(client, current, parameters, cancellationToken);
            await visitor.GetOrAdd(config);
            return visitor.Result;
        }

        sealed class CreateAsyncVisitor : AsyncOperation
        {
            public override async Task<object> Visit<Config>(ResourceConfig<Config> config)
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
                    CancellationToken));
            }

            public override async Task<object> Visit<Config, ParentConfig>(
                NestedResourceConfig<Config, ParentConfig> config)
            {
                var parent = await GetOrAdd(config.Parent);
                return config.Policy.Get(parent);
            }

            public CreateAsyncVisitor(
                IClient client,
                IState current,
                IState parameters,
                CancellationToken cancellationToken)
                : base(client, cancellationToken)
            {
                Current = current;
                Parameters = parameters;
            }

            IState Current { get; }
                
            IState Parameters { get; }
        }
    }
}
