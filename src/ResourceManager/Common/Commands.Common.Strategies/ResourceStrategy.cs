using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public sealed class ResourceStrategy<Model> : IResourceStrategy
    {
        public Func<string, IEnumerable<string>> GetId { get; }

        public Func<GetAsyncParams<IClient>, Task<Model>> GetAsync { get; }

        public Func<CreateOrUpdateAsyncParams<IClient, Model>, Task<Model>> CreateOrUpdateAsync { get; }

        public Func<Model, string> GetLocation { get; }

        public Action<Model, string> SetLocation { get; }

        public ResourceStrategy(
            Func<string, IEnumerable<string>> getId,
            Func<GetAsyncParams<IClient>, Task<Model>> getAsync,
            Func<CreateOrUpdateAsyncParams<IClient, Model>, Task<Model>> createOrUpdateAsync,
            Func<Model, string> getLocation,
            Action<Model, string> setLocation)
        {
            GetId = getId;
            GetAsync = getAsync;
            CreateOrUpdateAsync = createOrUpdateAsync;
            GetLocation = getLocation;
            SetLocation = setLocation;
        }
    }

    public static class ResourceStrategy
    {
        public static ResourceStrategy<Model> Create<Model, Client, Operations>(
            Func<string, IEnumerable<string>> getId,
            Func<Client, Operations> getOperations,
            Func<GetAsyncParams<Operations>, Task<Model>> getAsync,
            Func<CreateOrUpdateAsyncParams<Operations, Model>, Task<Model>> createOrUpdateAsync,
            Func<Model, string> getLocation,
            Action<Model, string> setLocation)
            where Client : ServiceClient<Client>
        {
            Func<IClient, Operations> toOperations = client => getOperations(client.GetClient<Client>());
            return new ResourceStrategy<Model>(
                getId,
                p => getAsync(GetAsyncParams.Create(
                    toOperations(p.Operations), p.ResourceGroupName, p.Name, p.CancellationToken)),
                p => createOrUpdateAsync(CreateOrUpdateAsyncParams.Create(
                    toOperations(p.Operations), p.ResourceGroupName, p.Name, p.Model, p.CancellationToken)),
                getLocation,
                setLocation);
        }

        public static ResourceStrategy<Model> Create<Model, Client, Operations>(
            IEnumerable<string> headers,
            Func<Client, Operations> getOperations,
            Func<GetAsyncParams<Operations>, Task<Model>> getAsync,
            Func<CreateOrUpdateAsyncParams<Operations, Model>, Task<Model>> createOrUpdateAsync,
            Func<Model, string> getLocation,
            Action<Model, string> setLocation)
            where Client : ServiceClient<Client>
            => Create(
                name => new[] { "providers" }.Concat(headers).Concat(new[] { name }),
                getOperations,
                getAsync,
                createOrUpdateAsync,
                getLocation,
                setLocation);
    }
}
