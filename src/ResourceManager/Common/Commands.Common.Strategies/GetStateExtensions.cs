using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class GetStateExtensions
    {
        /// <summary>
        /// Returns a current Azure state for the given resource (config).
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="config"></param>
        /// <param name="client"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<IState> GetStateAsync<TModel>(
            this IEntityConfig<TModel> config,
            IClient client,
            CancellationToken cancellationToken)
            where TModel : class
        {
            var context = new StateOperationContext(client, cancellationToken);
            await context.GetStateAsyncDispatch(config);
            return context.Result;
        }

        static Task GetStateAsyncDispatch(this StateOperationContext context, IEntityConfig config)
            => config.Accept(new GetStateAsyncVisitor(), context);

        static async Task GetStateAsync<TModel>(
            this StateOperationContext context, ResourceConfig<TModel> config)
            where TModel : class
            => await context.GetOrAdd(
                    config,
                    async () =>
                    {
                        var info = await config.GetAsync(context.Client, context.CancellationToken);
                        // Get state of dependencies if the resource doesn't exist
                        if (info == null)
                        {
                            var tasks = config.Dependencies.Select(context.GetStateAsyncDispatch);
                            await Task.WhenAll(tasks);
                        }
                        return info;
                    });

        static Task GetStateAsync<TModel, TParentModel>(
            this StateOperationContext context, NestedResourceConfig<TModel, TParentModel> config)
            where TModel : class
            where TParentModel : class
            => context.GetStateAsyncDispatch(config.Parent);

        sealed class GetStateAsyncVisitor : IEntityConfigVisitor<StateOperationContext, Task>
        {
            public Task Visit<TModel>(
                ResourceConfig<TModel> config, StateOperationContext context)
                where TModel : class
                => context.GetStateAsync(config);                

            public Task Visit<TModel, TParentModel>(
                NestedResourceConfig<TModel, TParentModel> config, StateOperationContext context)
                where TModel : class
                where TParentModel : class
                => context.GetStateAsync(config);
        }
    }
}
