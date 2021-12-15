using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSPrivateEndpointIPConfiguration : PSChildResource
    {
        public string Type { get; private set; }

        public string GroupId { get; set; }

        public string MemberName { get; set; }

        [Newtonsoft.Json.JsonProperty("PrivateIpAddress")]
        public string PrivateIPAddress { get; set; }
    }
}
