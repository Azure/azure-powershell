using System.Threading;

namespace Microsoft.Azure.Experiments
{
    public sealed class GetAsyncParams<TOperations>
    {
        public TOperations Operations { get; }

        public string ResourceGroupName { get; }

        public string Name { get; }

        public CancellationToken CancellationToken { get; }

        public GetAsyncParams(
            TOperations operations, ResourceName name, CancellationToken cancellationToken)
        {
            Operations = operations;
            ResourceGroupName = name.ResourceGroupName;
            Name = name.Name;
            CancellationToken = cancellationToken;
        }
    }
}
