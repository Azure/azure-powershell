using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSVpnLinkBgpSettings
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public long? Asn { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string BgpPeeringAddress { get; set; }
    }
}
