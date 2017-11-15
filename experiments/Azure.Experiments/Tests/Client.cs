using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.ResourceManager;
using System;

namespace Microsoft.Azure.Experiments.Tests
{
    class Client : IClient
    {
        public Client(Context context)
        {
            Context = context;
        }

        public Context Context { get; }

        public T GetClient<T>()
            where T: class, IDisposable
        {
            if (typeof(T) == typeof(INetworkManagementClient))
            {
                return new NetworkManagementClient(Context.Credentials)
                {
                    SubscriptionId = Context.SubscriptionId
                } as T;
            }
            else if (typeof(T) == typeof(IResourceManagementClient))
            {
                return new ResourceManagementClient(Context.Credentials)
                {
                    SubscriptionId = Context.SubscriptionId
                } as T;
            }
            else if (typeof(T) == typeof(IComputeManagementClient))
            {
                return new ComputeManagementClient(Context.Credentials)
                {
                    SubscriptionId = Context.SubscriptionId
                } as T;
            }
            throw new Exception("unknown client type");
        }
    }
}
