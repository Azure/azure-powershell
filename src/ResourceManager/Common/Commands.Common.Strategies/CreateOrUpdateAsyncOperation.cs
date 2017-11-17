using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class CreateOrUpdateAsyncOperation
    {
        /// <summary>
        /// Asynchronous resource creation.
        /// </summary>
        /// <typeparam name="Model"></typeparam>
        /// <param name="config"></param>
        /// <param name="client"></param>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>An Azure state.</returns>
        public static async Task<IState> CreateOrUpdateAsync<Model>(
            this IResourceConfig<Model> config,
            IClient client,
            IState target,
            CancellationToken cancellationToken)
            where Model : class
        {
            var visitor = new CreateAsyncVisitor(client, target, cancellationToken);
            await visitor.GetOrAdd(config);
            return visitor.Result;
        }

        sealed class CreateAsyncVisitor : AsyncOperationVisitor
        {
            public override async Task<object> Visit<Model>(ResourceConfig<Model> config)
            {
                var target = Target.GetOrNull(config);
                if (target == null)
                {
                    return null;
                }
                var tasks = config.Dependencies.Select(GetOrAddUntyped);
                await Task.WhenAll(tasks);
                return await config.Strategy.CreateOrUpdateAsync(
                    Client,
                    CreateOrUpdateAsyncParams.Create(
                        config.ResourceGroupName,
                        config.Name,
                        Target.GetOrNull(config),
                        CancellationToken));
            }

            public override async Task<object> Visit<Model, ParentModel>(
                NestedResourceConfig<Model, ParentModel> config)
            {
                var target = Target.GetOrNull(config);
                if (target == null)
                {
                    return null;
                }
                var parent = await GetOrAdd(config.Parent);
                return config.Policy.Get(parent, config.Name);
            }

            public CreateAsyncVisitor(
                IClient client,
                IState target,
                CancellationToken cancellationToken)
                : base(client, cancellationToken)
            {
                Target = target;
            }
                
            IState Target { get; }
        }
    }
}
