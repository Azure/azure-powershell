namespace Microsoft.Azure.Commands.Network.Models
{
    using Management.Network.Models;
    using System.Collections.Generic;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSVpnProfileResponse
    {
        [Ps1Xml(Label = "P2SVpnGateway Client Profile SASUrl", Target = ViewControl.Table)]
        public string ProfileUrl { get; set; }
    }
}