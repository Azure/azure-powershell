using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.SignalR.Strategies
{
    sealed class Client : IClient
    {
        public string SubscriptionId { get; }

        IAzureContext Context { get; }

        public Client(IAzureContext context)
        {
            Context = context;
            SubscriptionId = Context.Subscription.Id;
        }

        public T GetClient<T>()
            where T : ServiceClient<T>
            => AzureSession.Instance.ClientFactory.CreateArmClient<T>(
                Context, AzureEnvironment.Endpoint.ResourceManager);
    }
}
