using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSPrivateEndpointIPConfiguration
    {

        public string Name { get; set; }

        public string GroupId { get; set; }

        public string MemberName { get; set; }

        [Newtonsoft.Json.JsonProperty("PrivateIpAddress")]
        public string PrivateIPAddress { get; internal set; }

        public string Type { get; private set; }

        public string Etag { get; private set; }
    }
}
