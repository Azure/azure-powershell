// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;

    public partial class HubVirtualNetworkConnection
    {
        [JsonProperty(PropertyName = "properties.enableOnlyIPv6Peering", NullValueHandling = NullValueHandling.Ignore)]
        private bool? EnableOnlyIPv6PeeringCompatibility
        {
            get
            {
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    this.EnableOnlyIpv6Peering = value;
                }
            }
        }
    }

    public partial class HubVirtualNetworkConnectionProperties
    {
        [JsonProperty(PropertyName = "enableOnlyIPv6Peering", NullValueHandling = NullValueHandling.Ignore)]
        private bool? EnableOnlyIPv6PeeringCompatibility
        {
            get
            {
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    this.EnableOnlyIpv6Peering = value;
                }
            }
        }
    }
}
