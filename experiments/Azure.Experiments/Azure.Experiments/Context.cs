using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest;

namespace Microsoft.Azure.Experiments
{
    public sealed class Context
    {
        public Context(ServiceClientCredentials credentials, string subscriptionId)
        {
            Credentials = credentials;
            SubscriptionId = subscriptionId;
        }

        public ServiceClientCredentials Credentials { get; }

        public string SubscriptionId { get; }

        public NetworkManagementClient CreateNetworkManagementClient()
            => new NetworkManagementClient(Credentials)
            {
                SubscriptionId = SubscriptionId
            };

        public ComputeManagementClient CreateComputeManagementClient()
            => new ComputeManagementClient(Credentials)
            {
                SubscriptionId = SubscriptionId
            };

        public ResourceManagementClient CreateResourceManagementClient()
            => new ResourceManagementClient(Credentials)
            {
                SubscriptionId = SubscriptionId
            };
    }
}
