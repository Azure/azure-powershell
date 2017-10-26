using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public sealed class NetworkSecurityGroupParameters
        : ResourceParameters<NetworkSecurityGroup>
    {
        public NetworkSecurityGroupParameters(
            string name, ResourceGroupParameters resourceGroup) 
            : base(name, resourceGroup, NoDependencies)
        {
        }
    }
}
