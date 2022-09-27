using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.PowerShell.Ssh.Helpers.HybridConnectivity;

namespace Microsoft.Azure.PowerShell.Cmdlets.Ssh.AzureClients
{
    internal class HybridConnectivityClient
    {
        public IHybridConnectivityManagementAPIClient HybridConectivityManagementClient { get; private set; }

        public HybridConnectivityClient(IAzureContext context)
            : this(AzureSession.Instance.ClientFactory.CreateArmClient<HybridConnectivityManagementAPIClient>(
                context, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        public HybridConnectivityClient(IHybridConnectivityManagementAPIClient hybridComputeManagementClient)
        {
            this.HybridConectivityManagementClient = hybridComputeManagementClient;
        }
    }
}
