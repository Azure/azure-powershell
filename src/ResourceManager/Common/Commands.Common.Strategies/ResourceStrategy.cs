using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public sealed class ResourceStrategy<TModel> : IEntityStrategy
    {
        public Func<string, IEnumerable<string>> GetId { get; }

        public Func<IClient, GetAsyncParams, Task<TModel>> GetAsync { get; }

        public Func<IClient, CreateOrUpdateAsyncParams<TModel>, Task<TModel>> CreateOrUpdateAsync
        { get; }

        public Func<TModel, string> GetLocation { get; }

        public Action<TModel, string> SetLocation { get; }

        public ResourceStrategy(
            Func<string, IEnumerable<string>> getId,
            Func<IClient, GetAsyncParams, Task<TModel>> getAsync,
            Func<IClient, CreateOrUpdateAsyncParams<TModel>, Task<TModel>> createOrUpdateAsync,
            Func<TModel, string> getLocation,
            Action<TModel, string> setLocation)
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
        public static ResourceStrategy<TModel> Create<TModel, TClient, TOperation>(
            Func<string, IEnumerable<string>> getId,
            Func<TClient, TOperation> getOperations,
            Func<TOperation, GetAsyncParams, Task<TModel>> getAsync,
            Func<TOperation, CreateOrUpdateAsyncParams<TModel>, Task<TModel>> createOrUpdateAsync,
            Func<TModel, string> getLocation,
            Action<TModel, string> setLocation)
            where TClient : ServiceClient<TClient>
        {
            Func<IClient, TOperation> toOperations = client => getOperations(client.GetClient<TClient>());
            return new ResourceStrategy<TModel>(
                getId,
                (client, p) => getAsync(toOperations(client), p),
                (client, p) => createOrUpdateAsync(toOperations(client), p),
                getLocation,
                setLocation);
        }

        public static ResourceStrategy<TModel> Create<TModel, TClient, TOperation>(
            IEnumerable<string> headers,
            Func<TClient, TOperation> getOperations,
            Func<TOperation, GetAsyncParams, Task<TModel>> getAsync,
            Func<TOperation, CreateOrUpdateAsyncParams<TModel>, Task<TModel>> createOrUpdateAsync,
            Func<TModel, string> getLocation,
            Action<TModel, string> setLocation)
            where TClient : ServiceClient<TClient>
            => Create(
                name => new[] { "providers" }.Concat(headers).Concat(new[] { name }),
                getOperations,
                getAsync,
                createOrUpdateAsync,
                getLocation,
                setLocation);
    }
}
