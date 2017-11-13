using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public sealed class ResourcePolicy<Name, Config> : IResourcePolicy
    {
        public Func<IClient, Name, CancellationToken, Task<Config>> GetAsync { get; }

        public Func<IClient, Name, Config, CancellationToken, Task<Config>> CreateOrUpdateAsync { get; }

        public Func<Config, string> GetLocation { get; }

        public Action<Config, string> SetLocation { get; }

        public ResourcePolicy(
            Func<IClient, Name, CancellationToken, Task<Config>> getAsync,
            Func<IClient, Name, Config, CancellationToken, Task<Config>> createOrUpdateAsync,
            Func<Config, string> getLocation,
            Action<Config, string> setLocation)
        {
            GetAsync = getAsync;
            CreateOrUpdateAsync = createOrUpdateAsync;
            GetLocation = getLocation;
            SetLocation = setLocation;
        }
    }

    public static class ResourcePolicy
    {
        public static ResourcePolicy<Name, Config> Create<Name, Config, Client, Operations>(
            Func<Client, Operations> getOperations,
            Func<Operations, Name, CancellationToken, Task<Config>> getAsync,
            Func<Operations, Name, Config, CancellationToken, Task<Config>> createOrUpdateAsync,
            Func<Config, string> getLocation,
            Action<Config, string> setLocation)
            where Client : class, IDisposable
        {
            Operations GetOperations(IClient client) => getOperations(client.GetClient<Client>());
            return new ResourcePolicy<Name, Config>(
                (client, name, cancellationToken)
                    => getAsync(GetOperations(client), name, cancellationToken),
                (client, name, config, cancellationToken)
                    => createOrUpdateAsync(GetOperations(client), name, config, cancellationToken),
                getLocation,
                setLocation);
        }

        public static ResourcePolicy<ResourceName, Config> Create<Config, Client, Operations>(
            Func<Client, Operations> getOperations,
            Func<GetAsyncParams<Operations>, Task<Config>> getAsync,
            Func<CreateOrUpdateAsyncParams<Operations, Config>, Task<Config>> createOrUpdateAsync,
            Func<Config, string> getLocation,
            Action<Config, string> setLocation)
            where Client : class, IDisposable
            => Create<ResourceName, Config, Client, Operations>(
                getOperations,
                (operations, name, cancellationToken)
                     => getAsync(new GetAsyncParams<Operations>(
                         operations, name, cancellationToken)),
                (operations, name, config, cancellationToken)
                    => createOrUpdateAsync(new CreateOrUpdateAsyncParams<Operations, Config>(
                        operations, name, config, cancellationToken)),
                getLocation,
                setLocation);
    }
}
