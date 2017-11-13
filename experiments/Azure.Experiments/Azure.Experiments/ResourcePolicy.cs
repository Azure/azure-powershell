using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public sealed class ResourcePolicy<Config> : IResourcePolicy
    {
        public Func<GetAsyncParams<IClient>, Task<Config>> GetAsync { get; }

        public Func<CreateOrUpdateAsyncParams<IClient, Config>, Task<Config>> CreateOrUpdateAsync { get; }

        public Func<Config, string> GetLocation { get; }

        public Action<Config, string> SetLocation { get; }

        public ResourcePolicy(
            Func<GetAsyncParams<IClient>, Task<Config>> getAsync,
            Func<CreateOrUpdateAsyncParams<IClient, Config>, Task<Config>> createOrUpdateAsync,
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
        public static ResourcePolicy<Config> Create<Config, Client, Operations>(
            Func<Client, Operations> getOperations,
            Func<GetAsyncParams<Operations>, Task<Config>> getAsync,
            Func<CreateOrUpdateAsyncParams<Operations, Config>, Task<Config>> createOrUpdateAsync,
            Func<Config, string> getLocation,
            Action<Config, string> setLocation)
            where Client : class, IDisposable
        {
            Operations GetOperations(IClient client) => getOperations(client.GetClient<Client>());
            return new ResourcePolicy<Config>(
                p => getAsync(GetAsyncParams.Create(
                    GetOperations(p.Operations), p.ResourceGroupName, p.Name, p.CancellationToken)),
                p => createOrUpdateAsync(CreateOrUpdateAsyncParams.Create(
                    GetOperations(p.Operations), p.ResourceGroupName, p.Name, p.Config, p.CancellationToken)),
                getLocation,
                setLocation);
        }
    }
}
