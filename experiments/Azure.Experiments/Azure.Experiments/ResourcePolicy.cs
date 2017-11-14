using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public sealed class ResourcePolicy<Config> : IResourcePolicy
    {
        public Func<string, IEnumerable<string>> GetId { get; }

        public Func<GetAsyncParams<IClient>, Task<Config>> GetAsync { get; }

        public Func<CreateOrUpdateAsyncParams<IClient, Config>, Task<Config>> CreateOrUpdateAsync { get; }

        public Func<Config, string> GetLocation { get; }

        public Action<Config, string> SetLocation { get; }

        public ResourcePolicy(
            Func<string, IEnumerable<string>> getId,
            Func<GetAsyncParams<IClient>, Task<Config>> getAsync,
            Func<CreateOrUpdateAsyncParams<IClient, Config>, Task<Config>> createOrUpdateAsync,
            Func<Config, string> getLocation,
            Action<Config, string> setLocation)
        {
            GetId = getId;
            GetAsync = getAsync;
            CreateOrUpdateAsync = createOrUpdateAsync;
            GetLocation = getLocation;
            SetLocation = setLocation;
        }
    }

    public static class ResourcePolicy
    {
        public static ResourcePolicy<Config> Create<Config, Client, Operations>(
            Func<string, IEnumerable<string>> getId,
            Func<Client, Operations> getOperations,
            Func<GetAsyncParams<Operations>, Task<Config>> getAsync,
            Func<CreateOrUpdateAsyncParams<Operations, Config>, Task<Config>> createOrUpdateAsync,
            Func<Config, string> getLocation,
            Action<Config, string> setLocation)
            where Client : class, IDisposable
        {
            Operations GetOperations(IClient client) => getOperations(client.GetClient<Client>());
            return new ResourcePolicy<Config>(
                getId,
                p => getAsync(GetAsyncParams.Create(
                    GetOperations(p.Operations), p.ResourceGroupName, p.Name, p.CancellationToken)),
                p => createOrUpdateAsync(CreateOrUpdateAsyncParams.Create(
                    GetOperations(p.Operations), p.ResourceGroupName, p.Name, p.Config, p.CancellationToken)),
                getLocation,
                setLocation);
        }

        public static ResourcePolicy<Config> Create<Config, Client, Operations>(
            IEnumerable<string> headers,
            Func<Client, Operations> getOperations,
            Func<GetAsyncParams<Operations>, Task<Config>> getAsync,
            Func<CreateOrUpdateAsyncParams<Operations, Config>, Task<Config>> createOrUpdateAsync,
            Func<Config, string> getLocation,
            Action<Config, string> setLocation)
            where Client : class, IDisposable
            => Create(
                name => new[] { "providers" }.Concat(headers).Concat(new[] { name }),
                getOperations,
                getAsync,
                createOrUpdateAsync,
                getLocation,
                setLocation);
    }
}
