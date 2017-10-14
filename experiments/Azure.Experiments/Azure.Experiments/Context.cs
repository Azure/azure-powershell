using Microsoft.Azure.Management.Network;
using Microsoft.Rest;

namespace Azure.Experiments
{
    public class Context
    {
        public Context(ServiceClientCredentials credentials, string subscriptionId)
        {
            Credentials = credentials;
            SubscriptionId = subscriptionId;
        }

        public ServiceClientCredentials Credentials { get; }

        public string SubscriptionId { get; }

        public NetworkManagementClient CreateNetwork()
            => new NetworkManagementClient(Credentials)
            {
                SubscriptionId = SubscriptionId
            };
    }
}
