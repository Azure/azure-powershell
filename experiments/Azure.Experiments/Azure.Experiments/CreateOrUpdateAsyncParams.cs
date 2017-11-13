using System.Threading;

namespace Microsoft.Azure.Experiments
{
    public static class CreateOrUpdateAsyncParams
    {
        public static CreateOrUpdateAsyncParams<Operations, Config> Create<Operations, Config>(
            Operations operations,
            string resourceGroupName,
            string name,
            Config config,
            CancellationToken cancellationToken)
            => new CreateOrUpdateAsyncParams<Operations, Config>(
                operations, resourceGroupName, name, config, cancellationToken);
    }

    public sealed class CreateOrUpdateAsyncParams<TOperations, TConfig>
    {
        public TOperations Operations { get; }

        public string ResourceGroupName { get; }

        public string Name { get; }

        public CancellationToken CancellationToken { get; }

        public TConfig Config { get; }

        public CreateOrUpdateAsyncParams(
            TOperations operations,
            string resourceGroupName,
            string name,
            TConfig config,
            CancellationToken cancellationToken)
        {
            Operations = operations;
            ResourceGroupName = resourceGroupName;
            Name = name;
            Config = config;
            CancellationToken = cancellationToken;
        }
    }
}
