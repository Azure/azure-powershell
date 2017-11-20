using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    /*
    public static class CreateOrUpdateAsyncOperation
    {
        public static async Task<IState> CreateOrUpdateAsync<Model>(
            this ResourceConfig<Model> config,
            IClient client,
            IState target,
            CancellationToken cancellationToken)
            where Model : class
        {
            var context = new Context(client, cancellationToken, target);
        }

        sealed class Context
        {
            public AsyncOperationContext OperationContext { get; } = new AsyncOperationContext();

            public IClient Client { get; }

            public IState Target { get; }

            public CancellationToken CancellationToken { get; }

            public Context(IClient client, CancellationToken cancellationToken, IState target)
            {
                Client = client;
                CancellationToken = cancellationToken;
                Target = target;
            }
        }

        sealed class Visitor : IResourceBaseConfigVisitor<Context, Task>
        {
            public async Task Visit<Model>(ResourceConfig<Model> config, Context context)
                where Model : class
            {
                var model = context.Target.Get(config);
                if (model != null)
                {
                    await context.OperationContext.GetOrAdd(
                        config,
                        async () =>
                        {
                            foreach (var d in config.Dependencies)
                            {
                            }                            
                            return await config.Strategy.CreateOrUpdateAsync(
                                context.Client,
                                CreateOrUpdateAsyncParams.Create(
                                    config.ResourceGroupName,
                                    config.Name,
                                    model,
                                    context.CancellationToken));
                        });
                }
            }

            public Task Visit<Model, ParentModel>(NestedResourceConfig<Model, ParentModel> config, Context context)
                where Model : class
                where ParentModel : class
            {
                throw new NotImplementedException();
            }
        }
    }

    /*
    public static class CreateOrUpdateAsyncOperation
    {
        public static async Task<IState> CreateOrUpdateAsync<Model>(
            this ResourceConfig<Model> config,
            IClient client,
            IState target,
            CancellationToken cancellationToken)
            where Model : class
        {
            var context = new AsyncOperationContext();
            var model = target.Get(config);
            if (model != null)
            {
                await context.GetOrAdd(
                    config,
                    async () =>
                    {
                        // config.Dependencies
                        return await config.Strategy.CreateOrUpdateAsync(
                            client,
                            CreateOrUpdateAsyncParams.Create(
                                config.ResourceGroupName,
                                config.Name,
                                model,
                                cancellationToken));
                    });
            }
            return context.Result;
        }

        sealed class Context
        {
            AsyncOperationContext OperationContext { get; } = new AsyncOperationContext();

            IClient Client { get; }

            IState Target { get; }

            CancellationToken CancellationToken { get; }

            public async Task CreateOrUpdateAsync<Model>(ResourceConfig<Model> config)
                where Model : class
            {
                var model = Target.Get(config);
                if (model != null)
                {
                    await OperationContext.GetOrAdd(
                        config,
                        async () =>
                        {
                            // config.Dependencies
                            return await config.Strategy.CreateOrUpdateAsync(
                                    Client,
                                    CreateOrUpdateAsyncParams.Create(
                                        config.ResourceGroupName,
                                        config.Name,
                                        model,
                                        CancellationToken));
                        });
                }
            }

            public Context(IClient client, IState target, CancellationToken cancellationToken)
            {
                Client = client;
                Target = target;
                CancellationToken = cancellationToken;
            }
        }

        sealed class Visitor : IResourceBaseConfigVisitor<Context, Task>
        {
            public Task Visit<Model>(ResourceConfig<Model> config, Context context)
                where Model : class
            {
                throw new NotImplementedException();
            }

            public Task Visit<Model, ParentModel>(
                NestedResourceConfig<Model, ParentModel> config, Context context)
                where Model : class
                where ParentModel : class
            {
                throw new NotImplementedException();
            }
        }
    }

    /*
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
            this IResourceBaseConfig<Model> config,
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
                var target = Target.Get(config);
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
                        Target.Get(config),
                        CancellationToken));
            }

            public override async Task<object> Visit<Model, ParentModel>(
                NestedResourceConfig<Model, ParentModel> config)
            {
                var target = Target.GetNestedResourceModel(config);
                if (target == null)
                {
                    return null;
                }
                var parent = await GetOrAdd(config.Parent);
                return config.Strategy.Get(parent, config.Name);
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
    */
}
