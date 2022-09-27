using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.PowerShell.Ssh.Helpers.Compute;

namespace Microsoft.Azure.PowerShell.Cmdlets.Ssh.AzureClients
{
    internal class ComputeClient
    {
        public IComputeManagementClient ComputeManagementClient { get; private set; }

        public ComputeClient(IAzureContext context)
            : this(AzureSession.Instance.ClientFactory.CreateArmClient<ComputeManagementClient>(
                context, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        public ComputeClient(IComputeManagementClient computeManagementClient)
        {
            this.ComputeManagementClient = computeManagementClient;
        }
    }
}
