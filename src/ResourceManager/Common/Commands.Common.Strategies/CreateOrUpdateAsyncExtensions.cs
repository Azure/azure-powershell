using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class CreateOrUpdateAsyncExtensions
    {
        public static async Task<IState> CreateOrUpdateAsync<TModel>(
            this ResourceConfig<TModel> config,
            IClient client,
            IState target,
            CancellationToken cancellationToken)
            where TModel : class
        {
            var context = new Context(new AsyncOperationContext(client, cancellationToken), target);
            await context.CreateOrUpdateAsync(config);
            return context.Result;
        }

        sealed class Context
        {
            public IState Result => _OperationContext.Result;

            readonly AsyncOperationContext _OperationContext;

            readonly IState _Target;

            public Context(AsyncOperationContext operationContext, IState target)
            {
                _OperationContext = operationContext;
                _Target = target;
            }

            public async Task CreateOrUpdateAsync<TModel>(ResourceConfig<TModel> config)
                where TModel : class
            {
                var model = _Target.Get(config);
                if (model != null)
                {
                    await _OperationContext.GetOrAddAsync(
                        config,
                        async () =>
                        {
                            // wait for all dependencies
                            var tasks = config.Dependencies.Select(CreateOrUpdateAsyncDispatch);                            
                            await Task.WhenAll(tasks);
                            // call the main function.
                            return await config.Strategy.CreateOrUpdateAsync(
                                _OperationContext.Client,
                                CreateOrUpdateAsyncParams.Create(
                                    config.ResourceGroupName,
                                    config.Name,
                                    model,
                                    _OperationContext.CancellationToken));
                        });
                }
            }

            public Task CreateOrUpdateAsync<TModel, TParentModel>(
                NestedResourceConfig<TModel, TParentModel> config)
                where TModel : class
                where TParentModel : class
                => CreateOrUpdateAsyncDispatch(config.Parent);

            public Task CreateOrUpdateAsyncDispatch(IEntityConfig config)
                => config.Accept(new CreateOrUpdateAsyncVisitor(), this);
        }

        sealed class CreateOrUpdateAsyncVisitor : IEntityConfigVisitor<Context, Task>
        {
            public Task Visit<TModel>(ResourceConfig<TModel> config, Context context)
                where TModel : class
                => context.CreateOrUpdateAsync(config);

            public Task Visit<TModel, TParentModel>(
                NestedResourceConfig<TModel, TParentModel> config, Context context)
                where TModel : class
                where TParentModel : class
                => context.CreateOrUpdateAsync(config);
        }
    }
}
