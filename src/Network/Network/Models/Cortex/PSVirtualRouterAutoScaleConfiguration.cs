using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSVirtualRouterAutoScaleConfiguration
    {
        [Ps1Xml(Label = "Minimum Capacity", Target = ViewControl.Table)]
        public int MinCapacity { get; set; }
    }
}