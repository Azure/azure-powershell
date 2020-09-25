using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models.Cortex
{
    class PSVpnConnectionPacketCaptureResult : PSTopLevelResource
    {
        public string Code { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime StartTime { get; set; }

        public string ResultsText { get; set; }

        public string LinkConnectionName { get; set; }

        public PSVpnConnectionPacketCaptureResult()
        {
            this.Code = "Succeeded";
        }

    }
}
