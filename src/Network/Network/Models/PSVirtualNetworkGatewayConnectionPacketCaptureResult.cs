using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSVirtualNetworkGatewayConnectionPacketCaptureResult : PSTopLevelResource
    {
        public string Code { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime StartTime { get; set; }

        public string ResultsText { get; set; }

        public PSVirtualNetworkGatewayConnectionPacketCaptureResult()
        {
            this.Code = "Succeeded";
        }
    }
}
