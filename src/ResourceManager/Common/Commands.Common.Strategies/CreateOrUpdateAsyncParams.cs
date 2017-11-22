using System.Threading;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class CreateOrUpdateAsyncParams
    {
        public static CreateOrUpdateAsyncParams<TModel> Create<TModel>(
            string resourceGroupName,
            string name,
            TModel model,
            CancellationToken cancellationToken)
            => new CreateOrUpdateAsyncParams<TModel>(
                resourceGroupName, name, model, cancellationToken);
    }

    /// <summary>
    /// Parameters for CreateOrUpdateAsync functions.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public sealed class CreateOrUpdateAsyncParams<TModel>
    {
        public string ResourceGroupName { get; }

        public string Name { get; }

        public CancellationToken CancellationToken { get; }

        public TModel Model { get; }

        public CreateOrUpdateAsyncParams(
            string resourceGroupName,
            string name,
            TModel model,
            CancellationToken cancellationToken)
        {
            ResourceGroupName = resourceGroupName;
            Name = name;
            Model = model;
            CancellationToken = cancellationToken;
        }
    }
}
