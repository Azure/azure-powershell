namespace Microsoft.Azure.Commands.ManagementGroups.Common
{
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Management.Internal.Resources;

    public abstract class AzurePrecheckRegistrationAndAutoRegisterCmdletBase : AzureManagementGroupsCmdletBase
    {
        protected abstract string ProviderNamespace { get;  }

        protected override void BeginProcessing()
        {
            AzureSession.Instance.ClientFactory.RemoveHandler(typeof(AzurePrecheckRegistrationAndAutoRegisterDelegatingHandler));
            IAzureContext context;
            if (TryGetDefaultContext(out context)
                && context.Account != null
                && context.Subscription != null)
            {
                AzureSession.Instance.ClientFactory.AddHandler(new AzurePrecheckRegistrationAndAutoRegisterDelegatingHandler(
                    this.ProviderNamespace,
                    () =>
                    {
                        var client = new ResourceManagementClient(
                            context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                            AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context, AzureEnvironment.Endpoint.ResourceManager));
                        client.SubscriptionId = context.Subscription.Id;
                        return client;
                    },
                    s => DebugMessages.Enqueue(s)));
            }

            base.BeginProcessing();
        }
    }
}