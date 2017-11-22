using Microsoft.Rest.Azure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class GetAsyncOperation
    {
        public static async Task<IState> GetAsync<TModel>(
            this IEntityConfig<TModel> config,
            IClient client,
            CancellationToken cancellationToken)
            where TModel : class
        {
            var context = new AsyncOperationContext(client, cancellationToken);
            await context.AddStateAsyncDispatch(config);
            return context.Result;
        }

        static Task AddStateAsyncDispatch(this AsyncOperationContext context, IEntityConfig config)
            => config.Accept(new AddStateAsyncVisitor(), context);

        static async Task AddStateAsync<TModel>(
            this AsyncOperationContext context, ResourceConfig<TModel> config)
            where TModel : class
            => await context.GetOrAddAsync(
                    config,
                    async () =>
                    {
                        TModel info;
                        try
                        {
                            info = await config.Strategy.GetAsync(
                                context.Client,
                                new GetAsyncParams(
                                    config.ResourceGroupName,
                                    config.Name,
                                    context.CancellationToken));
                        }
                        catch (CloudException e)
                            when (e.Response.StatusCode == HttpStatusCode.NotFound)
                        {
                            info = null;
                        }
                        if (info == null)
                        {
                            var tasks = config.Dependencies.Select(d => context.AddStateAsyncDispatch(d));
                            await Task.WhenAll(tasks);
                            return null;
                        }
                        return info;
                    });

        static Task AddStateAsync<TModel, TParentModel>(
            this AsyncOperationContext context, NestedResourceConfig<TModel, TParentModel> config)
            where TModel : class
            where TParentModel : class
            => context.AddStateAsyncDispatch(config.Parent);

        sealed class AddStateAsyncVisitor : IEntityConfigVisitor<AsyncOperationContext, Task>
        {
            public Task Visit<TModel>(
                ResourceConfig<TModel> config, AsyncOperationContext context)
                where TModel : class
                => context.AddStateAsync(config);                

            public Task Visit<TModel, TParentModel>(
                NestedResourceConfig<TModel, TParentModel> config, AsyncOperationContext context)
                where TModel : class
                where TParentModel : class
                => context.AddStateAsync(config);
        }
    }
}
