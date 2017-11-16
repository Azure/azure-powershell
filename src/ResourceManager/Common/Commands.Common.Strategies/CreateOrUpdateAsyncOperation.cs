using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class CreateOrUpdateAsyncOperation
    {
        public static async Task<IState> CreateOrUpdateAsync<Model>(
            this IResourceConfig<Model> config,
            IClient client,
            IState current,
            IState target,
            CancellationToken cancellationToken)
            where Model : class
        {
            var visitor = new CreateAsyncVisitor(client, current, target, cancellationToken);
            await visitor.GetOrAdd(config);
            return visitor.Result;
        }

        sealed class CreateAsyncVisitor : AsyncOperationVisitor
        {
            public override async Task<object> Visit<Model>(ResourceConfig<Model> config)
            {
                var current = Current.GetOrNull(config);
                if (current != null)
                {
                    return current;
                }
                var tasks = config.Dependencies.Select(GetOrAddUntyped);
                await Task.WhenAll(tasks);
                return await config.Strategy.CreateOrUpdateAsync(CreateOrUpdateAsyncParams.Create(
                    Client,
                    config.ResourceGroupName,
                    config.Name,
                    Target.GetOrNull(config),
                    CancellationToken));
            }

            public override async Task<object> Visit<Model, ParentModel>(
                NestedResourceConfig<Model, ParentModel> config)
            {
                var parent = await GetOrAdd(config.Parent);
                return config.Policy.Get(parent, config.Name);
            }

            public CreateAsyncVisitor(
                IClient client,
                IState current,
                IState target,
                CancellationToken cancellationToken)
                : base(client, cancellationToken)
            {
                Current = current;
                Target = target;
            }

            IState Current { get; }
                
            IState Target { get; }
        }
    }
}
