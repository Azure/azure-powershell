using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.PowerShell.Ssh.Helpers.HybridCompute;

namespace Microsoft.Azure.PowerShell.Cmdlets.Ssh.AzureClients
{
    internal class HybridComputeClient
    {
        public IHybridComputeManagementClient HybridComputeManagementClient { get; private set; }

        public HybridComputeClient(IAzureContext context)
            : this(AzureSession.Instance.ClientFactory.CreateArmClient<HybridComputeManagementClient>(
                context, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        public HybridComputeClient(IHybridComputeManagementClient hybridComputeManagementClient)
        {
            this.HybridComputeManagementClient = hybridComputeManagementClient;
        }
    }
}
