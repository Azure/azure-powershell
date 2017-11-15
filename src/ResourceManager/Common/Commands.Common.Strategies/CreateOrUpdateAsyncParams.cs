using System.Threading;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class CreateOrUpdateAsyncParams
    {
        public static CreateOrUpdateAsyncParams<Operations, Model> Create<Operations, Model>(
            Operations operations,
            string resourceGroupName,
            string name,
            Model model,
            CancellationToken cancellationToken)
            => new CreateOrUpdateAsyncParams<Operations, Model>(
                operations, resourceGroupName, name, model, cancellationToken);
    }

    public sealed class CreateOrUpdateAsyncParams<TOperations, TModel>
    {
        public TOperations Operations { get; }

        public string ResourceGroupName { get; }

        public string Name { get; }

        public CancellationToken CancellationToken { get; }

        public TModel Model { get; }

        public CreateOrUpdateAsyncParams(
            TOperations operations,
            string resourceGroupName,
            string name,
            TModel model,
            CancellationToken cancellationToken)
        {
            Operations = operations;
            ResourceGroupName = resourceGroupName;
            Name = name;
            Model = model;
            CancellationToken = cancellationToken;
        }
    }
}
