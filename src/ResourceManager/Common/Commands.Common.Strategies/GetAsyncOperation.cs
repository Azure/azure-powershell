using Microsoft.Rest.Azure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class GetAsyncOperation
    {
        public static async Task<IState> GetAsync<Model>(
            this IResourceBaseConfig<Model> config,
            IClient client,
            CancellationToken cancellationToken)
            where Model : class
        {
            var context = new AsyncOperationContext(client, cancellationToken);
            await context.AddStateAsync(config);
            return context.Result;
        }

        static Task AddStateAsync(this AsyncOperationContext context, IResourceBaseConfig config)
            => config.Accept(new AddStateAsyncVisitor(), context);

        static async Task AddStateAsync<Model>(this AsyncOperationContext context, ResourceConfig<Model> config)
            where Model : class
            => await context.GetOrAddAsync(
                    config,
                    async () =>
                    {
                        Model info;
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
                            var tasks = config.Dependencies.Select(d => context.AddStateAsync(d));
                            await Task.WhenAll(tasks);
                            return null;
                        }
                        return info;
                    });

        static Task AddStateAsync<Model, ParentModel>(
            AsyncOperationContext context, NestedResourceConfig<Model, ParentModel> config)
            where Model : class
            where ParentModel : class
            => context.AddStateAsync(config.Parent);

        sealed class AddStateAsyncVisitor : IResourceBaseConfigVisitor<AsyncOperationContext, Task>
        {
            public Task Visit<Model>(
                ResourceConfig<Model> config, AsyncOperationContext context)
                where Model : class
                => context.AddStateAsync(config);                

            public Task Visit<Model, ParentModel>(
                NestedResourceConfig<Model, ParentModel> config, AsyncOperationContext context)
                where Model : class
                where ParentModel : class
                => context.AddStateAsync(config);
        }
    }
}
