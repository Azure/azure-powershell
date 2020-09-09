using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSHubIpConfiguration : PSChildResource
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string HostedSubnet { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }
    }
} 