// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;

    // Development bridge for azure-rest-api-specs PR 46249. Gateway-scoped lists
    // use a different model from resource-group lists. Replace this member with
    // generated support from the accepted specification before release.
    public partial class VirtualNetworkGatewayConnectionListEntity
    {
        /// <summary>
        /// Gets or sets whether FIPS compliance is enabled for this VPN connection.
        /// </summary>
        [JsonProperty(PropertyName = "properties.enableFipsCompliance", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableFipsCompliance { get; set; }
    }
}