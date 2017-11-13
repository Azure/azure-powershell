using System.Threading;

namespace Microsoft.Azure.Experiments
{
    public static class GetAsyncParams
    {
        public static GetAsyncParams<Operations> Create<Operations>(
            Operations operations,
            string resourceGroupName,
            string name,
            CancellationToken cancellationToken)
            => new GetAsyncParams<Operations>(operations, resourceGroupName, name, cancellationToken);
    }

    public class GetAsyncParams<TOperations>
    {
        public TOperations Operations { get; }

        public string ResourceGroupName { get; }

        public string Name { get; }

        public CancellationToken CancellationToken { get; }

        public GetAsyncParams(
            TOperations operations,
            string resourceGroupName,
            string name,
            CancellationToken cancellationToken)
        {
            Operations = operations;
            ResourceGroupName = resourceGroupName;
            Name = name;
            CancellationToken = cancellationToken;
        }
    }
}
