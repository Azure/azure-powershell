using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public abstract class ResourcePolicy<Name, Info>
        where Info : class
    {
        public abstract Task<Info> GetAsync(
            IClient client, Name name, CancellationToken cancellationToken);

        public abstract Task<Info> CreateOrUpdatesAsync(
            IClient client, Name name, Info info, CancellationToken cancellationToken);

        public abstract string GetLocation(Info info);

        public abstract void SetLocation(Info info, string location);
    }

    public abstract class ResourcePolicy<Info, RMClient, Operations> : ResourcePolicy<ResourceName, Info>
        where Info : class
        where RMClient : class, IDisposable
    {
        public sealed class GetParams
        {
            public Operations Operations { get; }

            public string ResourceGroupName { get; }

            public string Name { get; }

            public CancellationToken CancellationToken { get; }

            public GetParams(
                Operations operations, ResourceName name, CancellationToken cancellationToken)
            {
                Operations = operations;
                ResourceGroupName = name.ResourceGroupName;
                Name = name.Name;
                CancellationToken = cancellationToken;
            }
        }

        public sealed class CreateParams
        {
            public Operations Operations { get; }

            public string ResourceGroupName { get; }

            public string Name { get; }

            public Info Info { get; }

            public CancellationToken CancellationToken { get; }

            public CreateParams(
                Operations operations,
                ResourceName name,
                Info info,
                CancellationToken cancellationToken)
            {
                Operations = operations;
                ResourceGroupName = name.ResourceGroupName;
                Name = name.Name;
                Info = info;
                CancellationToken = cancellationToken;
            }
        }

        public abstract Operations GetOperations(RMClient client);

        public abstract Task<Info> GetAsync(GetParams p);

        public abstract Task<Info> CreateOrUpdateAsync(CreateParams p);

        public sealed override Task<Info> GetAsync(
            IClient client, ResourceName name, CancellationToken cancellationToken)
            => GetAsync(new GetParams(GetOperations(client), name, cancellationToken));

        public sealed override Task<Info> CreateOrUpdatesAsync(
            IClient client, ResourceName name, Info info, CancellationToken cancellationToken)
            => CreateOrUpdateAsync(new CreateParams(GetOperations(client), name, info, cancellationToken));

        Operations GetOperations(IClient client)
            => GetOperations(client.GetClient<RMClient>());
    }
}
