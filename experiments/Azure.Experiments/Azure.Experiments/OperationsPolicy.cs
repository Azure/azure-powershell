using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public static class OperationsPolicy
    {
        public static OperationsPolicy<Client, Name, Info> Create<Client, Name, Info>(
            Func<Client, Name, Task<Info>> getAsync,
            Func<Client, Name, Info, Task<Info>> createOrUpdateAsync)
            => new OperationsPolicy<Client, Name, Info>(getAsync, createOrUpdateAsync);
    }

    public sealed class OperationsPolicy<Client, Name, Info>
    {
        public Func<Client, Name, Task<Info>> GetAsync { get; }

        public Func<Client, Name, Info, Task<Info>> CreateOrUpdateAsync { get; }

        public OperationsPolicy(
            Func<Client, Name, Task<Info>> getAsync,
            Func<Client, Name, Info, Task<Info>> createOrUpdateAsync)
        {
            GetAsync = getAsync;
            CreateOrUpdateAsync = createOrUpdateAsync;
        }

        public OperationsPolicy<NewClient, Name, Info> Transform<NewClient>(Func<NewClient, Client> get)
            => OperationsPolicy.Create<NewClient, Name, Info>(
                (client, name) => GetAsync(get(client), name),
                (client, name, info) => CreateOrUpdateAsync(get(client), name, info));
    }
}
