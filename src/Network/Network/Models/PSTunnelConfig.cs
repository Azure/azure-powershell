using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSTunnelConfig
    {
        /// <summary>
        /// Tunnel Remote IP address
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string TunnelIpAddress { get; set; }

        /// <summary>
        /// Bgp peering address
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string BgpPeeringAddress { get; set; }
    }
}
