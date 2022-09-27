using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.PowerShell.Ssh.Helpers.Network;

namespace Microsoft.Azure.PowerShell.Cmdlets.Ssh.AzureClients
{
    internal class NetworkClient
    {
        public INetworkManagementClient NetworkManagementClient { get; private set; }

        public NetworkClient(IAzureContext context)
            : this(AzureSession.Instance.ClientFactory.CreateArmClient<NetworkManagementClient>(
                context, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        public NetworkClient(INetworkManagementClient networkManagementClient)
        {
            this.NetworkManagementClient = networkManagementClient;
        }
    }
}
