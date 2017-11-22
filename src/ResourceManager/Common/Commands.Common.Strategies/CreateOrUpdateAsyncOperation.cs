using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class CreateOrUpdateAsyncOperation
    {
        public static async Task<IState> CreateOrUpdateAsync<Model>(
            this ResourceConfig<Model> config,
            IClient client,
            IState target,
            CancellationToken cancellationToken)
            where Model : class
        {
            var context = new Context(
                new AsyncOperationContext(client, cancellationToken), target);
            await context.CreateOrUpdateAsync(config);
            return context.OperationContext.Result;
        }

        sealed class Context
        {
            public AsyncOperationContext OperationContext { get; }

            public IState Target { get; }

            public Context(AsyncOperationContext operationContext, IState target)
            {
                OperationContext = operationContext;
                Target = target;
            }

            public async Task CreateOrUpdateAsync<Model>(ResourceConfig<Model> config)
                where Model : class
            {
                var model = Target.Get(config);
                if (model != null)
                {
                    await OperationContext.GetOrAddAsync(
                        config,
                        async () =>
                        {
                            var tasks = config.Dependencies.Select(CreateOrUpdateAsync);
                            await Task.WhenAll(tasks);
                            return await config.Strategy.CreateOrUpdateAsync(
                                OperationContext.Client,
                                CreateOrUpdateAsyncParams.Create(
                                    config.ResourceGroupName,
                                    config.Name,
                                    model,
                                    OperationContext.CancellationToken));
                        });
                }
            }

            public Task CreateOrUpdateAsync<Model, ParentModel>(
                NestedResourceConfig<Model, ParentModel> config)
                where Model : class
                where ParentModel : class
                => CreateOrUpdateAsync(config.Parent);

            public Task CreateOrUpdateAsync(IEntityConfig config)
                => config.Accept(new Visitor(), this);
        }

        sealed class Visitor : IEntityConfigVisitor<Context, Task>
        {
            public Task Visit<Model>(ResourceConfig<Model> config, Context context)
                where Model : class
                => context.CreateOrUpdateAsync(config);

            public Task Visit<Model, ParentModel>(
                NestedResourceConfig<Model, ParentModel> config, Context context)
                where Model : class
                where ParentModel : class
                => context.CreateOrUpdateAsync(config);
        }
    }
}
