using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSAzureFirewallPacketCaptureResponse
    {
        [JsonProperty(Order = 1)]
        public string StatusCode { get; set; }

        [JsonProperty(Order = 2)]
        public string Message { get; set; }
    }
}

