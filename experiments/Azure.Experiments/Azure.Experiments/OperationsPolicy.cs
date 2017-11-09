using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public static class OperationsPolicy
    {
        public static OperationsPolicy<Client, Info> Create<Client, Info>(
            Func<Client, ResourceName, Task<Info>> getAsync,
            Func<Client, ResourceName, Info, Task<Info>> createOrUpdateAsync)
            => new OperationsPolicy<Client, Info>(getAsync, createOrUpdateAsync);
    }

    public sealed class OperationsPolicy<Client, Info>
    {
        public Func<Client, ResourceName, Task<Info>> GetAsync { get; }

        public Func<Client, ResourceName, Info, Task<Info>> CreateOrUpdateAsync { get; }

        public OperationsPolicy(
            Func<Client, ResourceName, Task<Info>> getAsync,
            Func<Client, ResourceName, Info, Task<Info>> createOrUpdateAsync)
        {
            GetAsync = getAsync;
            CreateOrUpdateAsync = createOrUpdateAsync;
        }

        public OperationsPolicy<NewClient, Info> Transform<NewClient>(Func<NewClient, Client> get)
            => OperationsPolicy.Create<NewClient, Info>(
                (client, name) => GetAsync(get(client), name),
                (client, name, info) => CreateOrUpdateAsync(get(client), name, info));
    }
}
