using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class UpdateStateExtensions
    {
        public static async Task<IState> UpdateStateAsync<TModel>(
            this ResourceConfig<TModel> config,
            IClient client,
            IState target,
            CancellationToken cancellationToken,
            IShouldProcess shouldProcess)
            where TModel : class
        {
            var context = new Context(
                new StateOperationContext(client, cancellationToken), target, shouldProcess);
            await context.UpdateStateAsync(config);
            return context.Result;
        }

        sealed class Context
        {
            public IState Result => _OperationContext.Result;

            readonly StateOperationContext _OperationContext;

            readonly IState _Target;

            readonly IShouldProcess _ShouldProcess;

            public Context(
                StateOperationContext operationContext, IState target, IShouldProcess shouldProcess)
            {
                _OperationContext = operationContext;
                _Target = target;
                _ShouldProcess = shouldProcess;
            }

            public async Task UpdateStateAsync<TModel>(ResourceConfig<TModel> config)
                where TModel : class
            {
                var model = _Target.Get(config);
                if (model != null)
                {
                    await _OperationContext.GetOrAdd(
                        config,
                        async () =>
                        {
                            // wait for all dependencies
                            var tasks = config
                                .GetResourceDependencies()
                                .Select(UpdateStateAsyncDispatch);
                            await Task.WhenAll(tasks);
                            // call the CreateOrUpdateAsync function for the resource.
                            if (_ShouldProcess.ShouldCreate(config, model))
                            {
                                return await config.CreateOrUpdateAsync(
                                    _OperationContext.Client,
                                    model,
                                    _OperationContext.CancellationToken);
                            }
                            else
                            {
                                return null;
                            }
                        });
                }
            }

            public Task UpdateStateAsyncDispatch(IResourceConfig config)
                => config.Accept(new UpdateStateAsyncVisitor(), this);
        }

        sealed class UpdateStateAsyncVisitor : IResourceConfigVisitor<Context, Task>
        {
            public Task Visit<TModel>(ResourceConfig<TModel> config, Context context) 
                where TModel : class
                => context.UpdateStateAsync(config);
        }
    }
}
