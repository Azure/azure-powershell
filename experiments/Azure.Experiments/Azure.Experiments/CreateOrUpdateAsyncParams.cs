using System.Threading;

namespace Microsoft.Azure.Experiments
{
    public sealed class CreateOrUpdateAsyncParams<TOperations, TConfig>
    {
        public TOperations Operations { get; }

        public string ResourceGroupName { get; }

        public string Name { get; }

        public CancellationToken CancellationToken { get; }

        public TConfig Config { get; }

        public CreateOrUpdateAsyncParams(
            TOperations operations,
            ResourceName name,
            TConfig config,
            CancellationToken cancellationToken)
        {
            Operations = operations;
            ResourceGroupName = name.ResourceGroupName;
            Name = name.Name;
            Config = config;
            CancellationToken = cancellationToken;
        }
    }
}
