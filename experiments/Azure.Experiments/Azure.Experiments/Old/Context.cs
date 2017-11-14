using Microsoft.Azure.Experiments;
using Microsoft.Azure.Management.Network;

namespace Azure.Experiments
{
    public static class ContextEx
    {
        public static NetworkManagementClient CreateNetwork(this Context context)
            => new NetworkManagementClient(context.Credentials)
            {
                SubscriptionId = context.SubscriptionId
            };
    }
}
