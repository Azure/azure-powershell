using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSVpnLinkProviderProperties
    {
        [Ps1Xml(Label = "Link Provider Name", Target = ViewControl.Table)]
        public string LinkProviderName { get; set; }

        [Ps1Xml(Label = "Link Speed in Mbps", Target = ViewControl.Table)]
        public int LinkSpeedInMbps { get; set; }
    }
}
